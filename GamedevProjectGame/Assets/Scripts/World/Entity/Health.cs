using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.Entity
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private float currentHealth;
        [SerializeField]
        private float maxHealth;
        [SerializeField]
        private float blinkTime;
        private Color32 blinkColor = new Color32(215,110,110,255);
        private Dictionary<SpriteRenderer,Color> spriteRenderers;
        private List<SpriteRenderer> toDelete;
        private Coroutine blinkRoutine;

        public float CurrentHealth => currentHealth;
        public float MaxHealth { get => maxHealth; set => maxHealth = value; }

        public void Awake()
        {
            currentHealth = MaxHealth;
            spriteRenderers = new Dictionary<SpriteRenderer, Color>();
            toDelete = new List<SpriteRenderer>();
            foreach (SpriteRenderer spriteRenderer in GetComponentsInChildren<SpriteRenderer>())
            {
                spriteRenderers.Add(spriteRenderer, spriteRenderer.color);
            }
           
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            Blink();
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

        private IEnumerator BlinkCoroutine()
        {
            if (spriteRenderers == null)
                yield break;
            foreach (SpriteRenderer spriteRenderer in spriteRenderers.Keys)
            {
                if (spriteRenderer != null)
                    spriteRenderer.color = blinkColor;
                else
                    toDelete.Add(spriteRenderer);
            }
            yield return new WaitForSeconds(blinkTime);
            foreach (SpriteRenderer spriteRenderer in spriteRenderers.Keys)
            {
                if (spriteRenderer != null)
                    spriteRenderer.color = spriteRenderers[spriteRenderer];
            }
            blinkRoutine = null;
        }
        private void Blink()
        {
            if (blinkRoutine != null)
            {
                StopCoroutine(blinkRoutine);
            }
            foreach (SpriteRenderer spriteRenderer in toDelete)
            {
                spriteRenderers.Remove(spriteRenderer);
            }
            toDelete.Clear();
            blinkRoutine = StartCoroutine(BlinkCoroutine());
        }
    }
}

