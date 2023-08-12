using UnityEngine;

public class Spin : MonoBehaviour
{
    public float rotationSpeed = 10f; // The speed at which the Earth rotates

    void Update()
    {
        // Rotate the Earth around the Y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
