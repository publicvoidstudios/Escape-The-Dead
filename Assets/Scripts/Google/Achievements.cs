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
    }
}
