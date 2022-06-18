using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

#region Enum
public enum CorePart
{
    NONE,
    CORE_01,
    CORE_02,
    CORE_03,
}

public enum EnginePart
{
    NONE,
    BU_01,
    BU_02,
    BU_03,
}

public enum BodyPart
{
    NONE,
    CS_01,
    CS_02,
    CS_03,
}

public enum WeaponPart
{
    NONE,
    G_01,
    L_01,
    M_01,
}

public enum SpecialWeaponPart
{
    NONE,
    GA_00,
    LO_VE,
    BU_03,
}
#endregion

public class PartsSetting : MonoSingleton<PartsSetting>
{
    [SerializeField]
    private Image _pCore;
    [SerializeField]
    private Image _pBooster;
    [SerializeField]
    private Image _pBody;
    [SerializeField]
    private Image[] _pWeapon;
    [SerializeField]
    private Image[] _pSweapon;

    private void Start()
    {
        LoadAllParts();
    }

    private void LoadAllParts()
    {
        _pWeapon[0].sprite = BundleLoader.Instance.FindAsset(SaveManager.Instance.Parts.WeaponSprite);
        _pWeapon[1].sprite = BundleLoader.Instance.FindAsset(SaveManager.Instance.Parts.WeaponSprite);
        _pWeapon[1].sprite = BundleLoader.Instance.FindAsset(SaveManager.Instance.Parts.WeaponSprite);
    }

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
                _pWeapon[0].sprite = image.sprite;
                _pWeapon[1].sprite = image.sprite;
                break;
            case PartType.SWeapon:
                _pSweapon[0].sprite = image.sprite;
                _pSweapon[1].sprite = image.sprite;
                break;
        }
    }

    public void SetPart(Image image, CorePart core, string adress)
    {
        _pCore.sprite = image.sprite;
        SaveManager.Instance.Parts.Core = core;
    }

    public void SetPart(Image image, EnginePart engine, string adress)
    {
        _pBooster.sprite = image.sprite;
        SaveManager.Instance.Parts.Engine = engine;
    }

    public void SetPart(Image image, BodyPart body, string adress)
    {
        _pBody.sprite = image.sprite;
        SaveManager.Instance.Parts.Body = body;
    }

    public void SetPart(Image image, WeaponPart weapon, string adress)
    {
        _pWeapon[0].sprite = image.sprite;
        _pWeapon[1].sprite = image.sprite;
        SaveManager.Instance.Parts.WeaponSprite = adress;
        SaveManager.Instance.Parts.Weapon = weapon;
    }

    public void SetPart(Image image, SpecialWeaponPart spesialWeapon, string adress)
    {
        _pSweapon[0].sprite = image.sprite;
        _pSweapon[1].sprite = image.sprite;
        SaveManager.Instance.Parts.SpesialWeapon = spesialWeapon;
    }

    public void RemovePart(PartType type)
    {
        switch (type)
        {
            case PartType.Core:
                SaveManager.Instance.Parts.Core = CorePart.NONE;
                _pCore.sprite = null;
                break;
            case PartType.Booster:
                SaveManager.Instance.Parts.Engine = EnginePart.NONE;
                _pBooster.sprite = null;
                break;
            case PartType.Body:
                SaveManager.Instance.Parts.Body = BodyPart.NONE;
                _pBody.sprite = null;
                break;
            case PartType.Weapon:
                SaveManager.Instance.Parts.Weapon = WeaponPart.NONE;
                _pWeapon[0].sprite = null;
                _pWeapon[1].sprite = null;
                break;
            case PartType.SWeapon:
                SaveManager.Instance.Parts.SpesialWeapon = SpecialWeaponPart.NONE;
                _pSweapon[0].sprite = null;
                _pSweapon[1].sprite = null;
                break;
        }
    }
}
