using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.Entity
{
    public class Health : MonoBehaviour
    {
        private float currentHealth;

        private float maxHealth;

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

