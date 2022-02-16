using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipGearInStore : MonoBehaviour
{
    [SerializeField]
    GameObject[] equipTexts;
    [SerializeField]
    GameObject[] equippedTexts;
    [SerializeField]
    PlayerProgress playerProgress;
    // Start is called before the first frame update
    void Start()
    {
        SetAllTextsToEquip();
        GetSavedInfo();
    }

    public void GetSavedInfo()
    {
        equippedTexts[playerProgress.activeWeapon].SetActive(true);
        equipTexts[playerProgress.activeWeapon].SetActive(false);
    }
    public void SetAllTextsToEquip()
    {
        foreach (GameObject equipText in equipTexts)
        {
            equipText.SetActive(true);
        }
        foreach (GameObject equippedText in equippedTexts)
        {
            equippedText.SetActive(false);
        }
    }
}
