using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : SurvivorModeManager
{
    private void Start()
    {
        FixedPursuitSpawnCount = 3;
        MovedPursuitSpawnCount = 2;
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
