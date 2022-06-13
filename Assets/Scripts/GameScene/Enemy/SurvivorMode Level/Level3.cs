using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : SurvivorModeManager
{
    private void Start()
    {
        FixedPursuitSpawnCount = 6;
        MovedPursuitSpawnCount = 3;
        curFixedPursuitSpawnCount = 0;
        curMovedPursuitSpawnCount = 0;
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void SpawnFixedPursuit()
    {
        base.SpawnFixedPursuit();
    }

    protected override void SpawnMovedPursuit()
    {
        base.SpawnMovedPursuit();
    }
}
