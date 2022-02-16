using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helmet : MonoBehaviour
{
    [SerializeField]
    PlayerProgress playerProgress;
    void OnEnable()
    {
        playerProgress.extraLife = true;
    }
}
