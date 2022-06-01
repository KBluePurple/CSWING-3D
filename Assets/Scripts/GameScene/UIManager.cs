using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoSingleton<UIManager>
{
    [Header("PlayerUI")]
    [SerializeField]
    private Image shield;
    [SerializeField]
    private Image hp;
    [SerializeField]
    private Image energy;

    [Header("PlayerAttackUI")]
    [SerializeField]
    private GameObject boost;
    [SerializeField]
    private GameObject weapon1;
    [SerializeField]
    private GameObject weapon2;
    [SerializeField]
    private GameObject skill1;
    [SerializeField]
    private GameObject skill2;

    [SerializeField] Text _warningCountDownText = null;

    private void Start()
    {
        SafeZoneManager.Instance.OnSafeZoneCountDown += OnSafeZoneCounterUpdate;
    }

    public void OnSafeZoneCounterUpdate(int count)
    {
        if (count == 0)
        {
            _warningCountDownText.text = "";
            return;
        }
        _warningCountDownText.text = count.ToString();
    }
}

