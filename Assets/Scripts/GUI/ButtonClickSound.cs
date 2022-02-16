using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    [SerializeField]
    AudioSource buttonClickAudioSource;
    public void ClickSound()
    {
        buttonClickAudioSource.Play();
    }
}
