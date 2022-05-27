using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat
{
    private int _maxHp = 100;
    private int _maxShield = 200;
    private int _maxEnergy = 100;
    public int _hp
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
        }
    }

    public int _shield
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
        }
    }

    public int _energy
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
        }
    }


}
