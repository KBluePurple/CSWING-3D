using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameScene
{
    public class PlayerStat
    {
        public PlayerStat()
        {
            CallAllParts();
        }

        private int _maxHp;
        private int _maxShield;
        private int _maxEnergy;
        private int _hp;
        private int _shield;
        private int _energy;
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
        private CorePart core;
        private BodyPart body;
        private EnginePart engine;
        public int Hp
        {
            get
            {
                return _hp;
            }
            set
            {
                _hp = value;
                if (_hp > _maxHp)
                {
                    _hp = _maxHp;
                }
                else if (_hp < 0)
                {
                    _hp = 0;
                }
                UIManager.Instance.Hp.fillAmount = _hp / (float)_maxHp;
            }
        }

        public int Shield
        {
            get
            {
                return _shield;
            }
            set
            {
                _shield = value;
                if (_shield > _maxShield)
                {
                    _shield = _maxShield;
                }
                else if (_shield < 0)
                {
                    _shield = 0;
                }
                UIManager.Instance.Shield.fillAmount = _shield / (float)_maxShield;
            }
        }

        public int Energy
        {
            get
            {
                return _energy;
            }
            set
            {
                _energy = value;
                if (_energy > _maxEnergy)
                {
                    _energy = _maxEnergy;
                }
                else if (_energy < 0)
                {
                    _energy = 0;
                }
                UIManager.Instance.Energy.fillAmount = _energy / (float)_maxEnergy;
            }
        }

        public int MaxShield { get { return _maxShield; } }
        public int MaxHp { get { return _maxHp; } }
        public int MaxEnergy { get { return _maxEnergy; } }
        public float MaxSpeed { get { return maxSpeed; } }
        private void CallAllParts()
        {
            core = SaveManager.Instance.Parts.Core;
            body = SaveManager.Instance.Parts.Body;
            engine = SaveManager.Instance.Parts.Engine;
            switch(core)
            {
                case CorePart.CORE_01 :
                    _maxShield = 100;
                    break;
                case CorePart.CORE_02:
                    _maxShield = 150;
                    break;
                case CorePart.CORE_03:
                    _maxShield = 75;
                    break;
            }
            switch (body)
            {
                case BodyPart.CS_01:
                    _maxHp = 200;
                    break;
                case BodyPart.CS_02:
                    _maxHp = 250;
                    break;
                case BodyPart.CS_03:
                    _maxHp = 150;
                    break;
            }
            switch (engine)
            {
                case EnginePart.BU_01:
                    maxSpeed = 50;
                    playerAcceleration = 10;
                    deceleration = 8;
                    boostSpeed = 10;
                    boostCooltime = 5;
                    break;
                case EnginePart.BU_02:
                    maxSpeed = 75;
                    playerAcceleration = 15;
                    deceleration = 10;
                    boostSpeed = 20;
                    boostCooltime = 10;
                    break;
                case EnginePart.BU_03:
                    maxSpeed = 35;
                    playerAcceleration = 10;
                    deceleration = 8;
                    boostSpeed = 10;
                    boostCooltime = 3;
                    break;
            }
            _shield = _maxShield;
            _hp = _maxHp;
            curSpeed = 0;
        }
    }
}