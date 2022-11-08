using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDropItem : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Drop();
    }
    public void Drop()
    {
        float xDirection = Random.Range(-1f, 1f);
        float yDirection = Random.Range(-1f, 1f);
        float speed = Random.Range(10f,30f);
        Vector2 dropDirection = new Vector2(xDirection, yDirection).normalized;
        rigidBody.velocity = new Vector3(dropDirection.x * speed, dropDirection.y * speed, 0f);   
        
    }
}
