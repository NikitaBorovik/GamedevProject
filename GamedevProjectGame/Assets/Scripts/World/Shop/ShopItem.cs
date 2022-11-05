using System;
using System.Collections;
using System.Collections.Generic;
using App.World;
using App.World.Entity.Player.PlayerComponents;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [SerializeField]
    private bool bActive = false;

    [SerializeField]
    private ObjectsContainer container;

    private Player player;

    private void Awake()
    {
        player = container.Player.GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        bActive = true;
    }

    private void OnTriggerExit(Collider other)
    {
        bActive = false;
    }

    public void TryBuy()
    {
        if (bActive /* && enough money */)
        {
            Buy();
        }
        else
        {
            //FailSound();
        }
    }

    private void Buy()
    {
        
    }
}
