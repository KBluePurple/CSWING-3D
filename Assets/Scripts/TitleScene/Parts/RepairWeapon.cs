using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairWeapon : MonoBehaviour
{
    [SerializeField] WeaponPart _part;
    [SerializeField] Image _image;
    [SerializeField] string _bundleAdress;

    private Button _button;
    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() =>
        {
            Debug.Log($"{_part} 장비 설정!");
            PartsSetting.Instance.SetPart(_image, _part, _bundleAdress);
        });
    }
}
