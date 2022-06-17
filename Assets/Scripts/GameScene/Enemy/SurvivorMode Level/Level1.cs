using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : SurvivorModeManager
{

    private void OnEnable()
    {
        FixedPursuitSpawnCount = 3;
        MovedPursuitSpawnCount = 2;
    }

    protected override IEnumerator SpawnPurusit()
    {
        return base.SpawnPurusit();
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
