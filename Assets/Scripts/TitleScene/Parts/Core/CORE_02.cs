using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CORE_02 : CoreBase
{
    private void Start()
    {
        base._shield = 150;
    }

    public override void Passive()
    {
        // 받는 피해 -15%
    }
}
