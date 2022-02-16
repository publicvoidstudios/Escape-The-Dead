using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleEvent : MonoBehaviour
{
    public void SetTimeScale(float scale)
    {
        Time.timeScale = scale;
    }
}
