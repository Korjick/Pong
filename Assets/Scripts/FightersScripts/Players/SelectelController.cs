using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using FightersScripts.Abilities;
using UnityEngine;

public class SelectelController : PlayerController
{
    [SerializeField] private Rigidbody2D fakeBallPrefab;
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
        Vector3 pos = ball.transform.position;
        Transform parent = transform.parent;
        Instantiate(fakeBallPrefab, pos, Quaternion.identity, parent)
            .velocity = new Vector2(-1, -1) * power;
        Instantiate(fakeBallPrefab, pos, Quaternion.identity, parent)
            .velocity = new Vector2(1, -1) * power;
        Instantiate(fakeBallPrefab, pos, Quaternion.identity, parent)
            .velocity = new Vector2(-1, 1) * power;
        Instantiate(fakeBallPrefab, pos, Quaternion.identity, parent)
            .velocity = new Vector2(1, 1) * power;
    }
}