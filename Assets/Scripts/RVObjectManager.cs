using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RVObjectManager : MonoBehaviour
{
    // This script is for changing the game objects for my Music Visualizer
    // Objects should change color at random once collision is detected.
    // RESET REACTOBJECTS IN VISUALIZER.
    [SerializeField] private GameObject reactObject;
    [SerializeField] private Material emissiveMaterial;
    private Color color;
    private Color originalCol;
    private float intensityRange;
    Vector3 originalPos, originalScale;
    Rigidbody rb;


    // Start is called before the first frame update
    private void Start()
    {
        // Get Material, Rigid body and store the position of the game object
        emissiveMaterial = GetComponent<MeshRenderer>().material;
        originalPos = reactObject.transform.position;
        originalScale = reactObject.transform.localScale;
        rb = reactObject.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Change intesity value from range
        intensityRange = Random.Range(0.8f, 2f);

        // Change Color value from range
        color = new Color(Random.Range(0, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);

        // Set new emissive material color and intensity
        emissiveMaterial.SetColor("_EmissionColor", color * intensityRange);

        // Debug.Log("intensityRange is " + intensityRange);
    }


    // Call this method on the stop button on your radio controller.
    public void Reset()
    {
        // Reset Position, Rotation, Scale and Velocity.
        reactObject.transform.SetPositionAndRotation(originalPos, Quaternion.identity);
        reactObject.transform.localScale = originalScale;
        rb.velocity = Vector3.zero;

        // Set back original emissive material color and intensity
        originalCol = new Color(1.51571655f, 0.649711668f, 0, 1f);
        emissiveMaterial.SetColor("_EmissionColor", originalCol * 1.0f);
    }
}
