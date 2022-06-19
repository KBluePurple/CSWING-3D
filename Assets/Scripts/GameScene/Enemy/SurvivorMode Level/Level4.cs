using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4 : SurvivorModeManager
{
    private void OnEnable()
    {
        FixedPursuitSpawnCount = 20;
        MovedPursuitSpawnCount = 8;
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
