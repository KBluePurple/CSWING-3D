using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CORE_03 : CoreBase
{
    private void Start()
    {
        base._shield = 75;
    }

    public override void Passive()
    {
        // 부스트 지속시간 +50%
    }
}
