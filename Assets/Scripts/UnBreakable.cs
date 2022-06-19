using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnBreakable : MonoBehaviour
{
    public static UnBreakable Instance = null;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
