using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairEngine : RepairBase
{
    [SerializeField] EnginePart _part;

    private void Start()
    {
        ChildrenStart();
        if (SaveManager.Instance.Parts.Engine == _part)
        {
            _toggleImage.color = Color.yellow;
            _isActive = true;
        }
    }

    public override void PartsSet()
    {
        Debug.Log($"{_part} 장비 설정!");
        SaveManager.Instance.Parts.Engine = _part;
        base.PartsSet();
    }

    protected override void UseSet()
    {
        _canUse = SaveManager.Instance.Parts.ENGINE[_number];
    }
}
