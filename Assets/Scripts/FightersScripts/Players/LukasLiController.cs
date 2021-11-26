using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using FightersScripts.Abilities;
using UnityEngine;

public class LukasLiController : PlayerController
{
    [SerializeField] private Transform wall_1, wall_2, wall_3;
    [SerializeField] private LiWall wallPrefab;

    public override void Init(bool isLeftPlayer,
        AnimatorOverrideController animatorController,
        ContainerForAbilities cfa, SkillContainer container)
    {
        base.Init(isLeftPlayer, animatorController, cfa, container);

        Instantiate(wallPrefab, wall_1.position, Quaternion.identity, transform.parent);
        Instantiate(wallPrefab, wall_2.position, Quaternion.identity, transform.parent);
        Instantiate(wallPrefab, wall_3.position, Quaternion.identity, transform.parent);
    }
}