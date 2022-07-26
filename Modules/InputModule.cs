using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputModule : GameModule
{
    private GameInput _input;
    public override void OnRegister()
    {
        _input = new GameInput();
        _input.Enable();
    }

    public void BindAction(string inputName, Action<InputAction.CallbackContext> action)
    {
        _input.FindAction(inputName).performed += action;
    }

    public override void OnUnregister()
    {
        //
    }
}
