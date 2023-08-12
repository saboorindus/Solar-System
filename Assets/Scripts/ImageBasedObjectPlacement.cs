using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageBasedObjectPlacement : MonoBehaviour
{
    public ARSession arSession;
    public ARTrackedImageManager imageManager;
    public ARPlaneManager planeManager;
    public GameObject[] objectsToPlace;

    private bool arTrackingEnabled = false;

    private void OnEnable()
    {
        DisableARSession();
    }

    public void ToggleARTracking()
    {
        arTrackingEnabled = !arTrackingEnabled;

        if (arTrackingEnabled)
        {
            EnableARSession();
        }
        else
        {
            DisableARSession();
        }
    }

    private void EnableARSession()
    {
        arSession.enabled = true;
        imageManager.enabled = true;
        planeManager.enabled = false;
    }

    private void DisableARSession()
    {
        arSession.enabled = false;
        imageManager.enabled = false;
        planeManager.enabled = true;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        if (!arTrackingEnabled)
            return;

        foreach (var trackedImage in eventArgs.added)
        {
            PlaceObject(trackedImage);
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            PlaceObject(trackedImage);
        }
    }

    private void PlaceObject(ARTrackedImage trackedImage)
    {
        string imageName = trackedImage.referenceImage.name;

        foreach (var obj in objectsToPlace)
        {
            if (obj.name.Equals(imageName))
            {
                // Clone the object to place it in the scene
                GameObject newObject = Instantiate(obj, trackedImage.transform.position, trackedImage.transform.rotation);
                // Set the parent to the tracked image so it moves with it
                newObject.transform.parent = trackedImage.transform;
                // Adjust the scale if needed
                newObject.transform.localScale = Vector3.one;
                // Disable AR tracking for the placed object so it doesn't interfere with the parent tracking
                var anchor = newObject.GetComponent<ARAnchor>();
                if (anchor != null)
                {
                    anchor.enabled = false;
                }
                // Stop looking for other objects to match
                return;
            }
        }
    }
}
