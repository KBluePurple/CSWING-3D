using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairBase : MonoBehaviour
{
    [SerializeField] protected Image _image;
    [SerializeField] protected string _bundleAdress;
    [SerializeField] protected int _number;

    protected Image _buttonImage;
    protected Button _button;
    protected Image _toggleImage;
    protected bool _canUse = false; //�ش� ������ �����س��� ��밡���Ѱ� ����
    protected void ChildrenStart()
    {
        _button = GetComponent<Button>();
        _buttonImage = GetComponent<Image>();
        _toggleImage = transform.Find("Active").GetComponent<Image>();
        _image.sprite = BundleLoader.Instance.FindAsset(_bundleAdress);
        UseSet();
        if(!_canUse)
        {
            _buttonImage.color = Color.black;
            _toggleImage.enabled = false;
            _button.onClick.AddListener(ShowMakePanel);
        }
        else
        {
            _button.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlaySound("Dock", SoundType.SE);
                PartsSet();
            });
        }
    }
    protected void ShowMakePanel()
    {

    }

    protected virtual void PartsSet()
    {
        //���� �ص�
    }

    protected virtual void UseSet()
    {
        //�굵 ���� �ص�
    }
}
