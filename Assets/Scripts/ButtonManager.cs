using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Setting;

    //private void Start()
    //{
    //    GetComponent<Button>().onClick.AddListener(() => { });
    //}
    public void OnStart()
    {
        Debug.Log("StartGame");
        SceneManager.LoadScene("GameScene");
    }

    public void BodySetting()
    {
        Debug.Log("BodySetting");
    }

    public void OnSetting()
    {
        Setting.SetActive(true);
        //Debug.Log("Setting");
    }

    public void OffSetting()
    {
        Setting.SetActive(false);
    }

    public void OnQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
