using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;


    public event EventHandler OnInteractAction; // player is accessing this
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable(); // Enable the Player action map so inputs can be read

        playerInputActions.Player.Interact.performed += Interact_performed; //performed is an event and Interact_performed is func name
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        //or if OnInteractAction != null this works the same
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized()
    {
        //Vector2 inputVector = new Vector2(0, 0);
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        //playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;
        return inputVector; 
    }
}
