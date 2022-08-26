using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTipColor : MonoBehaviour
    // Change Line Color
{
    public Material newMaterial;

    private void OnTriggerEnter(Collider other)
    {
            //Send message to public void setlinematerial to assign the new material
            other.SendMessageUpwards("SetLineMaterial", newMaterial, SendMessageOptions.DontRequireReceiver);
    }
}
