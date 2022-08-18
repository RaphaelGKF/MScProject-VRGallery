using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform target; // Set Target

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position; // Find Direction
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation; // Direction
    }
}
