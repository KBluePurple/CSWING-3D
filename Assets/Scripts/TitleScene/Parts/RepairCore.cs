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
    }

    protected override void PartsSet()
    {
        Debug.Log($"{_part} 장비 설정!");
        PartsSetting.Instance.SetPart(_image, _part, _bundleAdress);
    }
}
