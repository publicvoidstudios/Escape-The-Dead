using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FireButtonCooldown : MonoBehaviour
{
    [SerializeField]
    Shooting shooting;
    [SerializeField]
    Image fireButtonFill;
    void FixedUpdate()
    {
        float fillAmount = (float)shooting.rechargeTime / (float)shooting.fireRate;
        fireButtonFill.fillAmount = fillAmount;
    }
}
