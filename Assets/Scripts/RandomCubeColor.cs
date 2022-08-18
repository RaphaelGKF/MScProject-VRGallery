using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubeColor : MonoBehaviour
{
    // CUBE GUNS - RANDOM COLOR SCRIPT

    void Start()
    {
        //Get random Color for every cube generated
        gameObject.GetComponent<MeshRenderer>().material.color = new 
            Color(Random.Range(0, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        //  CubePrefab.GetComponent<MeshRenderer>().sharedMaterial.color = new Color(Random.Range(0, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
    }
}
