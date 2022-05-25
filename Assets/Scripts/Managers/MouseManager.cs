using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public void MouseHideSetting(bool isHide)
    {
        Cursor.visible = isHide;
    }

    public void MouseLockSetting(bool isLock)
    {
        Cursor.lockState = isLock ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
