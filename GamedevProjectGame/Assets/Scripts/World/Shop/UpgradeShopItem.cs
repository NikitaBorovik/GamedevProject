using System;
using System.Collections;
using System.Collections.Generic;
using App.Upgrades;
using App.World;
using App.World.Entity.Player.PlayerComponents;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace App.World.Shop
{
    public class UpgradeShopItem : BaseShopItem
    {

        [SerializeField]
        private List<BaseUpgrade> upgrades;

        private BaseUpgrade currentUpgrade;

        private void SetRandomUpgrade()
        {
            currentUpgrade = upgrades[Random.Range(0, upgrades.Count)];
        }
        
        protected override void Awake()
        {
            base.Awake();
            SetRandomUpgrade();
        }
        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);
            merchantInfoField.GetComponentInChildren<TextMeshPro>().text = $"Press E to buy for {currentUpgrade.Cost} bones :{currentUpgrade.Desctiption}";

        }
        protected override void OnTriggerExit2D(Collider2D collision)
        {
            base.OnTriggerExit2D(collision);
            
        }
        public override void TryBuy(SellEvent ev) // on click && overlap
        {
            if (timeFromBuy >= minTimeFromBuy)
            {
                if (player.Money >= currentUpgrade.Cost)
                {
                    Buy();
                    timeFromBuy = 0;
                    merchantInfoField.GetComponentInChildren<TextMeshPro>().text = $"Press E to buy for {currentUpgrade.Cost} bones :{currentUpgrade.Desctiption}";
                }
                else
                {
                    Debug.Log("Not enough money!");
                }
            }
        }

        public override void Buy()
        {
            player.Money -= currentUpgrade.Cost;
            var upgrade = Instantiate(currentUpgrade);
            player.GetComponent<UpgradeManager>().AddUpgrade(upgrade);
            SetRandomUpgrade();
        }
    }
}

