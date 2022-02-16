using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ModeSelector : MonoBehaviour
{
    [SerializeField]
    PlayerProgress playerProgress;
    [SerializeField]
    Button nightmareButton;
    [SerializeField]
    GameObject unlockingText;
    [SerializeField]
    GameObject _2X;
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    private void Update()
    {
        if(playerProgress.level < 5)
        {
            nightmareButton.interactable = false;
            unlockingText.SetActive(true);
            _2X.SetActive(false);
        }
        else
        {
            nightmareButton.interactable = true;
            unlockingText.SetActive(false);
            _2X.SetActive(true);
        }
    }
}
