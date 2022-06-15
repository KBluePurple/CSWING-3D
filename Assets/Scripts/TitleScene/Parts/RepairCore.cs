using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairCore : MonoBehaviour
{
    [SerializeField] CorePart _part;
    [SerializeField] Image _image;

    private Button _button;
    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() =>
        {
            SoundManager.Instance.PlaySound("Dock", SoundType.SE);
            Debug.Log($"{_part} 장비 설정!");
            PartsSetting.Instance.SetPart(_image, _part);
        });
    }
}
