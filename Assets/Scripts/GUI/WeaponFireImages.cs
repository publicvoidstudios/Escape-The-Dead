using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponFireImages : MonoBehaviour
{
    [SerializeField]
    PlayerProgress playerProgress;
    [SerializeField, Tooltip("Place weapon Images in correct order, accordingly to PlayerProgress weapons order")]
    Sprite[] weaponImages;
    [SerializeField]
    Image underlayImage;
    [SerializeField]
    Image rechargeFillImage;
    // Start is called before the first frame update
    void Start()
    {
        underlayImage.sprite = weaponImages[playerProgress.activeWeapon];
        rechargeFillImage.sprite = weaponImages[playerProgress.activeWeapon];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
