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

        private PlayerMove playerMove = null;

        void Start()
        {
            MouseManager.Show(false);
            MouseManager.Lock(true);
            SoundManager.Instance.PlaySound("StreetLove", SoundType.BGM);
            playerMove = FindObjectOfType<PlayerMove>();
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
            playerMove.isTimeStop = !playerMove.isTimeStop;
            Time.timeScale = pausePanel.activeSelf ? 0 : 1;
        }

        public void Resume()
        {
            TogglePausePanel();
            MouseManager.Show(false);
            MouseManager.Lock(true);
        }

        public void Setting()
        {
            Debug.Log("����");
        }

        public void BackToMainMenu()
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}