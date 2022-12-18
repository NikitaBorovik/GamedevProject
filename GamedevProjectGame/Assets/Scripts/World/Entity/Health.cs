using UnityEngine;
using App.World.Entity.Player.Events;

namespace World.Entity
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private float currentHealth;
        [SerializeField]
        private float maxHealth;
        [SerializeField]
        private HPUpdateEvent healthUpdateEvent;

        public float CurrentHealth 
        {
            get => currentHealth;
            private set
            {
                healthUpdateEvent.CallHPUpdateEvent(value, value - currentHealth);
                currentHealth = value;
            }
        }
        public float MaxHealth { get => maxHealth; set => maxHealth = value; }

        public void Awake()
        {
            currentHealth = MaxHealth;
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                IKillable baseScript = GetComponent<IKillable>();
                baseScript.Die();
            }
        }

        public void Heal(float amount)
        {
            currentHealth += amount;
            if(currentHealth > MaxHealth)
                currentHealth = MaxHealth;
        }

        public void HealToMax()
        {
            currentHealth = MaxHealth;
        }

        public void ChangeMaxHealth(float amount)
        {
            MaxHealth += amount;
        }
    }
}

