using UnityEngine;
using App.World.Entity.Player.Events;

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

