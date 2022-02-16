using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class WeaponStats : MonoBehaviour
{
    [Header("FIRE RATE")]
    [SerializeField]
    Shooting shooting;
    [SerializeField, Range(0f, 2f)]
    public float fireRate;
    [Header("ACCURACY")]
    [SerializeField]
    CinemachineVirtualCamera CMVCam;
    [SerializeField, Range(0f, 2f)]
    float accuracy;


    // Update is called once per frame
    private void Update()
    {
        SendToShooting();
        SetAccuracy();
    }

    private void SetAccuracy()
    {
        CMVCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = accuracy;
    }

    private void SendToShooting()
    {
        if (shooting != null)
        {
            shooting.fireRate = fireRate;
            shooting = null;
        }
    }
}
