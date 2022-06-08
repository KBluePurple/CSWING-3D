using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameScene
{
    public class PlayerStat
    {
        public PlayerStat(int hp, int shield, int energy)
        {

            _maxHp = _hp = hp;
            _maxShield = _shield = shield;
            _maxEnergy = _energy = energy;
        }

        private int _maxHp = 100;
        private int _maxShield = 200;
        private int _maxEnergy = 100;
        private int _hp = 100;
        private int _shield = 200;
        private int _energy = 100;
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
    }
}