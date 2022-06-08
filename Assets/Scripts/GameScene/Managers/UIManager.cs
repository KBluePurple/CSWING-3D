using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

        [SerializeField] Text _warningCountDownText = null;

        private PlayerMove playerMove;

        private void Start()
        {
            SafeZoneManager.Instance.OnSafeZoneCountDown += OnSafeZoneCounterUpdate;
            playerMove = FindObjectOfType<PlayerMove>();
        }

        private void Update()
        {
            Speed.fillAmount = playerMove._speed / 10;
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
    }
}