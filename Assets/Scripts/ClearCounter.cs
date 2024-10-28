using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private ClearCounter secondClearCounter;
    [SerializeField] private bool testing;

    private KitchenObject kitchenObject;
    private void Update()
    {
        if(testing && Input.GetKeyUp(KeyCode.T))
        {
            if(kitchenObject != null)
            {
                kitchenObject.SetClearCounter(secondClearCounter);
                //Debug.Log(kitchenObject.GetClearCounter()); will throw error as we are clearing the old counter so remove it
            }
        }
    }
    public void Interact()
    {
        if (kitchenObject == null) //if there is no kitchenObject existing
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetClearCounter(this); //making code more clear
           //kitchenObjectTransform.localPosition = Vector3.zero; //making sure that the obj appears on the right point

        }
        else
        {
            Debug.Log(kitchenObject.GetClearCounter());
        }
        
    }
    public Transform GetKitchenObjectFollowtransform()
    {
        return counterTopPoint;
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
