using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static event Action OnRoundFinished;
    public static event Action OnRoundStarted;

    [Header("Main")] [SerializeField] private int maxScore = 3;
    [SerializeField] private int waitTime = 3;
    [SerializeField] private BordersController bordersController;
    [SerializeField] private Transform leftSpawnPoint, rightSpawnPoint;

    [Header("Game Elements")] [SerializeField]
    private Ball _ball;

    [SerializeField] private ContainerForAbilities _cfa;
    [SerializeField] private SkillContainer leftSkillContainer, rightSkillContainer;
    private CharacterController _firstCharacter, _secondCharacter;

    [Header("UI")] [SerializeField] private Text score;
    [SerializeField] private ResultScreen resultScreen;

    public int LeftScore { get; private set; }
    public int RightScore { get; private set; }

    private void OnEnable()
        => bordersController.OnGoal += BordersController_OnGoal;

    private void OnDisable()
        => bordersController.OnGoal -= BordersController_OnGoal;

    private void Awake()
    {
        FighterSO firstFso = PlayerData.chosenFighterSO;
        FighterSO secondFso = PlayerData.secondPlayerChosenFighterSO;

        _firstCharacter = Instantiate(firstFso.battlePrefab, leftSpawnPoint);
        _firstCharacter.Init(true, firstFso.animator, _cfa, leftSkillContainer);
        _firstCharacter.OnChangeScore += delta => ChangeScore(false, delta);

        _secondCharacter = Instantiate(secondFso.battlePrefab, rightSpawnPoint);
        _secondCharacter.Init(false, secondFso.animator, _cfa, rightSkillContainer);
        _secondCharacter.OnChangeScore += delta => ChangeScore(true, delta);
    }

    private void Start()
    {
        StartCoroutine(ResetScene());
    }

    private IEnumerator ResetScene()
    {
        OnRoundFinished?.Invoke();
        _firstCharacter.transform.localPosition = Vector3.zero;
        _secondCharacter.transform.localPosition = Vector3.zero;
        _ball.transform.localPosition = Vector2.zero;
        _ball.Rigidbody.velocity = Vector2.zero;

        for (var i = waitTime; i > 0; i--)
        {
            score.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        score.text = "Game up to " + maxScore + " points\n" + LeftScore + " : " + RightScore;
        _ball.RandomForce();
        OnRoundStarted?.Invoke();
    }

    private void BordersController_OnGoal(bool isLeftPlayer)
    {
        if (!ChangeScore(isLeftPlayer, 1))
            return;
        StartCoroutine(ResetScene());
    }

    private bool ChangeScore(bool isLeftPlayer, int delta)
    {
        if (isLeftPlayer)
        {
            RightScore += delta;
            if (RightScore >= maxScore)
            {
                resultScreen.Enable();
                return false;
            }

            if (RightScore < 0) RightScore = 0;
        }
        else
        {
            LeftScore += delta;
            if (LeftScore >= maxScore)
            {
                resultScreen.Enable();
                return false;
            }

            if (LeftScore < 0) LeftScore = 0;
        }

        score.text = "Game up to " + maxScore + " points\n" + LeftScore + " : " + RightScore;
        return true;
    }
}