using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject setting;
    [SerializeField]
    private GameObject selectGameMode;
    [SerializeField]
    private GameObject title;

    //private void Start()
    //{
    //    GetComponent<Button>().onClick.AddListener(() => { });
    //}

    public void OnStart()
    {
        selectGameMode.SetActive(true);
        title.SetActive(false);
    }

    public void OnStartSurvival()
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
        setting.SetActive(true);
        //Debug.Log("Setting");
    }

    public void OffSetting()
    {
        setting.SetActive(false);
    }

    public void OnQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
