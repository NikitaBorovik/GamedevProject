using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.Entity;

public class DamagePlayer : MonoBehaviour
{
    private float damage;
    public void Init(float damage)
    {
        this.damage = damage;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Health collisionHealth = collision.GetComponent<Health>();
        if (collisionHealth != null)
        {
            collisionHealth.TakeDamage(damage);
            Debug.Log("Player hit");
        }  
        else
            Debug.Log("Error: Trying to damage target without Health component");
    }
}
