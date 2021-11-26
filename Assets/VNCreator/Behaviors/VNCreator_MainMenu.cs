using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace VNCreator
{
    public class VNCreator_MainMenu : MonoBehaviour
    {
        [Header("Buttons")]
        public Button newGameBtn;
        public Button continueBtn;
        public Button optionsMenuBtn;
        public Button quitBtn;

        [Header("")]
        private string playScene;

        [Header("Menu Objects")]
        public GameObject optionsMenu;
        public GameObject mainMenu;

        void Start()
        {
            if(newGameBtn != null)
                newGameBtn.onClick.AddListener(NewGame);
            if(optionsMenuBtn != null)
                optionsMenuBtn.onClick.AddListener(DisplayOptionsMenu);
            if(quitBtn != null)
                quitBtn.onClick.AddListener(Quit);
            if (continueBtn != null)
            {
                if (PlayerPrefs.HasKey("MainGame"))
                    continueBtn.onClick.AddListener(LoadGame);
                else
                    continueBtn.interactable = false;
            }
        }

        void NewGame()
        {
            PlayerPrefs.SetString("LastScene", "Winter");
            playScene = PlayerPrefs.GetString("LastScene", "Winter");
            GameSaveManager.NewLoad("MainGame");
            SceneManager.LoadScene(playScene, LoadSceneMode.Single);
        }

        void LoadGame()
        {
            playScene = PlayerPrefs.GetString("LastScene", "Winter");
            GameSaveManager.currentLoadName = "MainGame";
            SceneManager.LoadScene(playScene, LoadSceneMode.Single);
        }

        void DisplayOptionsMenu()
        {
            optionsMenu.SetActive(true);
            mainMenu.SetActive(false);
        }

        void Quit()
        {
            Application.Quit();
        }
    }
}
