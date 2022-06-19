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
    private string SAVE_FILENAME = "/SaveFile.json";
    private string default_save = @"{
    ""Core"": 1,
    ""CoreSprite"": """",
    ""Engine"": 1,
    ""EngineSprite"": """",
    ""Body"": 1,
    ""BodySprite"": ""body1"",
    ""Weapon"": 1,
    ""WeaponSprite"": ""weapon2.png"",
    ""SpesialWeapon"": 1,
    ""SpesialWeaponSprite"": """",
    ""CORE"": [
        true,
        false,
        false
    ],
    ""ENGINE"": [
        true,
        false,
        false
    ],
    ""BODY"": [
        true,
        false,
        false
    ],
    ""WEAPON"": [
        true,
        false,
        false
    ],
    ""SWEAPON"": [
        true,
        false,
        false
    ]
}";
    private void Awake()
    {
        SAVE_PATH = Application.dataPath + "/Json";
        if (!Directory.Exists(SAVE_PATH))
        {
            Directory.CreateDirectory(SAVE_PATH);
            File.WriteAllText(SAVE_PATH + SAVE_FILENAME, default_save, System.Text.Encoding.UTF8);
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
