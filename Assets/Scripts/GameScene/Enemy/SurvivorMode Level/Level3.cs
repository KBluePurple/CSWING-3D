using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : SurvivorModeManager
{
    private void OnEnable()
    {
        FixedPursuitSpawnCount = 6;
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
