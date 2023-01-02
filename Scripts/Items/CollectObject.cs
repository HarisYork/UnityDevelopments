using UnityEngine;
using System.Collections.Generic;

public class CollectObject : InteractableObject
{
    public Items item;
    public override void Interact()
    {
        base.Interact();
        PickUP();
    }
    // void PickUP()
    // {   
    //     Debug.Log("PickingUp " +item.itemName);
    //     inventory.instance.Add(item);
    //     Destroy(gameObject);
    // }
    void PickUP()
    {   
        Inventory.instance.Add(item);
        Destroy(gameObject);
    }
}
