using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageObjectPlacement : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;
    public GameObject[] objectPrefabs;

    private Dictionary<XRReferenceImage, GameObject> referenceImageToPrefabMap = new Dictionary<XRReferenceImage, GameObject>();

    private void Awake()
    {
        // Populate the referenceImageToPrefabMap with the reference images and their corresponding prefabs
        for (int i = 0; i < trackedImageManager.referenceLibrary.count; i++)
        {
            XRReferenceImage referenceImage = trackedImageManager.referenceLibrary[i];
            if (i < objectPrefabs.Length && !referenceImageToPrefabMap.ContainsKey(referenceImage))
            {
                referenceImageToPrefabMap.Add(referenceImage, objectPrefabs[i]);
            }
        }

        // Register the ARTrackedImageManager event
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            if (referenceImageToPrefabMap.TryGetValue(trackedImage.referenceImage, out GameObject objectPrefab))
            {
                // Instantiate the corresponding prefab at the tracked image's position and rotation
                Instantiate(objectPrefab, trackedImage.transform.position, trackedImage.transform.rotation);
            }
        }
    }
}
