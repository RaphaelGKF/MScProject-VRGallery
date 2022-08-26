using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    // FOLLOW TARGET SCRIPT: SUZANNE

    public Transform target; // Set Target: Sphere

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position; // Find Direction
        Quaternion rotation = Quaternion.LookRotation(direction); // Rotation Change
        transform.rotation = rotation; 
    }
}
