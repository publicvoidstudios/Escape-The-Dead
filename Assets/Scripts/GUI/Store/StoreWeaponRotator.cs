using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreWeaponRotator : MonoBehaviour
{
    [Range(0, 100), SerializeField]
    float rotationSpeedY = 20f;
    [SerializeField]
    GameObject[] objectsToRotate;
    void Update()
    {
        foreach(GameObject go in objectsToRotate)
        {
            go.transform.Rotate(0, rotationSpeedY * Time.deltaTime, 0);
        }
        
    }
}
