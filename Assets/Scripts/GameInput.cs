using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable(); // Enable the Player action map so inputs can be read
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
