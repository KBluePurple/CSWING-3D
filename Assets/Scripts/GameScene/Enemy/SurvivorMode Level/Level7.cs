using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level7 : SurvivorModeManager
{
    private void OnEnable()
    {
        FixedPursuitSpawnCount = 19;
        smallPursuitSpawnCount = 5;
        middlePursuitSpawnCount = 3;
        bigPursuitSpawnCount = 1;
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
