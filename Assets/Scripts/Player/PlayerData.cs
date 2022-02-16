using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    [Header("Player's Data")]
    public int level;
    public int koins;
    public int activeWeapon;
    public int killScore;
    public List<int> purchasedWeapons;
    public List<int> purchasedClothes;
    public int totalKills;

    [Header("Player's Settings")]
    [Header("CONTROLS")]
    public float verticalSensitivity;
    public float horizontalSensitivity;
    [Header("AUDIO")]
    public static string desription = "Here goes audio settings";
    public PlayerData(PlayerProgress player)
    {
        level = player.level;
        koins = player.koins;
        activeWeapon = player.activeWeapon;
        killScore = player.killScore;
        purchasedWeapons = player.purchasedWeapons;
        purchasedClothes = player.purchasedClothes;
        totalKills = player.totalKills;
    }
    public PlayerData(PlayerSettings settings)
    {
        verticalSensitivity = settings.verticalSensitivity;
        horizontalSensitivity = settings.horizontalSensitivity;
    }
}
