using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairManager : MonoBehaviour
{
    private RepairBase[] repairBase = null;
    void Start()
    {
        repairBase = GetComponentsInChildren<RepairBase>();
    }

    void ChangeValue(RepairBase select)
    {
        foreach (var item in repairBase)
        {
            if (item != select)
            {
                item._toggleImage.color = Color.gray;
                item._isActive = false;
            }
            else if (item == select)
            {
                item._toggleImage.color = Color.yellow;
                item._isActive = true;
            }
        }
    }
}
