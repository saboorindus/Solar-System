using UnityEngine;

public class TogglePanelButton : MonoBehaviour
{
    public GameObject panelToToggle; // Reference to the panel you want to show/hide

    // Call this method to show the panel
    public void ShowPanel()
    {
        panelToToggle.SetActive(true);
    }

    // Call this method to hide the panel
    public void HidePanel()
    {
        panelToToggle.SetActive(false);
    }
}
