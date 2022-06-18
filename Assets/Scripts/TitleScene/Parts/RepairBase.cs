using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairBase : MonoBehaviour
{
    [SerializeField] protected Image _image;
    [SerializeField] protected string _bundleAdress;
    [SerializeField] protected int _number;

    protected GameObject _alarmPanel;
    protected Image _buttonImage;
    protected Button _button;
    protected Image _toggleImage;
    protected bool _canUse = false; //해당 파츠를 사용가능한가 여부
    protected bool _isActive = false;
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
            _button.onClick.AddListener(()=>PartsSet());
        }
        else
        {
            _button.onClick.AddListener(() => ShowAlarmPanel());
        }
        _button.onClick.AddListener(() =>
        {
            SoundManager.Instance.PlaySound("Dock", SoundType.SE);
        });
    }

    protected void ShowAlarmPanel()
    {
        _alarmPanel.SetActive(true);
    }

    protected virtual void PartsSet()
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

        //선언만 해둠
    }

    protected virtual void UseSet()
    {
        //얘도 선언만 해둠
    }
}
