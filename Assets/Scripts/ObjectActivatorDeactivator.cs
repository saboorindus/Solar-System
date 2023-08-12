using UnityEngine;

public class ObjectActivatorDeactivator : MonoBehaviour
{
    public GameObject[] objectsToActivate;
    public GameObject[] objectsToDeactivate;

    public void ToggleObjects()
    {
        foreach (GameObject obj in objectsToActivate)
        {
            if (obj != null)
                obj.SetActive(true); // Always activate the object
        }

        foreach (GameObject obj in objectsToDeactivate)
        {
            if (obj != null)
                obj.SetActive(false); // Always deactivate the object
        }
    }
}
