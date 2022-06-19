using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairSWeapon : RepairBase
{
    [SerializeField] SpecialWeaponPart _part;

    private void Start()
    {
        ChildrenStart();
        if (SaveManager.Instance.Parts.SpecialWeapon == _part)
        {
            _toggleImage.color = Color.yellow;
            _isActive = true;
        }
    }

    public override void PartsSet()
    {
        Debug.Log($"{_part} 장비 설정!");
        SaveManager.Instance.Parts.SpecialWeapon = _part;
        base.PartsSet();
    }

    protected override void UseSet()
    {
        _canUse = SaveManager.Instance.Parts.SWEAPON[_number];
    }
}
