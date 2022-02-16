using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public enum Group
    {
        Z_Idle,
        Z_Walk,
        Z_Attack,
        Z_Die
    }
    public Group group;
    public AudioClip clip;
    [Range(0.1f, 3f)]
    public float pitch = 1f;
    public bool loop;
    public bool randomPitch;
    [Range(0f, 1f)]
    public float spatialBlend = 1f;
    [HideInInspector]
    public AudioSource source;
}
