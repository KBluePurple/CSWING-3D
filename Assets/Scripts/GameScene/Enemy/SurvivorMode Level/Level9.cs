using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level9 : SurvivorModeManager
{
    private void OnEnable()
    {
        FixedPursuitSpawnCount = 3;
        smallPursuitSpawnCount = 5;
        middlePursuitSpawnCount = 3;
        bigPursuitSpawnCount = 5;
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
