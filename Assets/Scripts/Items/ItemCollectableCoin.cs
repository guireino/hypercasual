using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase{

    public Collider2D collider;

    protected override void Collect(){
        base.Collect();
        ItemManager.Instance.AddCoins();
        collider.enabled = false;
    }
}