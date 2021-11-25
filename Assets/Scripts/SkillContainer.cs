using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillContainer : MonoBehaviour
{
    [SerializeField] private GameObject key;
    [SerializeField] private Transform progress;
    [SerializeField] private bool isLeft = true;

    private int progressCellIndex, maxProgressCellIndex;
    private bool isAbilityCharged;

    private void OnEnable()
    {
        PlayerController.BallKicked += OnBallKicked;
        progressCellIndex = 0;
        maxProgressCellIndex = progress.childCount - 1;
    }

    private void OnBallKicked(bool b)
    {
        if (isLeft == b)
            ChargeAbility();
    }

    private void ChargeAbility()
    {
        ChangeProgress();
        isAbilityCharged = progressCellIndex >= maxProgressCellIndex;
    }

    private void DischargeAbility()
    {
        if (!isAbilityCharged)
            return;

        ClearProgress();
        isAbilityCharged = false;
    }

    private void ChangeProgress()
    {
        if (progressCellIndex < 0)
            progressCellIndex = 0;
        if (progressCellIndex >= maxProgressCellIndex)
            return;

        progress.GetChild(progressCellIndex).gameObject.SetActive(true);

        progressCellIndex++;

        if (progressCellIndex >= maxProgressCellIndex)
            key.SetActive(true);
    }

    private void ClearProgress()
    {
        key.SetActive(false);
        for (int i = 0; i <= maxProgressCellIndex; i++)
            progress.GetChild(i).gameObject.SetActive(false);
    }
}