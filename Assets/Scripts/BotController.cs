using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : CharacterController
{
    private Vector2 botMove = Vector2.up;

    protected override void Movement()
    {
        isMoving = false;
        if (_rigidbody.velocity.magnitude < 0.01)
            botMove *= -1;
        else isMoving = true;
        _rigidbody.velocity = botMove * force;
        
        base.Movement();
    }
}