using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    private Text _bestScoreText;

    void Start()
    {
        SoundManager.Instance.PlaySound("Epic Backing Track", SoundType.BGM);
        _bestScoreText.text = $"{PlayerPrefs.GetInt("BestScore")}";
    }
}
