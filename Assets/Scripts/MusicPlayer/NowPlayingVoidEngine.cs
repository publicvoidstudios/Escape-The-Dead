using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class NowPlayingVoidEngine : MonoBehaviour
{
    public TMP_Text nowPlayingText;
    public Slider musicLength;


    void Update()
    {
        if (MusicVoidEngine.instance.CurrentTrackNumber() >= 0)
        {
            string timeText = SecondsToMS(MusicVoidEngine.instance.TimeInSeconds());
            string lengthText = SecondsToMS(MusicVoidEngine.instance.LengthInSeconds());

            nowPlayingText.text = "" + (MusicVoidEngine.instance.CurrentTrackNumber() + 1) + ".  " +
                MusicVoidEngine.instance.NowPlaying().name
                + " (" + timeText + "/" + lengthText + ")";

            musicLength.value = MusicVoidEngine.instance.TimeInSeconds();
            musicLength.maxValue = MusicVoidEngine.instance.LengthInSeconds();


        }
        else
        {
            nowPlayingText.text = "-----------------";
        }
    }

    string SecondsToMS(float seconds)
    {
        return string.Format("{0:D2}:{1:D2}", ((int)seconds) / 60, ((int)seconds) % 60);
    }
}
