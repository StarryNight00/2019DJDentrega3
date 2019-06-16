using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : PickUpChange
{
    protected override void NotifyPickUp(GameMng gameMng)
    {
        gameMng.AddIventory(itemName);
    }
}
