using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : PickUp
{
    [SerializeField] string itemName;

    protected override void NotifyPickUp(GameMng gameMng)
    {
        gameMng.AddIventory(itemName);
    }
}
