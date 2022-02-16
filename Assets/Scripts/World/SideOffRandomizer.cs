using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideOffRandomizer : MonoBehaviour
{
    [SerializeField]
    GameObject[] variants;

    void OnEnable()
    {
        variants[Random.Range(0, variants.Length)].SetActive(true);
    }
}
