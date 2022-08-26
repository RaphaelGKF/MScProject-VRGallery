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
        popSound = GetComponent<AudioSource>(); // Get AudioSource on BubblePrefab
    }

    void OnCollisionEnter (Collision collision)
    {
        // Check if bubble has been released
        // Added a safeguard, so it wouldn't pop if it collided with itself.
        if (transform.parent == null && collision.gameObject.GetComponent<Pop>() == null)
        {
            PopBubble();
        }
    }

    private void PopBubble()
    {
        // If the bubble is gone, initiate the pop effect,play bubble sound and destroy it after 1 second.
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
        popSound.pitch = Random.Range(1 - pitchChangeMultiplier, 1 + pitchChangeMultiplier); // Change Pitch sound to differentiate the pitch of the same sound.
        popSound.PlayOneShot(popSound.clip); // Play Bubble Pop sound and let it finish before playing another
        Destroy(gameObject, 0.2f);// Destroy in 0.2 seconds
    }
}
