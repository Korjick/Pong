using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private bool isPlayer1;
    [SerializeField] private float force = .1f;

    private KeyCode _up, _down, _specialPower;

    private void Awake() => SetKeycodes();

    private void Update() => Movement();

    private void SetKeycodes()
    {
        if (isPlayer1)
        {
            _up = KeyCode.W;
            _down = KeyCode.S;
            _specialPower = KeyCode.E;
        }
        else
        {
            _up = KeyCode.UpArrow;
            _down = KeyCode.DownArrow;
            _specialPower = KeyCode.KeypadEnter;
        }
    }
    
    private void Movement()
    {
        if (Input.GetKey(_up))
            rigidbody.position += Vector2.up * force;
        if(Input.GetKey(_down))
            rigidbody.position += Vector2.down * force;
    }
}
