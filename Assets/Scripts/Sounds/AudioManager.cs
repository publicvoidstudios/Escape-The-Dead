using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    public AudioMixerGroup mixerGroup;
    public Sound[] sounds;
    public int nowPlayingID;
    public float currentClipLength;
    [SerializeField, Range(0.1f, 1f)]
    float masterSoundVolume = 0.5f;
    [SerializeField, Range(15, 150)]
    int maximumSoundDistance = 30;
    // Start is called before the first frame update
    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = mixerGroup;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.spatialBlend = s.spatialBlend;
            s.source.rolloffMode = AudioRolloffMode.Logarithmic;
            s.source.maxDistance = maximumSoundDistance;
            s.source.volume = masterSoundVolume;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " wasn't found!");
            return;
        }
        if (s.randomPitch)
        {
            s.source.pitch = UnityEngine.Random.Range(0.8f, 1.2f);
        }
        s.source.Play();
    }

    private void PlayRandomFromGroup(Sound.Group group)
    {
        Sound[] s = Array.FindAll(sounds, sound => sound.group == group);
        //Debug.Log("Found " + s.Length + " in " + group);
        int selection = UnityEngine.Random.Range(0, s.Length);
        s[selection].source.Play();
        //Debug.Log("Now playing " + s[selection].name + " at " + gameObject.name);
        //currentClipLength = s[selection].source.clip.length;
        nowPlayingID = int.Parse(s[selection].name);
    }

    public void StopAllSounds()
    {
        foreach (Sound sound in sounds)
        {
            sound.source.Stop();
        }
    }

    public void PlayIdleSound()
    {
        if (Time.timeScale != 0)
            PlayRandomFromGroup(Sound.Group.Z_Idle);
    }

    public void PlayWalkingSound()
    {
        if (Time.timeScale != 0)
            PlayRandomFromGroup(Sound.Group.Z_Walk);
    }

    public void PlayAttackingSound()
    {
        if (Time.timeScale != 0)
            PlayRandomFromGroup(Sound.Group.Z_Attack);
    }
    public void PlayDeathSound()
    {
        StopAllSounds();
        PlayRandomFromGroup(Sound.Group.Z_Die);
    }

    public void PlayStop(bool play)
    {
        if (play)
        {
            Sound s = sounds[nowPlayingID];
            s.source.Play();
        }
    }
}
