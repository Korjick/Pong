using System;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FighterChoiceController : MonoBehaviour
{
    [SerializeField] private FighterButton fighterButtonPrefab;
    [SerializeField] private FighterSO[] fighterSOs;
    [SerializeField] private Transform fighterButtonsContainer;
    [SerializeField] private bool isMultiplayer;
    [SerializeField] private Image preview;
    [SerializeField] private Image secondPlayerPreview;
    [SerializeField] private Button startButton;
    [SerializeField] private string GameSceneName;
    private List<FighterButton> fighterButtonsList = new List<FighterButton>();
    private bool isSecondPlayerChoice;

    private void Start()
    {
        startButton.onClick.AddListener(StartButton_OnClick);
        foreach (FighterSO fighterSO in fighterSOs)
        {
            FighterButton fighterButton = Instantiate(fighterButtonPrefab, fighterButtonsContainer);
            fighterButton.SetSO(fighterSO);
            fighterButton.OnButtonSelected += FighterButton_OnButtonSelected;
            fighterButtonsList.Add(fighterButton);
        }
    }

    private void StartButton_OnClick()
    {
        if (isMultiplayer && !isSecondPlayerChoice)
        {
            isSecondPlayerChoice = true;
            return;
        }

        SceneManager.LoadSceneAsync(GameSceneName);
    }

    private void FighterButton_OnButtonSelected(FighterSO fighterSO)
    {
        if (isSecondPlayerChoice)
            PlayerData.secondPlayerChosenFighterSO = fighterSO;
        else
            PlayerData.chosenFighterSO = fighterSO;
    }

    private void OnDestroy()
    {
        startButton.onClick.RemoveListener(StartButton_OnClick);
        foreach (FighterButton fighterButton in fighterButtonsList)
        {
            fighterButton.OnButtonSelected -= FighterButton_OnButtonSelected;
        }
    }
}