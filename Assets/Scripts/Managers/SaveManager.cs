using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoSingleton<SaveManager>
{
    [SerializeField]
    private PlayerParts parts = null;

    public PlayerParts Parts { get { return parts; } }

    private string SAVE_PATH = "";
    private string SAVE_FILENAME = "/SaveFile.txt";

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        SAVE_PATH = Application.dataPath + "/Json";
        if (!Directory.Exists(SAVE_PATH))
        {
            Directory.CreateDirectory(SAVE_PATH);
        }
        LoadFromJson();
    }

    private void LoadFromJson()
    {
        if (File.Exists(SAVE_PATH + SAVE_FILENAME))
        {
            string json = File.ReadAllText(SAVE_PATH + SAVE_FILENAME);
            parts = JsonUtility.FromJson<PlayerParts>(json);
            Debug.Log("로딩 완료!");
        }
    }

    public void SaveParts()
    {
        string json = JsonUtility.ToJson(parts, true);
        File.WriteAllText(SAVE_PATH + SAVE_FILENAME, json, System.Text.Encoding.UTF8);
        Debug.Log("저장 완료!");
    }
}
