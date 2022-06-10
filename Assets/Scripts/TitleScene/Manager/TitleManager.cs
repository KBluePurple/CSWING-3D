using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoSingleton<TitleManager>
{
    private int _titlePageNum;

    private void Start()
    {
        _titlePageNum = 0;
    }

    public void RepairPageChange(int pageNum)
    {
        _titlePageNum = pageNum;
    }
}
