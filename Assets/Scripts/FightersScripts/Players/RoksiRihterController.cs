using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class RoksiRihterController : PlayerController
{
    private float disablingTime = 0.3f;
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
        StartCoroutine(DisableBall());
    }

    private IEnumerator DisableBall()
    {
        ball.Image.enabled = false;
        yield return new WaitForSeconds(disablingTime);
        ball.Image.enabled = true;
    }
}