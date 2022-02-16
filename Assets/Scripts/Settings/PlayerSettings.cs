using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
public class PlayerSettings : MonoBehaviour
{
    [Header("JSON")]
    [SerializeField]
    JSONSaveSystem jSONSaveSystem;

    [Header("CONTROLS")]
    [Range(0.2f, 1.2f)]
    public float verticalSensitivity;
    [Range(0.8f, 3f)]
    public float horizontalSensitivity;

    [Header("Controls, ONLY GAME MODE")]
    [SerializeField]
    CinemachineVirtualCamera virtualCamera;
    [SerializeField]
    CinemachinePOV pOV;
    [SerializeField]
    Slider joystickVerticalSlider;
    [SerializeField]
    float verticalSensitivityDefaultValue = 0.4f;
    [SerializeField]
    Slider joystickHorizontalSlider;
    [SerializeField]
    float horizontalSensitivityDefaultValue = 1f;

    [Header("AUDIO")]
    public static string desription = "Here goes audio settings";

    // Start is called before the first frame update
    void Start()
    {
        if (virtualCamera != null)
        {
            pOV = virtualCamera.GetCinemachineComponent<CinemachinePOV>();
        }
        Load();         
        SetLoadedValuesToSettings();
        SetSlidersToCurrentSettings();
    }
    public void Save()
    {
        SaveProtocolSettings.SaveProgress(this);
    }
    public void Load() //Which data to load?
    {
        PlayerData data = SaveProtocolSettings.LoadProgress();
        //Switch attributes to newly loaded
        verticalSensitivity = data.verticalSensitivity;
        horizontalSensitivity = data.horizontalSensitivity;
    }

    public void SetLoadedValuesToSettings()
    {
        if (pOV != null)
        {
            pOV.m_VerticalAxis.m_MaxSpeed = verticalSensitivity;
            pOV.m_HorizontalAxis.m_MaxSpeed = horizontalSensitivity;
        }
        else
        {
            Debug.LogError("WARNING!!! POV NOT FOUND!");
        }
    }
    private void SetSlidersToCurrentSettings()
    {
        if(pOV != null)
        {
            joystickHorizontalSlider.value = pOV.m_HorizontalAxis.m_MaxSpeed;
            joystickVerticalSlider.value = pOV.m_VerticalAxis.m_MaxSpeed;
        }
    }

    public void LoadDefaultGameSettings()
    {
        pOV.m_VerticalAxis.m_MaxSpeed = verticalSensitivityDefaultValue;
        pOV.m_HorizontalAxis.m_MaxSpeed = horizontalSensitivityDefaultValue;
        SetSlidersToCurrentSettings();
        Save();
    }

    public void ApplySliderControlsValues()
    {
        pOV.m_HorizontalAxis.m_MaxSpeed = joystickHorizontalSlider.value;
        pOV.m_VerticalAxis.m_MaxSpeed = joystickVerticalSlider.value;
        Save();
    }
}
