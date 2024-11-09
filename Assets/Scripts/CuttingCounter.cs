using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO cutKitchenObjectSO;
    public override void Interact(PlayerController player) //any logic that is specific to this type of counter goes here
    {
        if (!HasKitchenObject())
        {
            //there is no kitchen obj here
            if (player.HasKitchenObject())
            {
                //player carrying smth
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        }
        else
        {
            //there is kitchen obj here
            if (player.HasKitchenObject())
            {
                //player is carrying smth
            }
            else
            {
                //player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }

    }
    public override void InteractAlternate(PlayerController player)
    {
        if(HasKitchenObject())
        {
            //there is kitchen object here
            GetKitchenObject().DestroySelf(); //destroying the previous kitchen object for the new cutted obj

            KitchenObject.SpawnKitchenObject(cutKitchenObjectSO, this);
        }
    }
}

