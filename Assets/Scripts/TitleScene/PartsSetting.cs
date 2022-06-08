using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PartsSetting : MonoBehaviour
{
    private string _pCore = "null";
    private string _pBooster = "null";
    private string _pBody = "null";
    private string _pWeapon1 = "null";
    private string _pWeapon2 = "null";
    private string _pSweapon1 = "null";
    private string _pSweapon2 = "null";

    [SerializeField]
    private TextMeshProUGUI _tCore;
    [SerializeField]
    private TextMeshProUGUI _tBooster;
    [SerializeField]
    private TextMeshProUGUI _tBody;
    [SerializeField]
    private TextMeshProUGUI _tWeapon1;
    [SerializeField]
    private TextMeshProUGUI _tWeapon2;
    [SerializeField]
    private TextMeshProUGUI _tSweapon1;
    [SerializeField]
    private TextMeshProUGUI _tSweapon2;

    public void GetPart(string partName, PartType type)
    {
        switch(type)
        {
            case PartType.Core :
                _pCore = partName;
                break;
            case PartType.Booster:
                _pBooster = partName;
                break;
            case PartType.Body:
                _pBody = partName;
                break;
            case PartType.Weapon1:
                _pWeapon1 = partName;
                break;
            case PartType.Weapon2:
                _pWeapon2 = partName;
                break;
            case PartType.SWeapon1:
                _pSweapon1 = partName;
                break;
            case PartType.SWeapon2:
                _pSweapon2 = partName;
                break;
        }
        TextFormat();
    }

    private void TextFormat()
    {
        _tCore.text = _pCore;
        _tBooster.text = _pBooster;
        _tBody.text = _pBody;
        _tWeapon1.text = _pWeapon1;
        _tWeapon2.text = _pWeapon2;
        _tSweapon1.text = _pSweapon1;
        _tSweapon2.text = _pSweapon2;
    }
}
