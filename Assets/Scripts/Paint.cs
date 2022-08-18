using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;


public class Paint : MonoBehaviour
{
    [SerializeField] InputActionAsset playerControls;
    [SerializeField] Transform drawPositionSource;
    [SerializeField] Material lineMaterial;
    [SerializeField] Material brushHead;
    InputAction trigger;
    public float lineWidth = 0.03f;
    public float distanceThreshold = 0.05f; // min thresh for creating another line segment
    private List<Vector3> currentLinePositions = new();
    private bool triggerDown = false;
    private bool isDrawing = false;
    private LineRenderer currentLine;
    private AudioSource drawSound;




    // Start is called before the first frame update
    void Start()
    {
        var gamePlayActionMap = playerControls.FindActionMap("XRI Righthand Interaction");
        trigger = gamePlayActionMap.FindAction("Activate");
        trigger.performed += OnTriggerPressed;
        trigger.canceled += OnTriggerReleased;
        trigger.Enable();

        drawSound = GetComponent<AudioSource>();

    }


    // Update is called once per frame
    void Update()
    {
        if (isDrawing && triggerDown)
            UpdateDrawing();
    }

    // Set line/stroke color
    public void SetLineMaterial(Material newMat)
    {
        lineMaterial = newMat;
    }



    // Draw Line
    public void StartDrawing()
    {
        isDrawing = true;
        //Create Line/Stroke
        GameObject lineGameObject = new("Line");
        currentLine = lineGameObject.AddComponent<LineRenderer>();
        drawSound.Play();
        UpdateLine();

        // Destroy brush stroke after 1 minute
        GameObject.Destroy(lineGameObject, 60f);
    }

    //Update Line
    void UpdateLine()
    {
        //Update Line Position
        currentLinePositions.Add(drawPositionSource.position);//Source of the Position
        currentLine.positionCount = currentLinePositions.Count;// Current number of position
        currentLine.SetPositions(currentLinePositions.ToArray());//Set position


        //update line visual
        currentLine.material = lineMaterial;
        currentLine.startWidth = lineWidth;




    }

    public void StopDrawing()
    {
        isDrawing = false;
        //Clear line data positions
        currentLinePositions.Clear();
        currentLine = null;

        drawSound.Stop();
    }

    void UpdateDrawing()
    {
        //Check if we have a line
        if (!currentLine 
            || currentLinePositions.Count == 0)
        {
            return;
        }

        Vector3 lastSetPosition = currentLinePositions[currentLinePositions.Count - 1];
        if (Vector3.Distance(lastSetPosition, drawPositionSource.position) > distanceThreshold)
        {
            UpdateLine();
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
