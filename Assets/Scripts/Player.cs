using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore.MemorySystem;

public class Player : Character2D
{
    GameData gd;

    private void Start()
    {
        gd = MemorySystem.Load;
        transform.position = gd.PlayerPosition;
    }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MemorySystem.Save(new GameData(transform.position.x, transform.position.y));
    }
}
