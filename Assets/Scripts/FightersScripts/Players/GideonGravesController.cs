using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using FightersScripts.Abilities;
using UnityEngine;

public class GideonGravesController : PlayerController
{
    [SerializeField] private GameObject changeRealityPrefab;
    private GameObject changeReal;
    private float duration = 3f;

    public override void Init(bool isLeftPlayer,
        AnimatorOverrideController animatorController,
        ContainerForAbilities cfa, SkillContainer container)
    {
        base.Init(isLeftPlayer, animatorController, cfa, container);

        changeReal = Instantiate(changeRealityPrefab, cfa.Background.transform);
        changeReal.SetActive(false);
    }

    protected override void UseAbility()
    {
        StartCoroutine(ChangeReality());
    }

    private IEnumerator ChangeReality()
    {
        changeReal.SetActive(true);
        yield return new WaitForSeconds(duration);
        changeReal.SetActive(false);
    }
}