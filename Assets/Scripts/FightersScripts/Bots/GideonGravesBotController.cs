using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using FightersScripts;
using FightersScripts.Abilities;
using UnityEditor;
using UnityEngine;

public class GideonGravesBotController : NormalBotController
{
    [SerializeField] private Vector2 rangeForRandomAbilityUse = new Vector2(3f, 5f);
    private float timerMaxTime, time;
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

    protected override void Update()
    {
        base.Update();

        if (canUseAbility)
        {
            time += Time.deltaTime;
            if (time >= timerMaxTime)
            {
                time = -duration;
                UseAbility();
                timerMaxTime = Random.Range(rangeForRandomAbilityUse.x, rangeForRandomAbilityUse.y);
            }
        }
        else time = 0f;
    }

    protected override void UseAbility()
    {
        if (!canUseAbility)
            return;

        StartCoroutine(ChangeReality());
    }

    private IEnumerator ChangeReality()
    {
        changeReal.SetActive(true);
        yield return new WaitForSeconds(duration);
        changeReal.SetActive(false);
    }
}