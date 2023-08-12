using UnityEngine;
using UnityEngine.UI;

public class SoundToggleButton : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isSoundPlaying;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isSoundPlaying = false;

        // Initially, the sound is stopped and muted
        audioSource.Stop();
        audioSource.mute = true;
    }

    public void OnButtonClick()
    {
        if (isSoundPlaying)
        {
            // Sound is playing, stop it and mute
            audioSource.Stop();
            audioSource.mute = true;
            isSoundPlaying = false;
        }
        else
        {
            // Sound is not playing, play it and unmute
            audioSource.Play();
            audioSource.mute = false;
            isSoundPlaying = true;
        }
    }
}
