using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject title;
    [SerializeField]
    private GameObject setting;
    [SerializeField]
    private GameObject selectGameMode;
    [SerializeField]
    private GameObject repair;

    [Header("Scroll")]
    [SerializeField]
    private GameObject remodelScroll;
    [SerializeField]
    private GameObject spaceshipScroll;
    [SerializeField]
    private GameObject powerScroll;


    private void Start()
    {
        SoundManager.Instance.PlaySound("Epic Backing Track", SoundType.BGM);
    }

    public void Back()
    {
        SoundManager.Instance.PlaySound("UI_Click");
        selectGameMode.SetActive(false);
        repair.SetActive(false);
        setting.SetActive(false);
        title.SetActive(true);
    }

    public void OnStart()
    {
        SoundManager.Instance.PlaySound("UI_Click");
        Debug.Log("SelectGameMode");
        selectGameMode.SetActive(true);
        title.SetActive(false);
    }

    public void OnRepair()
    {
        SoundManager.Instance.PlaySound("UI_Click");
        Debug.Log("Repair");
        repair.SetActive(true);
        title.SetActive(false);
    }

    public void OnStartSurvival()
    {
        SoundManager.Instance.PlaySound("UI_Click");
        Debug.Log("StartGame");
        SceneManager.LoadScene("GameScene");
    }

    public void DisalbleAllScroll()
    {
        SoundManager.Instance.PlaySound("UI_Click");
        remodelScroll.SetActive(false);
        spaceshipScroll.SetActive(false);
        powerScroll.SetActive(false);
    }

    public void ActiveRemodelScroll()
    {
        DisalbleAllScroll();
        remodelScroll.SetActive(true);
    }

    public void ActiveSpaceShipScroll()
    {
        DisalbleAllScroll();
        spaceshipScroll.SetActive(true);
    }

    public void ActivePowerScroll()
    {
        DisalbleAllScroll();
        powerScroll.SetActive(true);
    }

    public void OnSetting()
    {
        setting.SetActive(true);
        //Debug.Log("Setting");
    }

    public void OnQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
