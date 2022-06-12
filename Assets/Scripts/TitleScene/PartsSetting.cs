using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum CorePart
{
    CORE_01,
    CORE_02,
    CORE_03,
}

public enum EnginePart
{
    BU_01,
    BU_02,
    BU_03,
}

public enum BodyPart
{
    CS_01,
    CS_02,
    CS_03,
}

public enum WeaponPart
{
    G_01,
    L_01,
    M_01,
}

public enum SpesialWeaponPart
{
    GA_00,
    LO_VE,
    BU_03,
}

public class PartsSetting : MonoBehaviour
{
    public static CorePart Core;
    public static EnginePart Engine;
    public static BodyPart Body;
    public static WeaponPart Weapon;
    public static SpesialWeaponPart SpesialWeapon;

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

    public void SetPart(Image image, WeaponPart weapon)
    {
        _pWeapon.sprite = image.sprite;
        Weapon = weapon;
    }

    public void SetPart(Image image, SpesialWeaponPart spesialWeapon)
    {
        _pSweapon.sprite = image.sprite;
        SpesialWeapon = spesialWeapon;
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
