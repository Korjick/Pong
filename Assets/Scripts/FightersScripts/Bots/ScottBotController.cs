using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using FightersScripts;
using FightersScripts.Abilities;
using UnityEditor;
using UnityEngine;

public class ScottBotController : NormalBotController
{
    [SerializeField] private Vector2 rangeForRandomAbilityUse = new Vector2(3f, 5f);
    private float timerMaxTime, time;
    private float power = 1000f;
    private Ball ball;

    public override void Init(bool isLeftPlayer,
        AnimatorOverrideController animatorController,
        ContainerForAbilities cfa, SkillContainer container)
    {
        base.Init(isLeftPlayer, animatorController, cfa, container);
        ball = cfa.Ball;
    }

    protected override void Update()
    {
        base.Update();

        if (canUseAbility)
        {
            time += Time.deltaTime;
            if (time >= timerMaxTime)
            {
                time = 0;
                UseAbility();
                timerMaxTime = Random.Range(rangeForRandomAbilityUse.x, rangeForRandomAbilityUse.y);
            }
        }
        else time = 0f;
    }

    protected override void UseAbility()
    {
        ball.Rigidbody.velocity = (isLeftPlayer ? Vector2.right : Vector2.left) * power;
    }
}