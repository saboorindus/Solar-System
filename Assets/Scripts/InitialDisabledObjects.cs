using UnityEngine;

public class InitialDisabledObjects : MonoBehaviour
{
    public GameObject[] objectsToDisableOnStart;

    private void Start()
    {
        // Initially disable the specified objects
        DisableObjects();
    }

    public void DisableObjects()
    {
        foreach (GameObject obj in objectsToDisableOnStart)
        {
            if (obj != null)
                obj.SetActive(false);
        }
    }
}
