using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairCore : RepairBase
{
    [SerializeField] CorePart _part;

    private void Start()
    {
        ChildrenStart();
        if (SaveManager.Instance.Parts.Core == _part)
        {
            _toggleImage.color = Color.yellow;
            _isActive = true;
        }
    }

    protected override void PartsSet()
    {
        Debug.Log($"{_part} 장비 설정!");
        SaveManager.Instance.Parts.Core = _part;
        base.PartsSet();
    }

    protected override void UseSet()
    {
        _canUse = SaveManager.Instance.Parts.CORE[_number];
    }
}
