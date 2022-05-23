using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    //private void Start()
    //{
    //    GetComponent<Button>().onClick.AddListener(() => { });
    //}
    public void OnStart()
    {
        Debug.Log("StartGame");
    }

    public void BodySetting()
    {
        Debug.Log("BodySetting");
    }

    public void OnSetting()
    {
        Debug.Log("Setting");
    }

    public void OnQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
