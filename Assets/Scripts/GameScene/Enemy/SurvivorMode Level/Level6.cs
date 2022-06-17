using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level6 : SurvivorModeManager
{
    private void OnEnable()
    {
        FixedPursuitSpawnCount = 14;
        smallPursuitSpawnCount = 3;
        middlePursuitSpawnCount = 2;
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
