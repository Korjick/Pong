using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : CharacterController
{
    private Vector2 botMove = Vector2.up;

    protected override void Movement()
    {
        base.Movement();
        if (rigidbody.velocity.magnitude < 0.01)
            botMove *= -1;
        rigidbody.velocity = botMove * force;
    }
}