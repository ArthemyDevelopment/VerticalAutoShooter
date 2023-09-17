using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInputManager : MonoBehaviour
{

    public delegate void GetInput();

    public static GetInput OnLeftGetInputUp;
    public static GetInput OnLeftGetInputDown;
    public static GetInput OnRightGetInputUp;
    public static GetInput OnRightGetInputDown;

    
    public void Update()
    {
        /*if (Input.GetAxis("Horizontal") < 0)
        {
            OnLeftGetInputDown.Invoke();
            OnRightGetInputUp.Invoke();
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            OnLeftGetInputUp.Invoke();
            OnRightGetInputDown.Invoke();
        }
        else if (Input.GetAxis("Horizontal") == 0)
        {
            if(OnLeftGetInputUp!=null)OnLeftGetInputUp.Invoke();
            if(OnRightGetInputUp!=null)OnRightGetInputUp.Invoke();
        }*/
    }
}
