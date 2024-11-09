using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter

{
    public event EventHandler OnPlayerGrabbedObject; 
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(PlayerController player)
    {
        if (!player.HasKitchenObject()) //player does not have anything
        { 
        KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);
       
        OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }
    
}
