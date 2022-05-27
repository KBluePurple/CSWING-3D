using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameScene
{
    public class PlayerManager : MonoBehaviour
    {
        //체력
        private float playerHp;
        //실드
        private float playerShield;
        //에너지
        private float playerEnergy;
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
    }
}
