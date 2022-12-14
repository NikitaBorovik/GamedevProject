using App.Upgrades;
using App.World.Entity.Player.PlayerComponents;
using App.World.Entity.Player.Weapons;
using App.World.Shop;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace App.World.Shops
{
    public class WeaponShopItem : BaseShopItem
    {
        [SerializeField]
        private List<WeaponSO> weapons;

        [SerializeField]
        private SpriteRenderer spriteRenderer;

        private WeaponSO currentWeapon;

        private WeaponSO previousWeapon;



        
        private void SetRandomWeapon()
        {
            do
            {
                int randomIndex = Random.Range(0, weapons.Count);
                currentWeapon = weapons[randomIndex];
                Debug.Log($"Current weapon: {currentWeapon == null}");
                Debug.Log($"Player: {player.Weapon == null}");
            } while (currentWeapon == player.Weapon.Data);
            spriteRenderer.sprite = currentWeapon.weaponSpriteForShop;

        }
        private new void Awake()
        {
            base.Awake();
        }
        private void Start()
        {
            SetRandomWeapon();
        }
        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);
            merchantInfoField.GetComponentInChildren<TextMeshPro>().text = $"Press E to buy for {currentWeapon.cost} bones : {currentWeapon.description}";
        }
        protected override void OnTriggerExit2D(Collider2D collision)
        {
            base.OnTriggerExit2D(collision);
        }
        public override void TryBuy(SellEvent ev) // on click && overlap
        {
            if (timeFromBuy >= minTimeFromBuy)
            {
                if (player.Money >= currentWeapon.cost)
                {
                    Buy();
                    timeFromBuy = 0;
                    merchantInfoField.GetComponentInChildren<TextMeshPro>().text = $"Press E to buy for {currentWeapon.cost} bones : {currentWeapon.description}";
                }
                else
                {
                    Debug.Log("Not enough money!");
                }
            }
        }

        public override void Buy()
        {
            player.Money -= currentWeapon.cost;
            player.GetComponent<UpgradeManager>().DisableAll();
            GameObject.Destroy(player.CurWeaponObj);
            player.CurWeaponObj = Instantiate(currentWeapon.weaponPrefab, player.WeaponPoint.position, Quaternion.identity, player.WeaponPoint);
            player.CurWeaponObj.transform.rotation = player.WeaponPoint.rotation;
            player.Weapon = player.CurWeaponObj.GetComponent<Weapon>();
            player.ShootPosition = player.Weapon.ShootPosition;
            player.GetComponent<UpgradeManager>().EnableAll();
            SetRandomWeapon();
        }

    }

}
