using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
public class PlayerProgress : MonoBehaviour
{
    [Header("JSON")]
    [SerializeField]
    JSONSaveSystem jSONSaveSystem;

    [Header("FX")]
    [SerializeField]
    public ParticleSystem levelUpFX;

    [Header("Player Data")]
    public int level = 1;
    public int koins;
    public int activeWeapon = 0;
    public int killScore;
    public int totalKills;

    [Header("Player Purchases")]
    public List<int> purchasedWeapons;
    public List<int> purchasedClothes;

    [Header("Clothes Bonuses")]
    [Tooltip("Backpack Bonus")]
    public int koinsMultiplier = 1;
    [Tooltip("Headset Bonus")]
    public bool coolMusic;
    [Tooltip("Goggles Bonus")]
    public bool gogglesActive;
    [Tooltip("Helmet Bonus")]
    public bool extraLife;

    [Header("Nightmare Mode")]
    public bool nightmareMode;

    [Header("ENABLE ONLY IN MAIN MENU")]
    public bool mainMenuInstance;
    public bool itemSwitched;

    [Header("CONTROLS")]
    [Range(0.2f, 1.2f)]
    public float verticalSensitivity = 0.4f;
    [Range(0.8f, 3f)]
    public float horizontalSensitivity = 1f;

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
    public static string description = "Here goes audio settings";

    public bool initialLoadComplete = false;

    #region OnLevelVariables

    private int startingKoins;
    public int looted;

    #endregion

    void Awake()
    {        
        purchasedWeapons.Add(0);
        if (virtualCamera != null)
        {
            pOV = virtualCamera.GetCinemachineComponent<CinemachinePOV>();
        } 
        LoadFromJson();
        initialLoadComplete = true;
        SetLoadedValuesToSettings();
        SetSlidersToCurrentSettings();
        if (nightmareMode)
        {
            koinsMultiplier *= 2;
        }
        CheckDefaultPrerequisites();
        startingKoins = koins;
    }

    private void Update()
    {
        looted = koins - startingKoins;        
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    public void Save()
    {
        jSONSaveSystem.SaveProgress(level, koins, activeWeapon, killScore, totalKills, purchasedWeapons, purchasedClothes, verticalSensitivity, horizontalSensitivity);
        //SaveProtocol.SaveProgress(this);
    }
    public void Load() //Which data to load?
    {
        PlayerData data = SaveProtocol.LoadProgress();
        //Switch attributes to newly loaded
        level = data.level;
        koins = data.koins;
        activeWeapon = data.activeWeapon;
        killScore = data.killScore;
        purchasedWeapons = data.purchasedWeapons;
        purchasedClothes = data.purchasedClothes;
        totalKills = data.totalKills;
    }

    public void LoadFromJson()
    {
        level = JSONSaveSystem.sv.level;
        koins = JSONSaveSystem.sv.koins;
        activeWeapon = JSONSaveSystem.sv.activeWeapon;
        killScore = JSONSaveSystem.sv.killScore;
        purchasedWeapons = JSONSaveSystem.sv.purchasedWeapons;
        purchasedClothes = JSONSaveSystem.sv.purchasedClothes;
        totalKills = JSONSaveSystem.sv.totalKills;
        verticalSensitivity = JSONSaveSystem.sv.verticalSensitivity;
        horizontalSensitivity = JSONSaveSystem.sv.horizontalSensitivity;
    }
    public void SetLoadedValuesToSettings()
    {
        if (pOV != null)
        {
            pOV.m_VerticalAxis.m_MaxSpeed = verticalSensitivity;
            pOV.m_HorizontalAxis.m_MaxSpeed = horizontalSensitivity;
        }
    }
    private void SetSlidersToCurrentSettings()
    {
        if (pOV != null)
        {
            joystickHorizontalSlider.value = pOV.m_HorizontalAxis.m_MaxSpeed;
            joystickVerticalSlider.value = pOV.m_VerticalAxis.m_MaxSpeed;
        }
        else
        {
            joystickHorizontalSlider.value = horizontalSensitivity;
            joystickVerticalSlider.value = verticalSensitivity;
        }
    }

    public void LoadDefaultGameSettings()
    {
        if (pOV != null)
        {
            pOV.m_VerticalAxis.m_MaxSpeed = verticalSensitivityDefaultValue;
            pOV.m_HorizontalAxis.m_MaxSpeed = horizontalSensitivityDefaultValue;
        }
        else
        {
            horizontalSensitivity = horizontalSensitivityDefaultValue;
            verticalSensitivity = verticalSensitivityDefaultValue;
            joystickHorizontalSlider.value = horizontalSensitivity;
            joystickVerticalSlider.value = verticalSensitivity;
        }   
        SetSlidersToCurrentSettings();
        Save();
    }

    public void ApplySliderControlsValues()
    {
        if(pOV != null)
            pOV.m_HorizontalAxis.m_MaxSpeed = joystickHorizontalSlider.value;
        if (pOV != null)
            pOV.m_VerticalAxis.m_MaxSpeed = joystickVerticalSlider.value;
        horizontalSensitivity = joystickHorizontalSlider.value;
        verticalSensitivity = joystickVerticalSlider.value;
        Save();
    }

    public void CheckDefaultPrerequisites()
    {
        if (purchasedWeapons.Contains(0))
        {
            return;
        }
        else
        {
            purchasedWeapons.Add(0);
            return;
        }
    }

}
