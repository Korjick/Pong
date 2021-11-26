using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HistoryFightStarter : MonoBehaviour
{
    [SerializeField] private FighterSO playerFighterSO;
    [SerializeField] private FighterSO enemyFighterSO;

    public void StartBattle()
    {
        PlayerData.chosenFighterSO = playerFighterSO;
        PlayerData.secondPlayerChosenFighterSO = enemyFighterSO;

        SceneManager.LoadSceneAsync("GameScene");
    }
}