using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Globalization;

public class JSONSaveSystem : MonoBehaviour
{
    public static Save sv = new Save();
    private string path;
    private const string timeFormat = "MM/dd/yyyy HH:mm:ss";


    private void Awake()
    {
        path = Path.Combine(Application.persistentDataPath, "Save.json");
        if (File.Exists(path))
        {
            sv = JsonUtility.FromJson<Save>(File.ReadAllText(path));
        }
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        if (pause)
            SaveProgressToJson();
    }
#endif
    private void OnApplicationQuit()
    {
        SaveProgressToJson();
        GooglePlayGames.PlayGamesPlatform.Instance.SignOut();
    }

    public void SaveProgressToJson()
    {
        File.WriteAllText(path, JsonUtility.ToJson(sv));        
    }

    public void SaveProgress(int level, int koins, int activeWeapon, int killScore, int totalKills, List<int> purchasedWeapons, List<int> purchasedClothes, float vertical, float horizontal)
    {
        sv.gameDate = DateTime.Now.ToString(timeFormat);
        sv.level = level;
        sv.koins = koins;
        sv.activeWeapon = activeWeapon;
        sv.killScore = killScore;
        sv.totalKills = totalKills;
        sv.purchasedWeapons = purchasedWeapons;
        sv.purchasedClothes = purchasedClothes;
        sv.verticalSensitivity = vertical;
        sv.horizontalSensitivity = horizontal;
        SaveProgressToJson();
    }

    public byte[] GetData()
    {
        sv.gameDate = DateTime.Now.ToString(timeFormat);
        string json = JsonUtility.ToJson(sv);
        byte[] byteArray = Encoding.UTF8.GetBytes(json);
        return byteArray;
    }

    public static void LoadSave(string data)
    {
        sv = JsonUtility.FromJson<Save>(data);
    }
    public static void LoadSave(byte[] data)
    {
        LoadSave(Encoding.UTF8.GetString(data, 0, data.Length));
    }

    [Serializable]
    public class Save
    {
        [Header("Player Data")]
        public int level = 1;
        public int koins;
        public int activeWeapon = 0;
        public int killScore;
        public int totalKills;

        [Header("Player Purchases")]
        public List<int> purchasedWeapons;
        public List<int> purchasedClothes;

        public float verticalSensitivity;
        public float horizontalSensitivity;

        [Header("Common Data")]
        public string gameDate;
    }
}
