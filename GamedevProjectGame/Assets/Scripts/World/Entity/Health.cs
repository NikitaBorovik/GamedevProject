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
                healthUpdateEvent?.CallHPUpdateEvent(value, value - currentHealth, MaxHealth);
                currentHealth = value;
            }
        }
        public float MaxHealth { get; set; }

        public void Awake()
        {
            CurrentHealth = MaxHealth;
        }

        public void TakeDamage(float damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
            {
                IKillable baseScript = GetComponent<IKillable>();
                baseScript.Die();
            }
        }

        public void Heal(float amount)
        {
            CurrentHealth += amount;
            if(CurrentHealth > MaxHealth)
                CurrentHealth = MaxHealth;
        }

        public void HealToMax()
        {
            CurrentHealth = MaxHealth;
        }

        public void ChangeMaxHealth(float amount)
        {
            MaxHealth += amount;
        }
    }
}

