﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore.PlayerController;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class Character2D : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float jumpForce;

    protected Animator anim;
    protected Rigidbody2D rb2D;
    protected SpriteRenderer sr;

    [SerializeField]
    protected float speedLimit;
    Vector2 clampVel;

    [SerializeField]
    GroundSystem groundSystem;

    protected RaycastHit2D grounding;
    protected bool jumping;

    [SerializeField]
    TouchJoystick tchJoystick;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        Move2D();
        Jump();
    }

    void Update()
    {
        Flip();
    }

    protected virtual void Move2D()
    {
        grounding = groundSystem.CheckGround(transform);

        rb2D.AddForce(grounding & ComponentX != 0f ? 
            (Vector2)Vector3.ProjectOnPlane(Vector2.right * ComponentX * moveSpeed, grounding.normal.normalized)
            :  Vector2.right  * moveSpeed * ComponentX, ForceMode2D.Impulse);

        clampVel = Vector2.ClampMagnitude(rb2D.velocity, speedLimit);

        rb2D.velocity = new Vector2(
            grounding & ComponentX != 0f ? clampVel.x :
            grounding & ComponentX == 0f ? 0f : 
            !grounding & ComponentX != 0f ? clampVel.x : 0f,
            rb2D.velocity.y
        );

        rb2D.velocity -= ComponentX == 0f ? grounding.normal : Vector2.zero;
        

    }

    protected virtual void Jump()
    {
        jumping = Btn_jump & grounding;
        rb2D.AddForce(Vector2.up  * (jumping ? jumpForce : 0), ForceMode2D.Impulse);
    }

    protected void Flip()
    {
        sr.flipX = ComponentX > 0f ? false : ComponentX < 0f ? true : sr.flipX;
    }

    //editor
    private void OnDrawGizmos()
    {
        groundSystem.DrawRay(transform);
        Gizmos.color = Color.red;
        Gizmos.DrawRay((Vector2)transform.position + groundSystem.StartPosition, grounding.normal * 2f);
        Gizmos.color = Color.cyan;
        if (ComponentX != 0f)
        {
            Gizmos.DrawRay((Vector2)transform.position + groundSystem.StartPosition, (Vector2)Vector3.ProjectOnPlane(rb2D.velocity.normalized, grounding.normal) * 2f);
        }
    }

    protected float ComponentX
    {
        get
        {
#if UNITY_STANDALONE
            return ControlSystem.Axis.x;
#elif UNITY_ANDROID
            return tchJoystick.Tch_axis.x;
#endif
        }
    }

    protected bool Btn_jump
    {
        get
        {
            return ControlSystem.Btn_jump;
        }
    }
}
