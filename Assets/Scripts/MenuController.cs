using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    //TODO it doesn't work
    // public void DisableSound(Image on, Image off)
    // {
    //     PlayerData.isSoundDisabled = !PlayerData.isSoundDisabled;
    //     on.enabled = !PlayerData.isSoundDisabled;
    //     off.enabled = PlayerData.isSoundDisabled;
    // }
    
    //TODO it doesn't work
    // public void DisableMusic(Image on, Image off)
    // {
    //     PlayerData.isMusicDisabled = !PlayerData.isMusicDisabled;
    //     on.enabled = !PlayerData.isMusicDisabled;
    //     off.enabled = PlayerData.isMusicDisabled;
    // }
}