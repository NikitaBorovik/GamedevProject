using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.Entity.Enemy
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/Enemies/ Enemy Data")]
    public class EnemyData : ScriptableObject
    {
        public string type;
        public int dangerLevel;
        public float speed;
        public float damage;
        public float timeBetweenAttacks;
        public float moneyDropChance;
        public float attackRange;
        public float spawnAnimationDuration;
        public int minMoneyDrop;
        public int maxMoneyDrop;
    }
}

