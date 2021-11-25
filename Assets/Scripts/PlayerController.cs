using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScottController : PlayerController
{
    
}

public class PlayerController : CharacterController
{
    private KeyCode _up, _down, _specialPower;
    private void Start() => SetKeycodes();

    private void SetKeycodes()
    {
        if (IsLeftPlayer)
        {
            _up = KeyCode.W;
            _down = KeyCode.S;
            _specialPower = KeyCode.X;
        }
        else
        {
            _up = KeyCode.UpArrow;
            _down = KeyCode.DownArrow;
            _specialPower = KeyCode.KeypadEnter;
        }
    }

    protected override void Movement()
    {
        base.Movement();
        _rigidbody.velocity = Vector2.zero;

        Vector2 move = Vector2.zero;
        if (Input.GetKey(_up))
            move += Vector2.up;
        if (Input.GetKey(_down))
            move += Vector2.down;
        if (move.magnitude > 0.001f)
            _rigidbody.velocity = move * force;

        if (Input.GetKey(_specialPower))
        {
            Debug.Log("Ryu use Ability");
            animator.SetTrigger("Ability");
        }
    }
}