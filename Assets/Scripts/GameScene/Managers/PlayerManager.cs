using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameScene
{
    public class PlayerManager : MonoSingleton<PlayerManager>
    {
        //����
        public PlayerStat Stat;
        //����1, ����2
        private GameObject playerWeapon1;
        private GameObject playerWeapon2;
        //Ư����ų1, Ư����ų2
        private GameObject playerSkill1;
        private GameObject playerSkill2;

        //��ü ȸ���ӵ�, ����
        private float rotationSpeed;
        //����? �� ����? ��?��?

        // ���� �ڵ����� ��Ÿ��
        private float shieldRecoveryDelay = 5f;
        private float curShieldRecoverydelay = 0f;
        private float delay = 0f;

        private UIManager uiManager;

        public Action<Enemy> OnEnemyAdded;
        public Action<Enemy> OnEnemyRemoved;

        private void Start()
        {
            Stat = new PlayerStat();
            uiManager = FindObjectOfType<UIManager>();
        }

        private void Update()
        {
            curShieldRecoverydelay += Time.deltaTime;
            delay += Time.deltaTime;

            if (curShieldRecoverydelay >= shieldRecoveryDelay)
            {
                if (delay >= 1f)
                {
                    Stat.Shield += 10;
                    delay = 0;
                }
            }

        }

        public void Damaged(int damage)
        {
            curShieldRecoverydelay = 0f;
            Stat.Shield -= damage;
            if (Stat.Shield < 0)
            {
                Stat.Hp += Stat.Shield;
                Stat.Shield = 0;
                SoundManager.Instance.PlaySound("Metal impact 5");
            }
            else
            {
                SoundManager.Instance.PlaySound("Hit_shield");
            }

            if (Stat.Hp <= 0)
            {
                uiManager.Dead();
            }
        }
    }
}
