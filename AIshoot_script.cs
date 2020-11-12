using Invector.vCharacterController.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIshoot_script : MonoBehaviour
{
    public vControlAIShooter aiCanShot;
    bool prevCanShot = false;
    bool eventStarted = false;

    void Update()
    {
        var CanShot = aiCanShot._canShot;

        if (CanShot != prevCanShot)
        {
            if (CanShot)
            {
                Debug.Log("AIEventStart");
                eventStarted = true;

            }
            else if (eventStarted)
            {
                Debug.Log("AIEventStop");
                eventStarted = false;
            }

        }
       
        prevCanShot = CanShot;
    }
}
