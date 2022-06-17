using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Level;

    public int curLevel { private set; get; } = 0;

    private float curDelay = 0f;
    private float levelDelay = 90f;

    private void Start()
    {
        Level[0].SetActive(true);
    }

    private void Update()
    {
        curDelay += Time.deltaTime;

        if(curDelay >= levelDelay)
        {
            nextLevel();
        }
    }

    public void nextLevel()
    {
        curDelay = 0f;
        ++curLevel;

        Debug.Log((curLevel + 1) + "�������� ����");

        if(curLevel == 5)
        {
            levelDelay = 180f;
        }
        else
        {
            levelDelay = 90f;
        }

        Level[curLevel].SetActive(true);
    }
}
