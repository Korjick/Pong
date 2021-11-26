using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using FightersScripts.Abilities;
using UnityEngine;

public class ScottController : PlayerController
{
    private float power = 1000f;
    private Ball ball;

    public override void Init(bool isLeftPlayer,
        AnimatorOverrideController animatorController,
        ContainerForAbilities cfa, SkillContainer container)
    {
        base.Init(isLeftPlayer, animatorController, cfa, container);
        ball = cfa.Ball;
    }

    protected override void UseAbility()
    {
        ball.Rigidbody.velocity = (isLeftPlayer ? Vector2.right : Vector2.left) * power;
    }
}