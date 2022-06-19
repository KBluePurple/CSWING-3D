using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : SurvivorModeManager
{
    private void OnEnable()
    {
        FixedPursuitSpawnCount = 10;
        smallPursuitSpawnCount = 10;
    }

    protected override IEnumerator SpawnPurusit()
    {
        return base.SpawnPurusit();
    }

    protected override void goNextLevel()
    {
        base.goNextLevel();
    }
}
