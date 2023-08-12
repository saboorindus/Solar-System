using UnityEngine;
using UnityEngine.UI;

public class ObjectSliderController : MonoBehaviour
{
    [System.Serializable]
    public class ObjectData
    {
        public GameObject miniModelPrefab;
        public Transform largeObjectTransform;
    }

    public ObjectData[] objectDataArray;
    public Slider slider;
    public Transform largeObjectDisplay;
    private GameObject[] miniModels;
    private int currentIndex = 0;

    private void Start()
    {
        // Hide all objects at the beginning
        foreach (ObjectData data in objectDataArray)
        {
            data.largeObjectTransform.gameObject.SetActive(false);
        }

        // Instantiate the mini models on the slider
        miniModels = new GameObject[objectDataArray.Length];
        for (int i = 0; i < objectDataArray.Length; i++)
        {
            GameObject miniModel = Instantiate(objectDataArray[i].miniModelPrefab, slider.transform);
            miniModel.transform.localPosition = new Vector3((i - objectDataArray.Length / 2f) * 50f, 0f, 0f);
            miniModel.GetComponent<Button>().onClick.AddListener(() => OnMiniModelClick(i));
            miniModels[i] = miniModel;
        }

        // Display the first object
        ShowObject(currentIndex);
    }

    public void OnSliderValueChanged()
    {
        currentIndex = (int)(slider.value * objectDataArray.Length);
        ShowObject(currentIndex);
    }

    public void OnMiniModelClick(int index)
    {
        currentIndex = index;
        ShowObject(currentIndex);
    }

    private void ShowObject(int index)
    {
        // Hide all objects first
        foreach (ObjectData data in objectDataArray)
        {
            data.largeObjectTransform.gameObject.SetActive(false);
        }

        // Show the object at the given index
        if (index >= 0 && index < objectDataArray.Length)
        {
            objectDataArray[index].largeObjectTransform.gameObject.SetActive(true);

            // Position the large object display in front of the user
            largeObjectDisplay.position = Camera.main.transform.position + Camera.main.transform.forward * 2f;
            largeObjectDisplay.rotation = Quaternion.identity;
            largeObjectDisplay.localScale = Vector3.one;
        }
    }
}
