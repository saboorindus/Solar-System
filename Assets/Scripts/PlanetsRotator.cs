using UnityEngine;

public class PlanetsRotator : MonoBehaviour
{
    public Transform sun; // Reference to the sun object
    public Transform[] planets; // Array of planet objects
    public float rotationSpeed = 10f; // Speed of rotation for the planets
    public float orbitSpeed = 20f; // Speed of orbit for the planets

    private void Update()
    {
        // Rotate the sun
        sun.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Rotate and orbit the planets
        for (int i = 0; i < planets.Length; i++)
        {
            // Rotate the planet around its own axis
            planets[i].Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

            // Orbit the planet around the sun
            planets[i].RotateAround(sun.position, Vector3.up, orbitSpeed * Time.deltaTime * (i + 1));
        }
    }
}
