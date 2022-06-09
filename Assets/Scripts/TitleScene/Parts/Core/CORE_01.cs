using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CORE_01 : CoreBase
{
    private void Start()
    {
        base._shield = 100;
    }

    public override void Passive()
    {
        // 메인무기 데미지 +33%
    }
}
