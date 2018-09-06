using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character2D
{
    protected override void Jump()
    {
        base.Jump();
        anim.SetBool("Grounding", grounding);

        if (jumping)
        {
            anim.SetTrigger("Jumping");
        }
    }

    protected override void Move2D()
    {
        base.Move2D();
        anim.SetFloat("InputX", Mathf.Abs(ComponentX));
    }
}
