using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairUIManager : MonoSingleton<RepairUIManager>
{
    [SerializeField]
    private GameObject _backButton = null;

    private int _titlePageNum;

    private void Start()
    {
        RepairPageChange(0);
    }

    public void RepairPageChange(int pageNum)
    {
        _titlePageNum = pageNum;
        if (_titlePageNum == 0)
        {
            _backButton.SetActive(false);
        }
        else
        {
            _backButton.SetActive(true);
        }
    }

    public void PlayUIClickSound()
    {
        SoundManager.Instance.PlaySound("UI_Click", SoundType.SE);
    }
}
