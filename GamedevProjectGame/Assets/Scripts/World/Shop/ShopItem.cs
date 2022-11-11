using System;
using System.Collections;
using System.Collections.Generic;
using App.Upgrades;
using App.World;
using App.World.Entity.Player.PlayerComponents;
using UnityEngine;
using Random = UnityEngine.Random;

namespace App.World.Shop
{
    public class ShopItem : MonoBehaviour
    {
        [SerializeField]
        private ObjectsContainer container;

        [SerializeField]
        private List<BaseUpgrade> upgrades;

        [SerializeField]
        private Shop shop;

        private BaseUpgrade currentUpgrade;

        private Player player;

        private float minTimeFromBuy = 0.1f;

        float timeFromBuy = 0f;

        // TODO remove
        private int price;

        private void Update()
        {
            timeFromBuy += Time.deltaTime;
        }
        private void SetRandomUpgrade()
        {
            currentUpgrade = upgrades[Random.Range(0, upgrades.Count)];
        }

        private void Awake()
        {
            player = container.Player.GetComponent<Player>();
            SetRandomUpgrade();
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log($"Press E to buy for {currentUpgrade.Cost} bones :{currentUpgrade.Desctiption}");
            shop.SellEvent.OnSell += this.TryBuy;
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            Debug.Log("Exit Trigger!");
            shop.SellEvent.OnSell -= this.TryBuy;
        }

        public void TryBuy(SellEvent ev) // on click && overlap
        {
            if (player.Money >= currentUpgrade.Cost && timeFromBuy >= minTimeFromBuy)
            {
                Buy();
            }
            else
            {
                Debug.Log("Not enough money!");
            }
            timeFromBuy = 0;
        }

        private void Buy()
        {
            player.Money -= currentUpgrade.Cost;
            var upgrade = Instantiate(currentUpgrade);
            player.GetComponent<UpgradeManager>().AddUpgrade(upgrade);
            SetRandomUpgrade();
        }
    }
}

