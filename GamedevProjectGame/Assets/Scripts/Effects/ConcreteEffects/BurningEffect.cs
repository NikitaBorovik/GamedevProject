using UnityEngine;
using World.Entity;
using World.Entity.Enemy;

namespace App.Effects.ConcreteEffects
{
    [CreateAssetMenu(fileName = "BurningEffect", menuName = "Scriptable Objects/Effects/BurningEffect")]
    public class BurningEffect : BaseStatusEffect
    {
        [SerializeField] private float burningPeriod;
        [SerializeField] private float burningDamage;
        private float timeCounter;

        public override bool IsStackable => true;

        public override void EnableEffect(BaseEnemy holder) => timeCounter = 0f;

        public override void DisableEffect(BaseEnemy holder) => timeCounter = 0f;

        public override void UpdateEffect(BaseEnemy holder)
        {
            if(timeCounter >= burningPeriod)
            {
                var health = holder.GetComponent<Health>();
                health.TakeDamage(burningDamage);
                timeCounter = 0f;
            }
            else
            {
                timeCounter += Time.fixedDeltaTime;
            }
        }
    }
}
