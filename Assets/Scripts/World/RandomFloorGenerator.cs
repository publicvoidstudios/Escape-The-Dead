using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFloorGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject[] floorVariants;

    void Start()
    {
        Invoke("RandomFloor", 0.05f);
    }

    private void RandomFloor()
    {
        floorVariants[Random.Range(0, floorVariants.Length)].SetActive(true);
    }
}
