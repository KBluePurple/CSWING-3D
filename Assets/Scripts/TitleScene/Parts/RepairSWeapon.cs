using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairSWeapon : MonoBehaviour
{
    [SerializeField] SpesialWeaponPart _part;
    [SerializeField] Image _image;

    private Button _button;
    private Image _toggleImage;
    private void Start()
    {
        _button = GetComponent<Button>();
        _toggleImage = transform.Find("Active").GetComponent<Image>();
        _button.onClick.AddListener(() =>
        {
            SoundManager.Instance.PlaySound("Dock", SoundType.SE);
            Debug.Log($"{_part} 장비 설정!");
            PartsSetting.Instance.SetPart(_image, _part);
        });
    }
}
