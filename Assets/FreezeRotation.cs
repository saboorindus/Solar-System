using UnityEngine;

public class FreezeRotation : MonoBehaviour
{
    private Quaternion initialRotation;

    private void Start()
    {
        // Store the initial rotation of the text GameObject
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        // Reset the rotation of the text GameObject to its initial rotation
        transform.rotation = initialRotation;
    }
}
