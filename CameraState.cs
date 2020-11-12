using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraState : MonoBehaviour
{

    public AK.Wwise.State Inside;
    public AK.Wwise.State RearView;
    // Start is called before the first frame update

    void Start()
    {
        RearView.SetValue();
    }
    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.F2))
        { RearView.SetValue(); }
        if (Input.GetKeyDown(KeyCode.F1))
        { Inside.SetValue(); }
       
    }
}

