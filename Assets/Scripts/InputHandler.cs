using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public static Action<Vector2> onStartGrab;
    public static Action<Vector2> onFinishedGrab;

    private Vector2 _currentMousePos;
    private Vector2 _startedGrabAt;
    private Vector2 _finishedGrabAt;



    public void OnGrabAction(InputAction.CallbackContext action)
    {
        // Started Grabbing
        if (action.started)
        {
            this._startedGrabAt = this._currentMousePos;
            onStartGrab?.Invoke(this._startedGrabAt);
        }

        // Released Grab
        if (action.canceled)
        {
            this._finishedGrabAt = this._currentMousePos;
            onFinishedGrab?.Invoke(this._finishedGrabAt);
        }
    }

    public void UpdateMousePosition(InputAction.CallbackContext action)
    {
        // Converting mouse position into a vector 2 based on world point of camera
        Vector2 convertedPos = Camera.main.ScreenToWorldPoint(action.ReadValue<Vector2>());
        this._currentMousePos = new Vector2(Mathf.RoundToInt(convertedPos.x), Mathf.RoundToInt(convertedPos.y));
    }
}
