using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : SurvivorModeManager
{
    private void OnEnable()
    {
        FixedPursuitSpawnCount = 14;
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
