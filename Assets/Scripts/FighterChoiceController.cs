using System;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FighterChoiceController : MonoBehaviour
{
    [SerializeField] private FighterButton fighterButtonPrefab;
    [SerializeField] private FighterSO[] fighterSOs;
    [SerializeField] private FighterSO[] botFighterSOs;
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
        if (isMultiplayer)
            if (!isSecondPlayerChoice)
                isSecondPlayerChoice = true;
            else
                SceneManager.LoadSceneAsync(GameSceneName);
        else
        {
            FighterSO selectedBot = botFighterSOs[Random.Range(0, botFighterSOs.Length)];

            PlayerData.secondPlayerChosenFighterSO = selectedBot;

            SceneManager.LoadSceneAsync(GameSceneName);
        }
    }

    private void FighterButton_OnButtonSelected(FighterSO fighterSO)
    {
        if (isSecondPlayerChoice)
        {
            PlayerData.secondPlayerChosenFighterSO = fighterSO;
            secondPlayerPreview.sprite = fighterSO.preview;
        }
        else
        {
            PlayerData.chosenFighterSO = fighterSO;
            preview.sprite = fighterSO.preview;
        }
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