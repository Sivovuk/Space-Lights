using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Advertisements;

/*  UPUSTVO
    ako dodajes ovu skriptu u neki projekat trebas da odradis 3 svari
    1. da skines unity monetization 3.3.0 (verzija prilikom ovog pisanja)
    2. da skines advertisments u paketima i da ga azuriras na 3.3.1 verziju
    3. da pobrses unity ads, plugins i editor u slucaju da ti izbacuje erore
*/

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    public Gameplay player;
    string placementId = "3502222";
    string adsRewardedVideo = "rewardedVideo";
    string adsVideo = "video";

    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(placementId, true);
    }

    private void Update()
    {
    }

    public void ShowAdsRewardedVideo()
    {
        Advertisement.Show(adsRewardedVideo);
    }

    public void ShowAdsVideo()
    {
        Advertisement.Show(adsVideo);
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(showResult == ShowResult.Finished)
        {
            player.GetComponent<Gameplay>().AdWatched();
        }
        else if(showResult == ShowResult.Failed)
        {
            Debug.Log("Neuspelo");
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        
    }

    public void OnUnityAdsReady(string placementId)
    {
        
    }

    public void OnUnityAdsDidError(string message)
    {

    }
}
