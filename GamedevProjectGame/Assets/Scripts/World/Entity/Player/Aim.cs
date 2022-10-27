using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    
    public void AimWeaponWithMouse(Transform weaponAnchorTransform, float aimAngle,float playerPos,float cursorPos)
    {
        weaponAnchorTransform.eulerAngles = new Vector3(0f, 0f, aimAngle);
        if (cursorPos >= playerPos)
        {
            weaponAnchorTransform.localScale = new Vector3(1f, 1f, 0f);
        }
        else
        {
            weaponAnchorTransform.localScale = new Vector3(1f, -1f, 0f);
        }

    }



}
