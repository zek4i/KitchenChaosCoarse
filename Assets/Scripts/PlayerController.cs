using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IKitchenObjectParent
{
    //public static PlayerController instance;
    public static PlayerController Instance { get; private set; } //does the same thing as separate functions 
    //VS automatically creates get and set functions u dont need to create them seperately


    public event EventHandler <onSelectedCounterChangedEventArgs> onSelectedCounterChanged;
    public class onSelectedCounterChangedEventArgs : EventArgs
    {
        public ClearCounter selectedCounter; //using the same name dont be confused
    }


    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask countersLayerMask;
    [SerializeField] private Transform kitchenObjectHoldPoint;


    private bool isWalking;
    private Vector3 lastInteractDir; //to not stop interact when w key is not pressed
    private ClearCounter selectedCounter;
    private KitchenObject kitchenObject;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("we have more than 1 player instance");
        }
        Instance = this; //singleton pattern
    }
    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction; //listening to input
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        if(selectedCounter != null) //if there is a selected counter
        {
            selectedCounter.Interact(this);
        }
    }

    private void Update()
    {
        HandleMovement();
        HandleInteractions();
    }

    public bool IsWalking()
    {
        return isWalking;
    }
    private void HandleInteractions()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        if(moveDir != Vector3.zero) //if moveDir is differnt from Zero
        {
            lastInteractDir = moveDir; //now even if we stop moving we will use the last interact direction 
        }

        float interactDistance = 2f;
        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance, countersLayerMask)) //defining Raycasthit
        // the out gives the output now instead of just returning boolean value like last time
        //layerMasks are used to detect only the obj of a certain layer like how we only iteract with counters layer here
        { 
            if(raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))//to identify the object that was hit
            {// TryGetComponent automatically checks for the null value
                //has counter
                if(clearCounter != selectedCounter)
                {
                    SetSelectedCounter(clearCounter);

                }
            }
            else
            {
                SetSelectedCounter(null);
            }
        }
        else
        {
            SetSelectedCounter(null);
    
        }
    }    
    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = .7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        if (!canMove)
        {
            // Cannot move towards moveDir

            // Attempt only X movement
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

            if (canMove)
            {
                // Can move only on the X
                moveDir = moveDirX;
            }
            else
            {
                // Cannot move only on the X

                // Attempt only Z movement
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized; //so the player moves at same speed diagonally as well
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                if (canMove)
                {
                    // Can move only on the Z
                    moveDir = moveDirZ;
                }
                else
                {
                    // Cannot move in any direction
                }
            }
        }

        if (canMove)
        {
            transform.position += moveDir * moveDistance;
        }

        isWalking = moveDir != Vector3.zero;

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }

    private void SetSelectedCounter(ClearCounter selectedCounter)
    {   
        this.selectedCounter = selectedCounter;


        onSelectedCounterChanged?.Invoke(this, new onSelectedCounterChangedEventArgs
        {
            selectedCounter = selectedCounter
        });

    }

    public Transform GetKitchenObjectFollowtransform()
    {
        return kitchenObjectHoldPoint;
    }
    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }
    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }
    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }
    public bool HasKitchenObject() //checking if this counter has anything on top
    {
        return kitchenObject != null;
    }
}