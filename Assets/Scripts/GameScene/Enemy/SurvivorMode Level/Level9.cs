using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level9 : SurvivorModeManager
{
    private void OnEnable()
    {
        FixedPursuitSpawnCount = 6;
        smallPursuitSpawnCount = 10;
        middlePursuitSpawnCount = 6;
        bigPursuitSpawnCount = 10;
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
