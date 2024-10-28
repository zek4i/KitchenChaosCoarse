using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private ClearCounter clearCounter;

    public KitchenObjectSO GetKitchenObjectSO() //getter method
    {
        return kitchenObjectSO;
    }

    public void SetClearCounter(ClearCounter clearCounter)
    {
        if(this.clearCounter != null ) //previous kitchen counter
        {
            this.clearCounter.ClearKitchenObject();
        }
        if(clearCounter.HasKitchenObject()) //this should never happen
        {
            Debug.LogError("Counter already has a KitchenObject");
        }
        this.clearCounter = clearCounter; //second counter (new)
        clearCounter.SetKitchenObject(this); 

        transform.parent = clearCounter.GetKitchenObjectFollowtransform();
        transform.localPosition = Vector3.zero;
    }
    public ClearCounter GetClearCounter()
    {
        return clearCounter;
    }
}
