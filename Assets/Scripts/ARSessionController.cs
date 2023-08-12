using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARSessionController : MonoBehaviour
{
    public ARTrackedImageManager imageManager;

    private bool imageTrackingEnabled = true;

    public void ToggleImageTracking()
    {
        imageTrackingEnabled = !imageTrackingEnabled;

        if (imageTrackingEnabled)
        {
            EnableImageTracking();
        }
        else
        {
            DisableImageTracking();
        }
    }

    private void EnableImageTracking()
    {
        // Enable image tracking
        imageManager.enabled = true;
    }

    private void DisableImageTracking()
    {
        // Disable image tracking
        imageManager.enabled = false;
    }
}
