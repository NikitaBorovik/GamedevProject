using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDataSO", menuName = "Scriptable Objects/Weapons/ Weapon Data")]
public class WeaponSO : ScriptableObject
{
    public float damage;
    public float coolDown;
    public float bulletFlySpeed;
    public GameObject bullet;
}
