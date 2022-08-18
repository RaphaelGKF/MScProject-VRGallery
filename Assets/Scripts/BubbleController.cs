using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class BubbleController : MonoBehaviour
{
    // BUBBLE GENERATION
    [SerializeField] GameObject bubblePrefab, spawnPoint, bubbleGun;
    [SerializeField] float maxlocalScaleMagnitude;
    public InputActionAsset playerControls;
    public float growRate = 1.5f;
    public float floatStrength = 20f;
    InputAction trigger;
    private GameObject bubble;
    private AudioSource inflateSound;
    private bool triggerDown = false;
    private bool isPressing = false;
    private Rigidbody rb;

    public void CreateBubble()
    {
        isPressing = true;
        if (bubbleGun && bubblePrefab)
        {

            bubble = Instantiate(bubblePrefab, spawnPoint.transform.position, Quaternion.identity);//Instatiate a bubble 
            bubble.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);//Setting local scale to 0.01f on all axes
            // Make the bubble's rigid body kinematic
            rb = bubble.GetComponent<Rigidbody>();
            rb.isKinematic = true;

            inflateSound.Play();

            // Disable box collider on the bubble gun temporarily 
            bubbleGun.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void GrowBubble()
    {
        isPressing = true;
        float incrThisFrame = growRate * Time.deltaTime;
        Vector3 changeScale = bubble.transform.localScale * incrThisFrame;
        bubble.transform.localScale += changeScale;
        
     // if bubbles magnitude is over the set magnitude then release the bubble.
        if (bubble.transform.localScale.magnitude > maxlocalScaleMagnitude)
        {
            ReleaseBubble();
        }

     // Disable box collider on the bubble gun temporarily 
        bubbleGun.GetComponent<BoxCollider>().enabled = false;
    }

    public void ReleaseBubble()
    {
        isPressing = false;  
        rb.isKinematic = false;
        Vector3 force = Vector3.up * floatStrength;// force the bubble upwards
        rb.AddForce(force);

        inflateSound.Stop();

        // Enable box collider on the bubble gun 
        bubbleGun.GetComponent<BoxCollider>().enabled = true;

    //Remove bubble after 20 seconds
        bubble = null;
        GameObject.Destroy(bubble, 20f);
    }


    // Start is called before the first frame update
    void Start()
    {
        var gamePlayActionMap = playerControls.FindActionMap("XRI Righthand Interaction");
        //Locating the input for Activate on the controller
        trigger = gamePlayActionMap.FindAction("Shoot");
        trigger.performed += OnTriggerPressed;
        trigger.canceled += OnTriggerReleased;
        trigger.Enable();

        bubbleGun = this.gameObject;
        inflateSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

       if (isPressing && triggerDown)
        {
            GrowBubble(); //Grow Bubble if bubble is present
        }
    }


    //Trigger Pressed?
    void OnTriggerPressed(InputAction.CallbackContext context)
    {
        triggerDown = true;
        
    }


    void OnTriggerReleased(InputAction.CallbackContext context)
    {
        triggerDown = false;
    }
}
