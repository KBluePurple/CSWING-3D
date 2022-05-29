using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
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
}

