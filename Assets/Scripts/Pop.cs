using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pop : MonoBehaviour
{
    // POP BUBBLE & PLAY SOUND SCRIPT

    [SerializeField] AudioClip[] popping;
    private AudioSource popSound;
    public GameObject popEffectPrefab;
    [Range(0.1f, 0.5f)]
    public float pitchChangeMultiplier;


    private void Start()
    {
        popSound = GetComponent<AudioSource>();
    }

    void OnCollisionEnter (Collision collision)
    {
       
        //Check if bubble has been released
        if (transform.parent == null && collision.gameObject.GetComponent<Pop>() == null)//remove 2nd parameter
        {
            
            PopBubble();
        }
    }

    private void PopBubble()
    {
        if (popEffectPrefab != null)
        {
            GameObject effect = Instantiate(popEffectPrefab, transform.position, transform.rotation);
            PopBubblesSound();
            Destroy(effect, 1f);
        }
    }

    void PopBubblesSound()
    {
        popSound.clip = popping[Random.Range(0, popping.Length)];
        popSound.pitch = Random.Range(1 - pitchChangeMultiplier, 1 + pitchChangeMultiplier);
        popSound.PlayOneShot(popSound.clip);
        Destroy(gameObject, 0.2f);// destroy in some seconds
    }

}
