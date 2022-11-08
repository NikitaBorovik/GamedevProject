using System.Collections.Generic;
using App.Upgrades;
using App.World;
using App.World.Entity.Player.PlayerComponents;
using UnityEngine;
using Random = UnityEngine.Random;

namespace World.Shop
{
    public class ShopItem : MonoBehaviour
    {
        [SerializeField]
        private ObjectsContainer container;

        [SerializeField] 
        private List<BaseUpgrade> upgrades;

        private BaseUpgrade currentUpgrade;

        private Player player;

        // TODO remove
        private int price;

        private void SetRandomUpgrade()
        {
            currentUpgrade = upgrades[Random.Range(0, upgrades.Count)];
        }

        private void Awake()
        {
            player = container.Player.GetComponent<Player>();
            SetRandomUpgrade();
        }

        private void OnTriggerEnter(Collider other)
        {
       
        }

        private void OnTriggerExit(Collider other)
        {
        
        }

        public void TryBuy() // on click && overlap
        {
            if (player.Money >= price)
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
            player.Money -= price;
            player.GetComponent<UpgradeManager>().AddUpgrade(currentUpgrade);
            SetRandomUpgrade();
        }
    }
}
