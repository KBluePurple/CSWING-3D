using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnBreakable : MonoBehaviour
{
    private static bool isGameOn = false; 

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
