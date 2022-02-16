using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ClothItem : MonoBehaviour
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
        if (store.purchasedClothes.Contains(productID))
        {
            buyButton.SetActive(false);
            equipButton.SetActive(true);
        }
    }

    public void Buy()
    {
        if (player.koins >= price)
        {
            player.koins -= price;
            buyButton.SetActive(false);
            equipButton.SetActive(true);
            store.purchasedClothes.Add(productID);
            player.purchasedClothes = store.purchasedClothes;
            player.itemSwitched = true;
            StartCoroutine(DelayedSwitchCloth());
            player.Save();
        }
        else
        {
            Debug.Log("Not enough koins (((");
        }
    }
    IEnumerator DelayedSwitchCloth()
    {
        yield return new WaitForSeconds(0.1f);
        player.itemSwitched = false;
        StopAllCoroutines();
    }
}
