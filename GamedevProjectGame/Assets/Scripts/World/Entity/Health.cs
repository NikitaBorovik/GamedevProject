using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.Entity
{
    public class Health : MonoBehaviour
    {
        private float currentHealth;

        [SerializeField]
        private float maxHealth;

        public void Awake()
        {
            currentHealth = maxHealth;
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
            if(currentHealth > maxHealth)
                currentHealth = maxHealth;
        }

        public void HealToMax()
        {
            currentHealth = maxHealth;
        }

        public void ChangeMaxHealth(float amount)
        {
            maxHealth += amount;
        }
    }
}

