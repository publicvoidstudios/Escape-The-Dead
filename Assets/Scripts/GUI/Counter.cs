using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Counter : MonoBehaviour
{
    [SerializeField]
    TMP_Text killsText;
    [SerializeField]
    PlayerProgress player;
    [SerializeField]
    TMP_Text koinsEarnedText;
    [SerializeField]
    TMP_Text level;
    int startingKoins;
    int currentKoins;
    int koinsEarned;

    private void Start()
    {
        startingKoins = player.koins;
    }
    void Update()
    {        
        CountNDisplay();
    }
    private void CountNDisplay()
    {
        killsText.text = "ZOMBIES KILLED IN TOTAL: " + player.totalKills.ToString();
        currentKoins = player.koins;
        koinsEarned = currentKoins - startingKoins;
        koinsEarnedText.text = "KOINS EARNED THIS SESSION: " + koinsEarned.ToString();
        level.text = "YOU REACHED LEVEL " + player.level.ToString() + "!";
    }
}
