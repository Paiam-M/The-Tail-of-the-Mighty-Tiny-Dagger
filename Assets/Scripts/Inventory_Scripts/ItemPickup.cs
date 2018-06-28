using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ItemPickup is an object that contains an item
 * If the player touches the ItemPickup and has enough space,
 * the object should disappear and the
 */

public class ItemPickup : Interactable {

    public Item item;

    public PlayerBasicAttack attackType;

    private void Start()
    {
        player = GameObject.Find("Player");
        item.attackType = attackType;
    }

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        bool wasPickedUp = InventoryManager.instance.Add(item);

        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }
}
