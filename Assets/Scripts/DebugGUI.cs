using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGUI : MonoBehaviour
{
    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 50;
        style.normal.textColor = Color.white;

        GUILayout.TextArea($"Pos x : {transform.position.x}", style);
        GUILayout.TextArea($"Pos y : {transform.position.y}", style);
        GUILayout.TextArea($"Pos z : {transform.position.z}", style);
    }
}
