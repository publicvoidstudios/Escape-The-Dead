using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreSystem : MonoBehaviour
{
    [SerializeField]
    PlayerProgress player;
    [SerializeField]
    TMP_Text koins;
    public List<int> purchasedWeapons;
    public List<int> purchasedClothes;
    void Awake()
    {
        UpdateList();
    }

    void Update()
    {
        DisplayKoins();
    }

    private void DisplayKoins()
    {
        koins.text = player.koins.ToString();
    }

    public void UpdateList()
    {
        purchasedWeapons = player.purchasedWeapons;
        purchasedClothes = player.purchasedClothes;
    }
}
