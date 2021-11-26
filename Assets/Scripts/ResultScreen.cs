using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultScreen : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private Text score;

    public void Enable()
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);
        score.text = "SCORE: " + gameController.LeftScore + " : " + gameController.RightScore;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }
}