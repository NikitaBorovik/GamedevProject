using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.Entity.Enemy;

//FOR TESTING ONLY
//Used to initialise one enemy (without the use of enemy spawning system)

public class EnemyIniter : MonoBehaviour
{
    [SerializeField]
    private BaseEnemy enemy;
    [SerializeField]
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        enemy.Init(target.position,target);
    }
}
