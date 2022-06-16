using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameScene;

public class SpeedOmeter : MonoBehaviour
{
    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
    }

    private void Update()
    {
        _text.text = string.Format($"{PlayerMove.Instance._speed:F1} Km/s");
    }
}
