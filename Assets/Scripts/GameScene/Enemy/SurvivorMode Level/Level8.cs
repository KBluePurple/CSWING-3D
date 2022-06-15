using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level8 : SurvivorModeManager
{
    private void Start()
    {
        FixedPursuitSpawnCount = 2;
        smallPursuitSpawnCount = 3;
        middlePursuitSpawnCount = 3;
        bigPursuitSpawnCount = 3;
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void SpawnFixedPursuit()
    {
        base.SpawnFixedPursuit();
    }

    protected override void SpawnSmallPursuit()
    {
        base.SpawnSmallPursuit();
    }

    protected override void SpawnMiddlePursuit()
    {
        base.SpawnMiddlePursuit();
    }

    protected override void SpawnBigPursuit()
    {
        base.SpawnBigPursuit();
    }

    protected override void goNextLevel()
    {
        base.goNextLevel();
    }
}
