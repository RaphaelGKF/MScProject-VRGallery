using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class DisplayPanel : MonoBehaviour
{
    // UNHIDE / DISPLAY A UI PANEL AFTER CLICK EVENT.
    [SerializeField] private GameObject panelUI;
    public bool activePanel = true;

    // Start is called before the first frame update
    void Start()
    {
        ShowMixerUI();
    }


    //When the button is pressed on the info display, call the showmixer function
    public void ButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ShowMixerUI();
        }
    }


    public void ShowMixerUI()
    {
        //if UI is already active set it to false = hidden 
        if (activePanel)
        {
            panelUI.SetActive(false);
            activePanel = false;
        }
        //if UI is hidden then set it to true = visible
        else if (!activePanel)
        {
            panelUI.SetActive(true);
            activePanel = true;
        }
    }


}
