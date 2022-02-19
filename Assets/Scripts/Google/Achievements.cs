using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    [SerializeField]
    GPGSManager gPGSManager;
    [SerializeField]
    PlayerProgress playerProgress;

    public void AchievementsReport()
    {
        CheckAchievements();
        ReportLeaderboards();
    }

    private void ReportLeaderboards()
    {
        gPGSManager.ReportLeaderboardScore(playerProgress.totalKills, GPGSIds.leaderboard_kings_of_massacre);
        gPGSManager.ReportLeaderboardScore(playerProgress.koins, GPGSIds.leaderboard_the_great_hodlers);
    }

    private void CheckAchievements()
    {
        if (playerProgress.totalKills >= 100)
        {
            gPGSManager.GrantBasicAchievement(GPGSIds.achievement_a_hundred);
        }
        if(playerProgress.purchasedWeapons.Count > 1)
        {
            gPGSManager.GrantBasicAchievement(GPGSIds.achievement_guns_guns_guns);
        }
        if(playerProgress.purchasedClothes.Count > 0)
        {
            gPGSManager.GrantBasicAchievement(GPGSIds.achievement_new_look);
        }
        if(playerProgress.level >= 2)
        {
            gPGSManager.GrantBasicAchievement(GPGSIds.achievement_adventure_begins);
        }
        if(playerProgress.level >= 20)
        {
            gPGSManager.GrantBasicAchievement(GPGSIds.achievement_legend);
        }
        if(playerProgress.koins >= 1000)
        {
            gPGSManager.GrantBasicAchievement(GPGSIds.achievement_hobo);
        }
        if(playerProgress.level >= 5)
        {
            gPGSManager.GrantBasicAchievement(GPGSIds.achievement_nightmare_begins);
        }
        if (playerProgress.purchasedClothes.Contains(0))
        {
            gPGSManager.GrantBasicAchievement(GPGSIds.achievement_thrifty);
        }
        if(playerProgress.level >= 10)
        {
            gPGSManager.GrantBasicAchievement(GPGSIds.achievement_anniversary);
        }
        if(playerProgress.totalKills >= 300)
        {
            gPGSManager.GrantBasicAchievement(GPGSIds.achievement_isting_is_300_bucks);
        }
        if(playerProgress.koins >= 10000)
        {
            gPGSManager.GrantBasicAchievement(GPGSIds.achievement_prosperous);
        }
        if (playerProgress.purchasedClothes.Contains(3))
        {
            gPGSManager.GrantBasicAchievement(GPGSIds.achievement_make_it_loud);
        }
        if (playerProgress.purchasedClothes.Contains(2))
        {
            gPGSManager.GrantBasicAchievement(GPGSIds.achievement_not_so_scary);
        }
        if(playerProgress.purchasedWeapons.Count >= 5)
        {
            gPGSManager.GrantBasicAchievement(GPGSIds.achievement_half_of_collection);
        }
        if(playerProgress.purchasedWeapons.Count >= 10)
        {
            gPGSManager.GrantBasicAchievement(GPGSIds.achievement_guns_collection);
        }
        if(playerProgress.purchasedClothes.Count > 4)
        {
            gPGSManager.GrantBasicAchievement(GPGSIds.achievement_trendy);
        }
        if(playerProgress.koins >= 20000)
        {
            gPGSManager.GrantBasicAchievement(GPGSIds.achievement_moneybags);
        }
        if(playerProgress.level >= 30)
        {
            gPGSManager.GrantBasicAchievement(GPGSIds.achievement_nerd);
        }
        if(playerProgress.totalKills >= 1000)
        {
            gPGSManager.GrantBasicAchievement(GPGSIds.achievement_mass_murderer);
        }
    }
}
