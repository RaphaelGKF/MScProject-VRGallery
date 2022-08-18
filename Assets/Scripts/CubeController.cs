using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class CubeController : MonoBehaviour
{
    [SerializeField] private GameObject Gun;
    [SerializeField] private Transform movementSource;// Position of the motion
    [SerializeField] private float newPositionThresholdDistance = 0.05f;
    [SerializeField] private float addedForce = 5f;
    private List<Vector3> positionsList = new();
    private GameObject spawnMe;
    private AudioSource generateSound;
    private bool isMoving = false;
    private bool triggerDown = false;
    public GameObject CubePrefab;
    public InputActionAsset playerControls;
    InputAction trigger;
    Rigidbody rb;



    // Start is called before the first frame update
    void Start()
    {
        //Locating the input for Activate on the controller
        var gamePlayActionMap = playerControls.FindActionMap("XRI Righthand Interaction");
        trigger = gamePlayActionMap.FindAction("Activate");
        trigger.performed += OnTriggerPressed;
        trigger.canceled += OnTriggerReleased;
        trigger.Enable();

        Gun = this.gameObject;
        generateSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Continue Movement
        if (isMoving && triggerDown)
            {
                UpdateMovement();
            }
    }

    public void StartMovement()
    {
        isMoving = true;
        positionsList.Clear(); //Clear the position list 
        positionsList.Add(movementSource.position);
        if (CubePrefab && Gun)
        {
            Destroy(
                Instantiate(CubePrefab, movementSource.position, Quaternion.identity), 
                10); //Destroy creations after 10 seconds
            generateSound.Play();
        }

    }

    public void PushMovement()
    {
        isMoving = true;
        positionsList.Clear(); //Clear the position list 
        positionsList.Add(movementSource.position);
        if (CubePrefab && Gun)
        {
            Destroy(
                spawnMe = Instantiate(CubePrefab, movementSource.position, Quaternion.identity)
                , 10); //Destroy creations after 10 seconds
            rb = spawnMe.GetComponent<Rigidbody>();
            rb.AddForce(movementSource.forward * addedForce, ForceMode.Impulse);
            generateSound.Play();
        }

    }


    public void EndMovement()
    {
        isMoving = false;
        generateSound.Stop(); //Stop sound
    }

    public void UpdateMovement()
    {
        Vector3 lastPosition = positionsList[^1];
        if (Vector3.Distance(movementSource.position, lastPosition) > newPositionThresholdDistance)
        {
            positionsList.Add(movementSource.position); //Store position movements
            if (CubePrefab && Gun)
            {
                Destroy(Instantiate(CubePrefab, movementSource.position, Quaternion.identity), 30); //Destroy creations after some seconds
            }
        }
    }

    // Trigger Pressed?
    void OnTriggerPressed(InputAction.CallbackContext context)
    {
        triggerDown = true;
    }


    void OnTriggerReleased(InputAction.CallbackContext context)
    {
        triggerDown = false;
    }
}
