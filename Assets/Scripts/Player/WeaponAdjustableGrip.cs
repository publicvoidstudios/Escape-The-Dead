using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class WeaponAdjustableGrip : MonoBehaviour
{
    [SerializeField]
    PlayerProgress player;
    [SerializeField]
    WeaponSwitcher weaponSwitcher;

    [SerializeField]
    RigBuilder rigBuilder;

    [SerializeField]
    TwoBoneIKConstraint leftHandIKConstraint;

    [SerializeField]
    TwoBoneIKConstraint rightHandIKConstraint;
    void Start()
    {
        leftHandIKConstraint.data.target = weaponSwitcher.weapons[player.activeWeapon].GetComponentInChildren<LeftGrip>().transform;
        rightHandIKConstraint.data.target = weaponSwitcher.weapons[player.activeWeapon].GetComponentInChildren<RightGrip>().transform;
        rigBuilder.Build();
    }

    private void Update()
    {
        if (player.mainMenuInstance && player.itemSwitched)
        {
            leftHandIKConstraint.data.target = weaponSwitcher.weapons[player.activeWeapon].GetComponentInChildren<LeftGrip>().transform;
            rightHandIKConstraint.data.target = weaponSwitcher.weapons[player.activeWeapon].GetComponentInChildren<RightGrip>().transform;
            rigBuilder.Build();
        }
    }
}
