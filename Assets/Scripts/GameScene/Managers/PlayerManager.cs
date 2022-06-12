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
        //�ְ�ӵ�
        private float maxSpeed;
        //����ӵ�
        private float curSpeed;
        //���ӵ�
        private float playerAcceleration;
        //���ӵ�
        private float deceleration;
        //�ν�Ʈ �ӵ�, ��Ÿ��
        private float boostSpeed;
        private float boostCooltime;
        //��ü ȸ���ӵ�, ����
        private float rotationSpeed;
        //����? �� ����? ��?��?

        private UIManager uiManager;

        private void Start()
        {
            Stat = new PlayerStat(100, 200, 100);
            uiManager = FindObjectOfType<UIManager>();
        }

        public void Damaged(int damage)
        {
            Stat.Shield -= damage;
            if (Stat.Shield < 0)
            {
                Stat.Hp += Stat.Shield;
                Stat.Shield = 0;
            }

            if (Stat.Hp <= 0)
            {
                uiManager.Dead();
            }
        }
    }
}
