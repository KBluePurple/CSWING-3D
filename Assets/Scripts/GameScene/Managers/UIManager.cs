using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace GameScene
{
    public class UIManager : MonoSingleton<UIManager>
    {
        [Header("PlayerUI")]
        [SerializeField]
        public Image Shield;
        [SerializeField]
        public Image Hp;
        [SerializeField]
        public Image Energy;
        [SerializeField]
        public Image Speed;
        [SerializeField]
        public Image BackSpeed;

        [Header("PlayerAttackUI")]
        [SerializeField]
        public GameObject Boost;
        [SerializeField]
        public GameObject Weapon1;
        [SerializeField]
        public GameObject Weapon2;
        [SerializeField]
        public GameObject Skill1;
        [SerializeField]
        public GameObject Skill2;

        [Header("PauseUI")]
        [SerializeField]
        private TextMeshProUGUI shieldText;
        [SerializeField]
        private TextMeshProUGUI hpText;
        [SerializeField]
        private TextMeshProUGUI energyText;
        [SerializeField]
        private TextMeshProUGUI speedText;
        [SerializeField]
        private TextMeshProUGUI weaponText;
        [SerializeField]
        private TextMeshProUGUI coreText;

        [SerializeField]
        private Image displaySafeZone;
        [SerializeField]
        private GameObject gameOverPanel;
        [SerializeField] TextMeshProUGUI _warningCountDownText = null;

        private PlayerMove playerMove;
        private GameManager gameManager;

        private void Start()
        {
            SafeZoneManager.Instance.OnSafeZoneCountDown += OnSafeZoneCounterUpdate;
            playerMove = FindObjectOfType<PlayerMove>();
            gameManager = FindObjectOfType<GameManager>();
        }

        private void Update()
        {
            Speed.fillAmount = playerMove._speed / playerMove.MaxSpeed;
            BackSpeed.fillAmount = -playerMove._speed / playerMove.MaxSpeed;

            if (gameManager.isActivePausePanel)
            {
                ShowPlayerStat();
            }

            DisplaySafeZone();
        }

        void DisplaySafeZone()
        {
            if (playerMove.transform.position.x >= Mathf.Abs(400f))
            {
                Color color = displaySafeZone.color;
                color.a = (Mathf.Abs(playerMove.transform.position.x) - 400f)/10f;
                displaySafeZone.color = color;
            }
            if (playerMove.transform.position.y >= Mathf.Abs(400f))
            {
                Color color = displaySafeZone.color;
                color.a = (Mathf.Abs(playerMove.transform.position.y) - 400f) / 10f;
                displaySafeZone.color = color;
            }
            if (playerMove.transform.position.z >= Mathf.Abs(400f))
            {
                Color color = displaySafeZone.color;
                color.a = (Mathf.Abs(playerMove.transform.position.z) - 400f) / 10f;
                displaySafeZone.color = color;
            }

            if( (playerMove.transform.position.x <= Mathf.Abs(400f) && playerMove.transform.position.y <= Mathf.Abs(400f) && playerMove.transform.position.z <= Mathf.Abs(400f)))
            {
                Color color = displaySafeZone.color;
                color.a = 0;
                displaySafeZone.color = color;
            }
        }

        public void OnSafeZoneCounterUpdate(int count)
        {
            if (count == 0)
            {
                _warningCountDownText.text = "";
                return;
            }
            _warningCountDownText.text = count.ToString();
        }

        public void Dead()
        {
            gameOverPanel.SetActive(true);
            MouseManager.Show(true);
            MouseManager.Lock(false);
        }

        public void ShowPlayerStat()
        {
            shieldText.text = "PlayerSheild : " + PlayerManager.Instance.Stat.Shield.ToString();
            hpText.text = "PlayerHp : " + PlayerManager.Instance.Stat.Hp.ToString();
            energyText.text = "PlayerEnergy : " + PlayerManager.Instance.Stat.Energy.ToString();
            speedText.text = $"Player Speed : {playerMove._speed:F1}km/s";
            weaponText.text = "Player Weapon :\n" + SaveManager.Instance.Parts.Weapon.ToString();
            coreText.text = "Player Core :\n" + SaveManager.Instance.Parts.Core.ToString();
        }
    }
}