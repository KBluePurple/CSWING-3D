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
        if (SaveManager.Instance.Parts.Body == _part)
        {
            _toggleImage.color = Color.yellow;
            _isActive = true;
        }
    }

    public override void PartsSet()
    {
        base.PartsSet();
        SaveManager.Instance.Parts.BodySprite = _image.sprite.name;
        Debug.Log($"{_part} 장비 설정!");
        SaveManager.Instance.Parts.Body = _part;
    }

    protected override void UseSet()
    {
        _canUse = SaveManager.Instance.Parts.BODY[_number];
    }
}
