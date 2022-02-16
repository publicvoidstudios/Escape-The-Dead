using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponItem : MonoBehaviour
{
    [SerializeField]
    public StoreSystem store;
    [SerializeField]
    int productID;
    [SerializeField]
    PlayerProgress player;
    [SerializeField]
    GameObject buyButton;
    [SerializeField]
    GameObject equipButton;
    [SerializeField]
    TMP_Text priceText;
    [SerializeField]
    int price;
    // Start is called before the first frame update
    void Start()
    {
        priceText.text = price.ToString();
        CheckPurchases();
    }

    public void CheckPurchases()
    {
        if (store.purchasedWeapons.Contains(productID))
        {
            buyButton.SetActive(false);
            equipButton.SetActive(true);
        }
    }

    public void Buy()
    {
        if(player.koins >= price)
        {
            player.koins -= price;
            buyButton.SetActive(false);
            equipButton.SetActive(true);
            store.purchasedWeapons.Add(productID);
            player.purchasedWeapons = store.purchasedWeapons;
            player.Save();
        }
        else
        {
            Debug.Log("Not enough koins (((");
        }
    }

    public void Equip()
    {
        player.itemSwitched = true;
        player.activeWeapon = productID;
        player.Save();
        StartCoroutine(DelayedSwitchWeapon());
    }

    IEnumerator DelayedSwitchWeapon()
    {
        yield return new WaitForSeconds(0.1f);
        player.itemSwitched = false;
        StopAllCoroutines();
    }
}
