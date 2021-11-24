using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }

    public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private readonly string[] Scenes = { "PlotScene", "ArenaScene", "MultiplayerScene" };

    public enum E_Scenes
    {
        Plot = 0,
        Arena = 1,
        Multiplayer = 2,
    }
}