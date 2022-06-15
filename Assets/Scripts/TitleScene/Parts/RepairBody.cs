using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairBody : RepairBase
{
    [SerializeField] BodyPart _part;

    private void Start()
    {
        ChildrenStart();
    }

    protected override void PartsSet()
    {
        Debug.Log($"{_part} 장비 설정!");
        PartsSetting.Instance.SetPart(_image, _part, _bundleAdress);
    }

    protected override void UseSet()
    {
        _canUse = SaveManager.Instance.Parts.BODY[_number];
    }
}
