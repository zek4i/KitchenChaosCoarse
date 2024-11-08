using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter, IKitchenObjectParent

{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;


    private KitchenObject kitchenObject;
    public override void Interact(PlayerController player)
    {
        if (kitchenObject == null) //if there is no kitchenObject existing
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this); //making code more clear
                                                                                               //kitchenObjectTransform.localPosition = Vector3.zero; //making sure that the obj appears on the right point

        }
        else
        {
            //give the object to the player
            kitchenObject.SetKitchenObjectParent(player); //giving parent to the player
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
