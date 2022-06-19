using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairBase : MonoBehaviour
{
    [SerializeField] protected Image priviewImage = null;
    [SerializeField] protected Image _image;
    [SerializeField] protected string _bundleAdress;
    [SerializeField] protected int _number;

    protected GameObject _alarmPanel;
    protected Image _buttonImage;
    protected Button _button;
    public Image _toggleImage;
    protected bool _canUse = false; //�ش� ������ ��밡���Ѱ� ����
    public bool _isActive = false;
    protected void ChildrenStart()
    {
        _button = GetComponent<Button>();
        _buttonImage = GetComponent<Image>();
        _toggleImage = transform.Find("Active").GetComponent<Image>();
        _image.sprite = BundleLoader.Instance.FindAsset(_bundleAdress);
        _alarmPanel = transform.parent.parent.parent.parent.Find("MakePartPanel").gameObject;
        UseSet();
        _button.onClick.RemoveAllListeners();
        if (_canUse)
        {
            _button.onClick.AddListener(() => PartsSet());
        }
        else
        {
            _button.onClick.AddListener(() => ShowAlarmPanel());
        }
        _button.onClick.AddListener(() =>
        {
            if (_canUse)
            {
                SoundManager.Instance.PlaySound("Dock", SoundType.SE);
            }
            else
            {
                SoundManager.Instance.PlaySound("UI_Beep", SoundType.SE);
            }
        });
    }

    protected void ShowAlarmPanel()
    {
        _alarmPanel.SetActive(true);
    }

    public virtual void PartsSet()
    {
        if (!_isActive)
        {
            _toggleImage.color = Color.yellow;
            _isActive = true;
        }
        else
        {
            _toggleImage.color = Color.gray;
            _isActive = false;
        }
        SendMessageUpwards("ChangeValue", this);
        //���� �ص�
    }

    protected virtual void UseSet()
    {
        //�굵 ���� �ص�
    }
}
