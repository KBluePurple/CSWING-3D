using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCheckUI : MonoBehaviour
{
    [SerializeField]
    private Image _enemyBox;

    [SerializeField]
    private List<GameObject> _enemyList = null;

    void Start()
    {
        _enemyList = new List<GameObject>();
        foreach (var item in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            _enemyList.Add(item);
        }
        foreach (var item in GameObject.FindGameObjectsWithTag("Pursuit"))
        {
            _enemyList.Add(item);
        }
    }


    void Update()
    {
        FindEnemy();
    }

    private void FindEnemy()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (!_enemyList.Contains(item))
            {
                _enemyList.Add(item);
            }
        }
        foreach (var item in GameObject.FindGameObjectsWithTag("Pursuit"))
        {
            if (!_enemyList.Contains(item))
            {
                _enemyList.Add(item);
            }
        }
    }
}
