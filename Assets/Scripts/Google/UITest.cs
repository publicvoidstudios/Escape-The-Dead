using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class UITest : MonoBehaviour
{
    [Header("Player Texts")]
    [SerializeField]
    public TMP_Text[] playerValues;

    [SerializeField]
    public TMP_Text status;
    [SerializeField]
    public TMP_Text log;

    [SerializeField]
    PlayerProgress playerProgress;


    public void FromPP()
    {
        playerValues[0].text = playerProgress.level.ToString();
        playerValues[1].text = playerProgress.koins.ToString();
        playerValues[2].text = playerProgress.activeWeapon.ToString();
        playerValues[3].text = playerProgress.killScore.ToString();
        playerValues[4].text = playerProgress.totalKills.ToString();
        playerValues[5].text = string.Join(",", playerProgress.purchasedWeapons.ToArray());
        playerValues[6].text = string.Join(",", playerProgress.purchasedClothes.ToArray());
        playerValues[7].text = playerProgress.verticalSensitivity.ToString();
        playerValues[8].text = playerProgress.horizontalSensitivity.ToString();
    }

    public void ToPP()
    {
        playerProgress.level = int.Parse(playerValues[0].text);
        playerProgress.koins = int.Parse(playerValues[1].text);
        playerProgress.activeWeapon = int.Parse(playerValues[2].text);
        playerProgress.killScore = int.Parse(playerValues[3].text);
        playerProgress.totalKills = int.Parse(playerValues[4].text);
        playerProgress.purchasedWeapons = playerValues[5].text.Split(',').Select(int.Parse).ToList();
        playerProgress.purchasedClothes = playerValues[6].text.Split(',').Select(int.Parse).ToList();
        playerProgress.verticalSensitivity = float.Parse(playerValues[7].text);
        playerProgress.horizontalSensitivity = float.Parse(playerValues[8].text);
    }

    public void ChangeLevel()
    {
        playerValues[0].text = Random.Range(1, 15).ToString();
    }
    public void ChangeKoins()
    {
        playerValues[1].text = Random.Range(1, 5000).ToString();
    }
    public void ChangeActiveWeapon()
    {
        playerValues[2].text = playerProgress.purchasedWeapons[Random.Range(0, playerProgress.purchasedWeapons.Count)].ToString();
    }

    public void ChangeKillScore()
    {
        playerValues[3].text = Random.Range(1, 1500).ToString();
    }

    public void ChangeTotalKills()
    {
        playerValues[4].text = Random.Range(1, 1500).ToString();
    }

    public void ChangePW()
    {
        int rand = Random.Range(0, 3);
        switch (rand)
        {
            case 0:
                playerValues[5].text = "0,1,2,3,4";
                return;
            case 1:
                playerValues[5].text = "0,5,6,9";
                return;
            case 2:
                playerValues[5].text = "0,2,4,6";
                return;
        }        
    }

    public void ChangePC()
    {
        int rand = Random.Range(0, 3);
        switch (rand)
        {
            case 0:
                playerValues[6].text = "0,1";
                return;
            case 1:
                playerValues[6].text = "0,1,2";
                return;
            case 2:
                playerValues[6].text = "0,2,3";
                return;
        }
    }

    public void ChangeVS()
    {
        playerValues[7].text = Random.Range(0.2f, 1.2f).ToString();
    }

    public void ChangeHS()
    {
        playerValues[8].text = Random.Range(0.8f, 3f).ToString();
    }
}
