using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private int maxScore = 3;
    [SerializeField] private BordersController bordersController;
    [SerializeField] private Transform leftSpawnPoint, rightSpawnPoint;
    [SerializeField] private Text score;
    public int LeftScore { get; private set; }
    public int RightScore { get; private set; }

    private void Start()
    {
        bordersController.OnGoal += BordersController_OnGoal;
        score.text = "Game up to " + maxScore + " points\n" + LeftScore + " : " + RightScore;

        FighterSO firstFSO = PlayerData.chosenFighterSO;
        FighterSO secondFSO = PlayerData.secondPlayerChosenFighterSO;

        CharacterController firstCharacter =
            Instantiate(firstFSO.battlePrefab, leftSpawnPoint);
        firstCharacter.Init(true, firstFSO.animator);

        CharacterController secondCharacter =
            Instantiate(secondFSO.battlePrefab, rightSpawnPoint);
        secondCharacter.Init(false, secondFSO.animator);
    }

    private void BordersController_OnGoal(bool isLeftPlayer)
    {
        if (isLeftPlayer)
        {
            RightScore++;
            if (RightScore >= maxScore)
                return; // TODO game over
        }
        else
        {
            LeftScore++;
            if (LeftScore >= maxScore)
                return; // TODO game over
        }

        score.text = "Game up to " + maxScore + " points\n" + LeftScore + " : " + RightScore;
        //TODO restart ball
    }
}