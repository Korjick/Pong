using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using FightersScripts;
using UnityEditor;
using UnityEngine;

public class RoksiRihterBotController : NormalBotController
{
    [SerializeField] private Vector2 rangeForRandomAbilityUse = new Vector2(3f, 5f);
    private float timerMaxTime, time;
    private float disablingTime = 0.3f;
    private Ball ball;

    public override void Init(bool isLeftPlayer,
        AnimatorOverrideController animatorController,
        ContainerForAbilities cfa, SkillContainer container)
    {
        base.Init(isLeftPlayer, animatorController, cfa, container);
        ball = cfa.Ball;

        timerMaxTime = Random.Range(rangeForRandomAbilityUse.x, rangeForRandomAbilityUse.y);
    }

    protected override void Update()
    {
        base.Update();

        if (canUseAbility)
        {
            time += Time.deltaTime;
            if (time >= timerMaxTime)
            {
                time = 0f;
                UseAbility();
                timerMaxTime = Random.Range(rangeForRandomAbilityUse.x, rangeForRandomAbilityUse.y);
            }
        }
        else time = 0f;
    }

    protected override void UseAbility()
    {
        StartCoroutine(DisableBall());
    }

    private IEnumerator DisableBall()
    {
        ball.Image.enabled = false;
        yield return new WaitForSeconds(disablingTime);
        ball.Image.enabled = true;
    }
}