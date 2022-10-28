using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField]
    private Transform shootPosition;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float coolDown;
    private float timeFromCoolDown;
    // Start is called before the first frame update
    public void Shoot(Vector2 vel)
    {
        if (timeFromCoolDown > coolDown) 
        { 
            GameObject bullet = Instantiate(bulletPrefab, shootPosition.position, shootPosition.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            timeFromCoolDown = 0.0f;
        }
        
    }
    void Start()
    {
        timeFromCoolDown = coolDown;
        Shoot(Vector2.zero);// TODO delete this 
    }

    // Update is called once per frame
    void Update()
    {
        Shoot(Vector2.zero);// TODO delete this 
        timeFromCoolDown += Time.deltaTime;
    }
}
