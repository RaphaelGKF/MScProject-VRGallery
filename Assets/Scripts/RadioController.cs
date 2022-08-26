using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class RadioController : MonoBehaviour
{
    // RADIO CONTROLS TO PLAY MUSIC AND OTHER ACTIONS.
    [Header("Tracklist")]
    [SerializeField] private Track[] audioTracks; // List of tracks to play
    [SerializeField] private float musicVolume = 1f;
    private AudioSource AudioSource;
    private int trackIndex; // Identify what track is playing

    [Header("Text UI")]
    [SerializeField] private TMP_Text trackTextUI;
    

    private void Start()
    {
        // Locate Audio source
        AudioSource = GetComponent<AudioSource>(); 

        // First track
        trackIndex = 0; 
        AudioSource.clip = audioTracks[trackIndex].trackAudioClip;

        // Making the text UI the title of the current track playing
        trackTextUI.text = audioTracks[trackIndex].name;
    }

    // MAIN CONTROLS: PLAY, PAUSE , STOP

    // Play Audio
    public void PlayAudio()
    {
        AudioSource.Play();
    }

    // Pause Audio
    public void PauseAudio()
    {
        AudioSource.Pause();
    }

    // Stop Audio 
    public void StopAudio()
    {
        AudioSource.Stop();
    }

    // SECONDARY CONTROLS: PREVIOUS, NEXT

    // Next Track
    public void NextAudio()
    {
        if(trackIndex < audioTracks.Length - 1)
        {
            trackIndex++; // When button is pressed, increment track index = 0 , by 1.
            UpdateTrack(trackIndex);
        }
    }

    // Update Track clip and name
    void UpdateTrack(int index)
    {
        AudioSource.clip = audioTracks[index].trackAudioClip;
        trackTextUI.text = audioTracks[index].name;
    }

    // Previous Track
    public void PreviousAudio()
    {
        // Ensures user cannot go back on the first track
        if(trackIndex >= 1)
        {
            trackIndex--;
            UpdateTrack(trackIndex);
        }
    }



    // Update volume from slider
    public void UpdateVolume(float volume)
    {
        musicVolume = volume;
    }

    // Update is called once per frame
    void Update()
    {
        // Update audio volume by music volume which will be controlled by the slider
        AudioSource.volume = musicVolume;
    }
}
