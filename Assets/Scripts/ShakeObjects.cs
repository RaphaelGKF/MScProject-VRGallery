using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShakeObjects : MonoBehaviour
{
    // SHAKE OBJECTS
    [SerializeField] private List<Transform> Base, LowMids, MidRange, Highs; // Groups for objects that will react to frequency
    [SerializeField] private float speed = 0.3f; // The speed at which the objects will change.
    [SerializeField] AudioSource audioSource;

    void FixedUpdate()
    {
        // Check if audio is playing before executing the function.
        if (audioSource.isPlaying) 
        {
            MakeObjectsReact();
        } 
    }

    void MakeObjectsReact()
    {
        // For every object in the list above, 
        // Modify it's scale according to the frequency spectrum data
        foreach (Transform obj in Base)
        {
            obj.localScale = Vector3.Lerp(obj.localScale, new Vector3(AudioVisualizer.instance.GetFrequencies(0, 7, 10), AudioVisualizer.instance.GetFrequencies(0, 7, 10), AudioVisualizer.instance.GetFrequencies(0, 7, 10)), speed);
            //obj.localRotation = Quaternion.Lerp(obj.localRotation, new Quaternion((Random.Range(0,360)), (Random.Range(0, 360)), (Random.Range(0, 360)), (Random.Range(0, 360))),speed); //ROTATE
        }
        foreach (Transform obj in LowMids)
        {
            obj.localScale = Vector3.Lerp(obj.localScale, new Vector3(AudioVisualizer.instance.GetFrequencies(7, 15, 100), AudioVisualizer.instance.GetFrequencies(7, 15, 100), AudioVisualizer.instance.GetFrequencies(7, 15, 100)), speed);
            //obj.localScale = Vector3.Lerp(obj.localScale, new Vector3(1, AudioVisualizer.instance.GetFrequencies(7, 15, 100), 1), speed);
        }
        foreach (Transform obj in MidRange)
        {
            obj.localScale = Vector3.Lerp(obj.localScale, new Vector3(AudioVisualizer.instance.GetFrequencies(15, 30, 200), AudioVisualizer.instance.GetFrequencies(15, 30, 200), AudioVisualizer.instance.GetFrequencies(15, 30, 200)), speed);
        }
        foreach (Transform obj in Highs)
        {
            obj.localScale = Vector3.Lerp(obj.localScale, new Vector3(AudioVisualizer.instance.GetFrequencies(30, 32, 1000), AudioVisualizer.instance.GetFrequencies(30, 32, 1000), AudioVisualizer.instance.GetFrequencies(30, 32, 1000)), speed);
        }
    }
}
