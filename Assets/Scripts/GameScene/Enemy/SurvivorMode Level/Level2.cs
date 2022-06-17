using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : SurvivorModeManager
{
    private void OnEnable()
    {
        FixedPursuitSpawnCount = 5;
        MovedPursuitSpawnCount = 3;
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
