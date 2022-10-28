using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IShootable
{
    [SerializeField]
    private float baseDamage;
    [SerializeField]
    private float speed;
    [SerializeField]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
