using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PartType
{
    Core,
    Booster,
    Body,
    Weapon1,
    Weapon2,
    SWeapon1,
    SWeapon2,
}

public class RepairMode : MonoBehaviour
{
    [SerializeField]
    private string _part;
    [SerializeField]
    private PartType type;

    private bool _isActive = false;
    private Image _toggleImage;
    private Button _button;
    private PartsSetting _partsSetting;
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ChangePart);
        _toggleImage = transform.Find("Active").GetComponent<Image>();
        _partsSetting = GameObject.Find("Preview").GetComponent<PartsSetting>();
    }

    private void ChangePart()
    {
        if(_isActive)
        {
            _isActive = false;
            Debug.Log($"{_part} 장비 해제!");
            _toggleImage.color = Color.gray;
            _partsSetting.GetPart("null", type);
        }
        else
        {
            _isActive = true;
            Debug.Log($"{_part} 장비 중!");
            _toggleImage.color = Color.yellow;
            _partsSetting.GetPart(_part, type);
        }
    }
}
