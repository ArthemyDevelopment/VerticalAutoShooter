using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenInputButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public enum InputList
    {
        Left,
        Right,
    }

    public InputList thisInput;
    

    public void OnPointerDown(PointerEventData eventData)
    {
        switch (thisInput)
        {
            case InputList.Left:
                UserInputManager.OnLeftGetInputDown.Invoke();
                break;
            case InputList.Right:
                UserInputManager.OnRightGetInputDown.Invoke();
                break;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        switch (thisInput)
        {
            case InputList.Left:
                UserInputManager.OnLeftGetInputUp.Invoke();
                break;
            case InputList.Right:
                UserInputManager.OnRightGetInputUp.Invoke();
                break;
        }        
    }
}
