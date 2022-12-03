using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action keyAction = null;
    public Action<Define.MouseEvent> mouseAction = null;

    bool isPressed = false;

    public void OnUpdate()
    {
        if (Input.anyKey && keyAction != null)
            keyAction.Invoke();
        
        if(mouseAction != null)
        {
            if(Input.GetMouseButton(0))
            {
                mouseAction.Invoke(Define.MouseEvent.Press);
                isPressed = true;
            }
            else
            {
                if (isPressed) mouseAction.Invoke(Define.MouseEvent.Click);
                isPressed = false;
            }
        }
    }
}
