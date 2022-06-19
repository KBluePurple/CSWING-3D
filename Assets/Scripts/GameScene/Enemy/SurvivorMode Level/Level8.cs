using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level8 : SurvivorModeManager
{
    private void OnEnable()
    {
        FixedPursuitSpawnCount = 4;
        smallPursuitSpawnCount = 6;
        middlePursuitSpawnCount = 6;
        bigPursuitSpawnCount = 6;
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
