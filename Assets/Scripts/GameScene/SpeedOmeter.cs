using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameScene;

public class SpeedOmeter : MonoBehaviour
{
    private PlayerMove _playerMove;
    private Text _text;

    private void Start()
    {
        _playerMove = FindObjectOfType<PlayerMove>();
        _text = GetComponent<Text>();
    }

    private void Update()
    {
        _text.text = string.Format($"{_playerMove._speed:F1} Km/s");
    }
}
