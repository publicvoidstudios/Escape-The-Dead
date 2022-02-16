using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using TMPro;
public class IAPManager : MonoBehaviour
{
    private const string weaponID01 = "com.publicvoidstudios.escapethedead.weaponid01";
    private const string weaponID02 = "com.publicvoidstudios.escapethedead.weaponid02";
    private const string weaponID03 = "com.publicvoidstudios.escapethedead.weaponid03";
    private const string weaponID04 = "com.publicvoidstudios.escapethedead.weaponid04";
    private const string weaponID05 = "com.publicvoidstudios.escapethedead.weaponid05";
    private const string weaponID06 = "com.publicvoidstudios.escapethedead.weaponid06";
    private const string weaponID07 = "com.publicvoidstudios.escapethedead.weaponid07";
    private const string weaponID08 = "com.publicvoidstudios.escapethedead.weaponid08";
    private const string weaponID09 = "com.publicvoidstudios.escapethedead.weaponid09";
    private const string weaponID10 = "com.publicvoidstudios.escapethedead.weaponid10";
    private const string gearID00 = "com.publicvoidstudios.escapethedead.gearid00";
    private const string gearID01 = "com.publicvoidstudios.escapethedead.gearid01";
    private const string gearID02 = "com.publicvoidstudios.escapethedead.gearid02";
    private const string gearID03 = "com.publicvoidstudios.escapethedead.gearid03";

    [SerializeField]
    PlayerProgress playerProgress;
    [SerializeField]
    WeaponItem[] weaponItems;
    [SerializeField]
    ClothItem[] clothItems;
    [SerializeField]
    GameObject purchaseFailPanel;
    [SerializeField]
    TMP_Text failureDescription;
    public void OnPurchaseComplete(Product product)
    {
        switch (product.definition.id)
        {
            case weaponID01:
                WeaponPurchase(1);                
                return;
            case weaponID02:
                WeaponPurchase(2);
                return;
            case weaponID03:
                WeaponPurchase(3);
                return;
            case weaponID04:
                WeaponPurchase(4);
                return;
            case weaponID05:
                WeaponPurchase(5);
                return;
            case weaponID06:
                WeaponPurchase(6);
                return;
            case weaponID07:
                WeaponPurchase(7);
                return;
            case weaponID08:
                WeaponPurchase(8);
                return;
            case weaponID09:
                WeaponPurchase(9);
                return;
            case weaponID10:
                WeaponPurchase(10);
                return;
            case gearID00:
                GearPurchase(0);
                return;
            case gearID01:
                GearPurchase(1);
                return;
            case gearID02:
                GearPurchase(2);
                return;
            case gearID03:
                GearPurchase(3);
                return;
        }
    }

    public void OnPurchaseFailure(Product product, PurchaseFailureReason reason)
    {
        purchaseFailPanel.SetActive(true);
        failureDescription.text = "Purchase of " + product.metadata.localizedTitle + " failed due to: " + reason;
        if(reason == PurchaseFailureReason.DuplicateTransaction)
        {
            OnPurchaseComplete(product);
        }
    }

    private void WeaponPurchase(int productID)
    {
        //Add Item to Player's pocket
        playerProgress.purchasedWeapons.Add(productID);
        //Update store info
        weaponItems[productID].store.UpdateList();
        //Check purchases to refresh buttons
        weaponItems[productID].CheckPurchases();
        //Save player data
        playerProgress.Save();
    }
    private void GearPurchase(int productID)
    {
        //Add Item to Player's pocket
        playerProgress.purchasedClothes.Add(productID);
        //Update store info
        clothItems[productID].store.UpdateList();
        //Check purchases to refresh buttons
        clothItems[productID].CheckPurchases();
        //Update look
        StartCoroutine(DelayedSwitchCloth());
        //Save player data
        playerProgress.Save();
    }
    IEnumerator DelayedSwitchCloth()
    {
        playerProgress.itemSwitched = true;
        yield return new WaitForSeconds(0.1f);
        playerProgress.itemSwitched = false;
        StopAllCoroutines();
    }
}
