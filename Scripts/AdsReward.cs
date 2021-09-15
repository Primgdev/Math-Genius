using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsReward : MonoBehaviour, IUnityAdsListener
{
#if UNITY_ANDROID
private string gameId = "4268875";
#endif

    bool testMode = true;
    string mySurfacingId_Reward = "Rewarded_Android";

    public static QuizManager instance;
    // Start is called before the first frame update
    void Start()
    {
       Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
    }

   
    public void ShowRewardAd()
    {
        if(Advertisement.IsReady(mySurfacingId_Reward))
        {
            Advertisement.Show(mySurfacingId_Reward);
        }
        else
        {
            print("help");
        }
    }


    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            // Reward the user for watching the ad to completion.
            if (placementId.Equals(mySurfacingId_Reward))
            {
                if (showResult == ShowResult.Finished)
                {
                    QuizManager.instance.timeRemaining = 5;
                    QuizManager.instance.endScene.SetActive(false);
                    QuizManager.instance.music.Play();
                    QuizManager.instance.timer = true;
                    QuizManager.instance.timeUp.gameObject.SetActive(false);
                    print("time added");                   
                }
            }
        }
        else if(showResult == ShowResult.Skipped)
        {
            print("you skipped it");
        }
        else if(showResult == ShowResult.Failed)
        {
            Debug.Log("you skip the ad");
        }



    }

    public void OnUnityAdsReady(string placementId)
    {
        if(placementId == mySurfacingId_Reward)
        {

        }
    }

    public void OnUnityAdsDidError(string message)
    {

    }

    public void OnUnityAdsDidStart(string placementId)
    {

    }

    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }

    

}
