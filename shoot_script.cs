using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;
using Invector.vShooter;

public class shoot_script : MonoBehaviour
{
    public vShooterMeleeInput tpinput;
    bool prevButtonPressed = false;
    bool prevReload = false;
    bool eventStarted = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
       var buttonPressed = tpinput.shotInput.GetButton();

        if (buttonPressed != prevButtonPressed)
        {
            if (buttonPressed)
            {
                Debug.Log("EventStart");
                eventStarted = true;

            }
            else if(eventStarted)
            {
                Debug.Log("EventStop");
                eventStarted = false;
            }

        }
        else if (buttonPressed)
        {
            if (tpinput.isReloading && eventStarted)
            {
                Debug.Log("EventStop");
                eventStarted = false;
            }
            else if (!tpinput.isReloading && !eventStarted)
            {
                Debug.Log("EventStart");
                eventStarted = true;
            }
        }


        prevButtonPressed = buttonPressed;
        prevReload = tpinput.isReloading;

    }
}
