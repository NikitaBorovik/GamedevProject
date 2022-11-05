using App.World.Entity.Player.PlayerComponents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyDropItem : BaseDropItem
{
    [SerializeField]
    private int price;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Player>().Money += price;
        Destroy(this.gameObject);
    }
}
