using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level6 : SurvivorModeManager
{
    private void OnEnable()
    {
        FixedPursuitSpawnCount = 28;
        smallPursuitSpawnCount = 6;
        middlePursuitSpawnCount = 4;
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
