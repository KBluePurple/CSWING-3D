using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : SurvivorModeManager
{
    private void Start()
    {
        FixedPursuitSpawnCount = 3;
        MovedPursuitSpawnCount = 2;
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

    protected override void goNextLevel()
    {
        base.goNextLevel();
    }
}
