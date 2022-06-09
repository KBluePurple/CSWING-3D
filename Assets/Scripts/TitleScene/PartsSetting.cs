using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PartsSetting : MonoBehaviour
{
    [SerializeField]
    private Image _pCore;
    [SerializeField]
    private Image _pBooster;
    [SerializeField]
    private Image _pBody;
    [SerializeField]
    private Image _pWeapon1;
    [SerializeField]
    private Image _pWeapon2;
    [SerializeField]
    private Image _pSweapon1;
    [SerializeField]
    private Image _pSweapon2;

    public void GetPart(Image image, PartType type)
    {
        switch(type)
        {
            case PartType.Core :
                _pCore.sprite = image.sprite;
                break;
            case PartType.Booster:
                _pBooster.sprite = image.sprite;
                break;
            case PartType.Body:
                _pBody.sprite = image.sprite;
                break;
            case PartType.Weapon1:
                _pWeapon1.sprite = image.sprite;
                break;
            case PartType.Weapon2:
                _pWeapon2.sprite = image.sprite;
                break;
            case PartType.SWeapon1:
                _pSweapon1.sprite = image.sprite;
                break;
            case PartType.SWeapon2:
                _pSweapon2.sprite = image.sprite;
                break;
        }
    }

    public void RemovePart(PartType type)
    {
        switch (type)
        {
            case PartType.Core:
                _pCore.sprite = null;
                break;
            case PartType.Booster:
                _pBooster.sprite = null;
                break;
            case PartType.Body:
                _pBody.sprite = null;
                break;
            case PartType.Weapon1:
                _pWeapon1.sprite = null;
                break;
            case PartType.Weapon2:
                _pWeapon2.sprite = null;
                break;
            case PartType.SWeapon1:
                _pSweapon1.sprite = null;
                break;
            case PartType.SWeapon2:
                _pSweapon2.sprite = null;
                break;
        }
    }
}
