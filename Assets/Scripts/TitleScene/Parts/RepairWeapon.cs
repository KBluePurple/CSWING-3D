using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairWeapon : RepairBase
{
    [SerializeField] WeaponPart _part;

    private void Start()
    {
        ChildrenStart();
        if (SaveManager.Instance.Parts.Weapon == _part)
        {
            _toggleImage.color = Color.yellow;
            _isActive = true;
        }
    }

    protected override void PartsSet()
    {
        base.PartsSet();
        Debug.Log($"{_part} 장비 설정!");
        SaveManager.Instance.Parts.Weapon = _part;
    }

    protected override void UseSet()
    {
        _canUse = SaveManager.Instance.Parts.WEAPON[_number];
    }
}
