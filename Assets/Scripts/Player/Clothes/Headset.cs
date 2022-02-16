using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headset : MonoBehaviour
{
    [SerializeField]
    PlayerProgress playerProgress;
    [SerializeField]
    GameObject audioHUD;
    void OnEnable()
    {
        playerProgress.coolMusic = true;
        if (audioHUD != null)
            audioHUD.SetActive(true);
    }
}
