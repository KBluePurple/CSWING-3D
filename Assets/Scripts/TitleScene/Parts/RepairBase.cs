using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairBase : MonoBehaviour
{
    [SerializeField] protected Image _image;
    [SerializeField] protected string _bundleAdress;

    protected Button _button;
    protected Image _toggleImage;

    protected void ChildrenStart()
    {
        _button = GetComponent<Button>();
        _toggleImage = transform.Find("Active").GetComponent<Image>();
        _image.sprite = BundleLoader.Instance.FindAsset(_bundleAdress);
        _button.onClick.AddListener(() =>
        {
            SoundManager.Instance.PlaySound("Dock", SoundType.SE);
            PartsSet();
        });
    }

    protected virtual void PartsSet()
    {
        //¼±¾ð¸¸ ÇØµÒ
    }
}
