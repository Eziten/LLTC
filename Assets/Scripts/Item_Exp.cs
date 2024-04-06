using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Exp : Item
{
    public override void MoveEnd()
    {
        Player.Instance.AddExp(30);

        ItemSpawner.Instance.PushToPool("Item_Exp", gameObject);
    }
}
