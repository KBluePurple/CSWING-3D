using System.Collections;
using System.Collections.Generic;
using GameScene;
using UnityEngine;
using TMPro;

public class PausePlayerStat : MonoBehaviour
{
    private TextMeshProUGUI shild;
    private TextMeshProUGUI hp;
    private TextMeshProUGUI energy;
    private TextMeshProUGUI max_speed;
    private TextMeshProUGUI weapon;
    private TextMeshProUGUI core;

    private void Start()
    {
        shild = transform.Find("PlayerShield").GetComponent<TextMeshProUGUI>();
        hp = transform.Find("PlayerHP").GetComponent<TextMeshProUGUI>();
        energy = transform.Find("PlayerEnergy").GetComponent<TextMeshProUGUI>();
        max_speed = transform.Find("PlayerSpeed").GetComponent<TextMeshProUGUI>();
        weapon = transform.Find("PlayerWeapon").GetComponent<TextMeshProUGUI>();
        core = transform.Find("PlayerCore").GetComponent<TextMeshProUGUI>();

        shild.SetText($"Shield : {PlayerManager.Instance.Stat.MaxShield}");
        hp.SetText($"HP : {PlayerManager.Instance.Stat.MaxHp}");
        energy.SetText($"Energy : {PlayerManager.Instance.Stat.MaxEnergy}");
        max_speed.SetText($"Max speed : {PlayerManager.Instance.Stat.MaxSpeed}");
        weapon.SetText($"Weapon : {SaveManager.Instance.Parts.Weapon}");
        core.SetText($"Core : {SaveManager.Instance.Parts.Core}");
    }
}
