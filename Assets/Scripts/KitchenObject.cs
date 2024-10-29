using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private IKitchenObjectParent kitchenObjectParent;

    public KitchenObjectSO GetKitchenObjectSO() //getter method
    {
        return kitchenObjectSO;
    }

    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent)
    {
        if(this.kitchenObjectParent != null ) //previous kitchen counter
        {
            this.kitchenObjectParent.ClearKitchenObject();
        }
        if(kitchenObjectParent.HasKitchenObject()) //this should never happen
        {
            Debug.LogError("IKitchenObjectParent already has a KitchenObject");
        }
        this.kitchenObjectParent = kitchenObjectParent; //second counter (new)
        kitchenObjectParent.SetKitchenObject(this); 

        transform.parent = kitchenObjectParent.GetKitchenObjectFollowtransform();
        transform.localPosition = Vector3.zero;
    }
    public IKitchenObjectParent GetKitchenObjectParent()
    {
        return kitchenObjectParent;
    }
}
