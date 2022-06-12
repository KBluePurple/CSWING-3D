using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameScene
{
    public class PlayerManager : MonoSingleton<PlayerManager>
    {
        //스탯
        public PlayerStat Stat;
        //무기1, 무기2
        private GameObject playerWeapon1;
        private GameObject playerWeapon2;
        //특수스킬1, 특수스킬2
        private GameObject playerSkill1;
        private GameObject playerSkill2;
        //최고속도
        private float maxSpeed;
        //현재속도
        private float curSpeed;
        //가속도
        private float playerAcceleration;
        //감속도
        private float deceleration;
        //부스트 속도, 쿨타임
        private float boostSpeed;
        private float boostCooltime;
        //몸체 회전속도, 감도
        private float rotationSpeed;
        //감도? 는 어케? 쓰?지?

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
