using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StoreWeaponStats : MonoBehaviour
{
    [Header("FIRE RATE")]
    [SerializeField, Range(0f, 2f)]
    float fireRate;
    [SerializeField]
    Image fillFR;
    [Header("ACCURACY")]
    [SerializeField, Range(0f, 2f)]
    float accuracy;
    [SerializeField]
    Image fillACC;

    void Start()
    {
        fillFR.fillAmount = fireRate / 2;
        fillACC.fillAmount = accuracy / 2;
    }
}
