using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goggles : MonoBehaviour
{
    [SerializeField]
    PlayerProgress playerProgress;
    void OnEnable()
    {
        playerProgress.gogglesActive = true;
    }
}
