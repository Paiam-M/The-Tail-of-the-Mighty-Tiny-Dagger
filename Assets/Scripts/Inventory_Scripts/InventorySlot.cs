using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    public Image icon;
    Item item;

    public PlayerAttack playerAttack;
    public PlayerBasicAttack attack;

    public void AddItem(Item newItem)
    {
        item = newItem;
        item.attackType = newItem.attackType;

        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    public void UseItem()
    {
        item.Use();
        playerAttack.currentAttackType = item.attackType;
    }
}
