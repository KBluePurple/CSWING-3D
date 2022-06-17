using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level8 : SurvivorModeManager
{
    private void OnEnable()
    {
        FixedPursuitSpawnCount = 2;
        smallPursuitSpawnCount = 3;
        middlePursuitSpawnCount = 3;
        bigPursuitSpawnCount = 3;
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
