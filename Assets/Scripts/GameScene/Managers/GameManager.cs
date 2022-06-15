using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameScene
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject pausePanel = null;
        [SerializeField]
        private GameObject resumeButton = null;
        [SerializeField]
        private GameObject settingButton = null;
        [SerializeField]
        private GameObject backToMainMenuButton = null;

        private bool isActivePausePanel = false;


        void Start()
        {
            MouseManager.Show(false);
            MouseManager.Lock(true);
            SoundManager.Instance.PlaySound("StreetLove", SoundType.BGM);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePausePanel();
            }
        }

        void TogglePausePanel()
        {
            MouseManager.Show(true);
            MouseManager.Lock(false);
            pausePanel.SetActive(!pausePanel.activeSelf);
            Time.timeScale = pausePanel.activeSelf ? 0 : 1;
        }

        public void Resume()
        {
            TogglePausePanel();
        }

        public void Setting()
        {
            Debug.Log("¼¼ÆÃ");
        }

        public void BackToMainMenu()
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}