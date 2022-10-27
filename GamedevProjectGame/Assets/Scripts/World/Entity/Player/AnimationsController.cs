using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetIdleAnimationParams(Animator animator)
    {
        animator.SetBool("isIdle",true);
        animator.SetBool("isMoving", false);
    }
    public void SetAimAnimationParams(Animator animator,float playerPos, float cursorPos)
    {
        if (cursorPos >= playerPos)
        {
            animator.SetBool("aimRight",true);
            animator.SetBool("aimLeft", false);
        }
        else
        {
            animator.SetBool("aimRight", false);
            animator.SetBool("aimLeft", true);
        }
        Debug.Log(cursorPos + "   " + Screen.width / 2);
    }
    public void SetMovementAnimationParams(Animator animator)
    {
        animator.SetBool("isIdle", false);
        animator.SetBool("isMoving", true);
    }
}
