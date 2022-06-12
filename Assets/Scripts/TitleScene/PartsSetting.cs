using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum CorePart
{

}

public enum EnginePart
{

}

public enum BodyPart
{

}

public enum WeaponPart
{

}

public enum WeaponType
{
    Main,
    Sub
}

public class PartsSetting : MonoBehaviour
{
    public static CorePart Core;
    public static EnginePart Engine;
    public static BodyPart Body;
    public static WeaponPart Weapon;
    public static WeaponPart SubWeapon;

    [SerializeField]
    private Image _pCore;
    [SerializeField]
    private Image _pBooster;
    [SerializeField]
    private Image _pBody;
    [SerializeField]
    private Image _pWeapon;
    [SerializeField]
    private Image _pSweapon;

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
            case PartType.Weapon:
                _pWeapon.sprite = image.sprite;
                break;
            case PartType.SWeapon:
                _pSweapon.sprite = image.sprite;
                break;
        }
    }

    public void SetPart(Image image, CorePart core)
    {
        _pCore.sprite = image.sprite;
        Core = core;
    }

    public void SetPart(Image image, EnginePart engine)
    {
        _pBooster.sprite = image.sprite;
        Engine = engine;
    }

    public void SetPart(Image image, BodyPart body)
    {
        _pBody.sprite = image.sprite;
        Body = body;
    }

    public void SetPart(Image image, WeaponPart weapon, WeaponType type)
    {
        if(type == WeaponType.Main)
        {
            _pWeapon.sprite = image.sprite;
            Weapon = weapon;
        }
        else
        {
            _pSweapon.sprite = image.sprite;
            SubWeapon = weapon;
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
            case PartType.Weapon:
                _pWeapon.sprite = null;
                break;
            case PartType.SWeapon:
                _pSweapon.sprite = null;
                break;
        }
    }
}
