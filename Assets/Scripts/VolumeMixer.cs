using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeMixer : MonoBehaviour
{
    [SerializeField] private float musicVolume = 1f;
    public AudioSource AudioSource;

    // Update is called once per frame
    void Update()
    {
    // Update audio volume by music volume which will be controlled by the slider

        AudioSource.volume = musicVolume;

    }

    // Update volume from slider
    public void UpdateVolume(float volume)
    {
        musicVolume = volume;
    }

    // Play or Unpause Audio
    public void PlayAudio()
    {
        AudioSource.UnPause();
    }

    // Pause Audio
    public void PauseAudio()
    {
        AudioSource.Pause();
    }

    // Reset Audio song
    public void ResetAudio()
    {
        AudioSource.Play();
    }
}
