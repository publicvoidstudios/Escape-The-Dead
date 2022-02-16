using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class EndGame : MonoBehaviour
{
    [SerializeField]
    Player player;
    [SerializeField]
    PlayerProgress playerProgress;
    [SerializeField]
    GameObject HUD_Canvas;
    [SerializeField]
    GameObject lostCanvas;
    [SerializeField]
    LevelCompleteCheck completeCheck;
    [SerializeField, Tooltip("Assign only in Nightmare Mode")]
    GameObject gogglesCanvas;

    [Header("Lost Canvas variables")]
    [SerializeField]
    TMP_Text lootedText;
    [SerializeField]
    TMP_Text bonusText;

    void Update()
    {
        CheckPlayerState();
    }

    private void CheckPlayerState()
    {
        if (player.infected)
        {
            HUD_Canvas.SetActive(false);
            if(gogglesCanvas != null)
            {
                gogglesCanvas.SetActive(false);
            }
            Invoke("InheritedTimeScale", 2f);
            SetLostCanvasValues();
            lostCanvas.SetActive(true);
        }
    }

    private void SetLostCanvasValues()
    {
        lootedText.text = playerProgress.looted.ToString();
        bonusText.text = "+" + (playerProgress.looted / 5).ToString();
    }

    private void InheritedTimeScale()
    {
        completeCheck.SetTimeScale(1, 0);
    }

    public void LoadMainMenu() //Used to load MainMenu, now reloads currently active scene
    {
        player.infected = false;
        completeCheck.SetTimeScale(0, 1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
