using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    GameObject loadingPanel;
    [SerializeField]
    Slider loadingSlider;
    [SerializeField]
    GameObject continueButton;
    public bool playerReady;
    public bool nowLoading = false;
    public void LoadLevel(string sceneName)
    {
        StartCoroutine(LoadAsync(sceneName));
    }

    IEnumerator LoadAsync(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        asyncOperation.allowSceneActivation = false;

        loadingPanel.SetActive(true);

        while (!asyncOperation.isDone)
        {
            nowLoading = true;

            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);

            loadingSlider.value = progress;

            if(progress == 1)
            {
                continueButton.SetActive(true);
            }
            if (playerReady)
            {
                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    public void ContinueButton()
    {
        playerReady = true;
    }
}
