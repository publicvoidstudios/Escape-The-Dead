using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherEffects : MonoBehaviour
{
    [SerializeField]
    GameObject[] fX;


    void Start()
    {
        int rand = Random.Range(0, fX.Length + 1);
        if(rand != fX.Length)
            fX[rand].SetActive(true);
        
    }
}
