using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRHand : MonoBehaviour
{
    // VR HAND CODE SCRIPT
    // Model from Oculus : Oculus Hand Model

    [SerializeField] private ActionBasedController myController = null;
    [SerializeField] private Animator myAnimator = null;
    [SerializeField] private float speed = 8.0f;
    private const string ANIMATOR_GRIP_PARAM = "Grip";
    private float gripTarget = 0.0f;
    private float theGrip = 0.0f;


    // Update is called once per frame
    void Update()
    {
        //  Check if Grip button is being pressed, play animation.
        gripTarget = myController.selectAction.action.ReadValue<float>();

        if (theGrip != gripTarget)
        {
            theGrip = Mathf.MoveTowards(theGrip, gripTarget, Time.deltaTime * speed);
            myAnimator.SetFloat(ANIMATOR_GRIP_PARAM, theGrip);
        }
    }
}
