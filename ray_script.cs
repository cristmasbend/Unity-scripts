using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ray_script : MonoBehaviour
{
    public GameObject cameraObject;
    public float distanceToCamera;
    RaycastHit rh;
    Vector3 TargetDirection;

    void Update()

    {
        TargetDirection = cameraObject.transform.position - transform.position;
        distanceToCamera = Vector3.Distance(transform.position, cameraObject.transform.position);
        Physics.Raycast(transform.position, TargetDirection, out rh, distanceToCamera);
        if (rh.collider.tag == "Occlusion")
        {
            Debug.DrawLine(transform.position, cameraObject.transform.position, Color.red);
        }
        else if (rh.collider.tag == "MainCamera")
        {
            Debug.DrawLine(transform.position, cameraObject.transform.position, Color.green);
        }
           
    }
}
