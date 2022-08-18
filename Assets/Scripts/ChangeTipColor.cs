using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTipColor : MonoBehaviour
    
{
    public Material newMaterial;

    private void OnTriggerEnter(Collider other)
    {
            //Change Line Color
            other.SendMessageUpwards("SetLineMaterial", newMaterial, SendMessageOptions.DontRequireReceiver);
    }
}
