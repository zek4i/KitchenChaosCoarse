using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    
    public override void Interact(PlayerController player)
    {
       if(!HasKitchenObject())
        {
            //there is no kitchen obj here
            if(player.HasKitchenObject())
            {
                //player carrying smth
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        }
       else
        {
            //there is kitchen obj here
            if(player.HasKitchenObject())
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

}
