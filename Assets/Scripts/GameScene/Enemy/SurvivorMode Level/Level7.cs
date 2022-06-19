using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level7 : SurvivorModeManager
{
    private void OnEnable()
    {
        FixedPursuitSpawnCount = 38;
        smallPursuitSpawnCount = 10;
        middlePursuitSpawnCount = 6;
        bigPursuitSpawnCount = 2;
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
