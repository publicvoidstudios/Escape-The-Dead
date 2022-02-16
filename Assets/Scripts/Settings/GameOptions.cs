using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
public class GameOptions : MonoBehaviour
{
    [Header("Controls")]
    [SerializeField]
    CinemachineVirtualCamera virtualCamera;
    CinemachinePOV pOV;
    [SerializeField]
    Slider joystickVerticalSlider;
    [SerializeField]
    float verticalSensitivityDefaultValue = 0.4f;
    [SerializeField]
    Slider joystickHorizontalSlider;
    [SerializeField]
    float horizontalSensitivityDefaultValue = 1f;

    void Start()
    {
        pOV = virtualCamera.GetCinemachineComponent<CinemachinePOV>();
        SetSlidersToCurrentSettings();
    }

    private void SetSlidersToCurrentSettings()
    {
        joystickHorizontalSlider.value = pOV.m_HorizontalAxis.m_MaxSpeed;
        joystickVerticalSlider.value = pOV.m_VerticalAxis.m_MaxSpeed;
    }

    public void LoadDefaultGameSettings()
    {
        pOV.m_VerticalAxis.m_MaxSpeed = verticalSensitivityDefaultValue;
        pOV.m_HorizontalAxis.m_MaxSpeed = horizontalSensitivityDefaultValue;
        SetSlidersToCurrentSettings();
    }

    public void ApplySliderValues()
    {
        pOV.m_HorizontalAxis.m_MaxSpeed = joystickHorizontalSlider.value;
        pOV.m_VerticalAxis.m_MaxSpeed = joystickVerticalSlider.value;


    }
}
