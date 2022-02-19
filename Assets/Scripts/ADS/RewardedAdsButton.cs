using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using TMPro;

[RequireComponent(typeof(Button))]
public class RewardedAdsButton : MonoBehaviour, IUnityAdsListener
{

#if UNITY_IOS
    private string gameId = "4610596";
#elif UNITY_ANDROID
    private string gameId = "4610597";
#endif

    Button myButton;
    public string myPlacementId = "Rewarded_Android";
    [SerializeField]
    PlayerProgress playerProgress;
    [SerializeField]
    TMP_Text info;
    [SerializeField]
    GameObject aDReady;
    [SerializeField]
    GameObject aDNotReady;
    [SerializeField]
    GameObject aDWatched;
    [SerializeField]
    AdState adState;
    public bool watched = false;

    void OnEnable()
    {
        myButton = GetComponent<Button>();

        // Set interactivity to be dependent on the Placement’s status:
        myButton.interactable = Advertisement.IsReady(myPlacementId);

        // Map the ShowRewardedVideo function to the button’s click listener:
        if (myButton) myButton.onClick.AddListener(ShowRewardedVideo);

        // Initialize the Ads listener and service:
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, false); //Set to false when publishing!

        // Swtich button state to Ready
        SwitchButtonState(AdState.Ready);
    }

    void OnDisable()
    {
        myButton.onClick.RemoveAllListeners();

        Advertisement.RemoveListener(this);
    }

    // Implement a function for showing a rewarded video ad:
    void ShowRewardedVideo()
    {
        Advertisement.Show(myPlacementId);
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, activate the button: 
        if (placementId == myPlacementId)
        {
            if (!watched)
            {
                SwitchButtonState(AdState.Ready);
                myButton.interactable = true;
            }
            else
            {
                SwitchButtonState(AdState.Watched);
                myButton.interactable = false;
            }
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            // Reward the user for watching the ad to completion.
            playerProgress.koins += playerProgress.looted / 5;
            watched = true;
            info.text = "THANKS FOR WATCHING ADS";
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
            info.text = "NO REWARD FOR SKIPPING AD :(";            
        }
        else if (showResult == ShowResult.Failed)
        {
            info.text = "FAILED TO WATCH ADS";
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    private enum AdState
    {
        Ready,
        NotReady,
        Watched
    }

    private void SwitchButtonState(AdState state)
    {
        switch (state)
        {
            case AdState.Ready:
                aDReady.SetActive(true);
                aDNotReady.SetActive(false);
                aDWatched.SetActive(false);
                adState = AdState.Ready;
                return;
            case AdState.NotReady:
                aDReady.SetActive(false);
                aDNotReady.SetActive(true);
                aDWatched.SetActive(false);
                adState = AdState.NotReady;
                return;
            case AdState.Watched:
                aDReady.SetActive(false);
                aDNotReady.SetActive(false);
                aDWatched.SetActive(true);
                adState = AdState.Watched;
                return;
        }
    }
}
