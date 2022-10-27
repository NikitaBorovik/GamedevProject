using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public void Move(Rigidbody2D body, Vector2 direction, float speed)
    {
        body.velocity = new Vector2(direction.x*speed,direction.y*speed);
    }
}
