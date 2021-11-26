using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class ScottController : PlayerController
{
}

public class PlayerController : CharacterController
{
    public static event Action<bool> BallKicked;

    private KeyCode _up, _down, _specialPower;
    private bool canUseAbility;

    private void Start() => SetKeycodes();

    public override void Init(bool isLeftPlayer, AnimatorOverrideController animatorController,
        ContainerForAbilities cfa,
        SkillContainer skillContainer)
    {
        base.Init(isLeftPlayer, animatorController, cfa, skillContainer);

        GameController.OnRoundFinished += () => canUseAbility = false;
        GameController.OnRoundStarted += () => canUseAbility = true;
    }

    private void SetKeycodes()
    {
        if (isLeftPlayer)
        {
            _up = KeyCode.W;
            _down = KeyCode.S;
            _specialPower = KeyCode.X;
        }
        else
        {
            _up = KeyCode.UpArrow;
            _down = KeyCode.DownArrow;
            _specialPower = KeyCode.RightArrow;
        }
    }

    protected override void Movement()
    {
        isMoving = false;
        _rigidbody.velocity = Vector2.zero;

        Vector2 move = Vector2.zero;
        if (Input.GetKey(_up))
            move += Vector2.up;
        if (Input.GetKey(_down))
            move += Vector2.down;
        if (move.magnitude > 0.001f)
        {
            isMoving = true;
            _rigidbody.velocity = move * force;
        }

        if (Input.GetKey(_specialPower))
        {
            if (!canUseAbility)
                return;

            if (skillContainer.DischargeAbility())
            {
                UseAbility();
                animator.SetTrigger("Ability");
            }
        }

        base.Movement();
    }

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Ball"))
        {
            animator.SetTrigger("Kick");
            BallKicked?.Invoke(isLeftPlayer);
        }
    }
}