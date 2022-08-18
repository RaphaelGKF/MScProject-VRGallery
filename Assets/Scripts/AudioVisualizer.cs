using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioVisualizer : MonoBehaviour
{
    public static AudioVisualizer instance;
    [SerializeField] private int numberOfSamples = 1024;
    public float[] spectrumWidth;
    AudioSource audioSource;

    void Start()
    {
        instance = this;

        // Initialize the float array
        spectrumWidth = new float[numberOfSamples];

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
     // Populate the array with frequency spectrum data
        audioSource.GetSpectrumData(spectrumWidth, 0, FFTWindow.Blackman);
    }

    // Get values for Frequency Groups
    public float GetFrequencies(int start, int end, int mult)
    {
        return spectrumWidth.ToList().GetRange(start, end).Average() * mult;
    }
}
