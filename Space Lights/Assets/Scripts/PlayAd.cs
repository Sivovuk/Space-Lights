using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class PlayAd : MonoBehaviour
{
	string placementId = "rewardedVideo";
	public GameObject player;

	void Start()
	{
		//Advertisement.Initialize("3502222", true);

		

	}


	// public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
	// {
		
	// }

	// public void OnUnityAdsDidStart(string placementId)
	// {
		
	// }

	// public void OnUnityAdsReady(string placementId)
	// {
		
	// }

	// public void OnUnityAdsDidError(string message)
	// {

	// }






	// void Start(){
	// 	print(PlayerPrefsManager.GetNoAds().ToString());
	// 	if(PlayerPrefsManager.GetNoAds() == "yes"){
	// 		gameObject.SetActive(false);
	// 	}

	// }

	// public void ShowAd(){

	// 	if(Advertisement.IsReady()){
	// 		Advertisement.Show("rewardedVideo", new ShowOptions(){resultCallback = HandleAdResult});
	// 	}
		
	// }

	// private void HandleAdResult(ShowResult result){

	// 	switch (result)
	// 	{
	// 		case ShowResult.Finished:
	// 			player.GetComponent<Gameplay>().AdWatched();
	// 			break;
	// 		case ShowResult.Skipped:
	// 			Debug.Log("Skipped");
	// 			break;
	// 		case ShowResult.Failed:
	// 			Debug.Log("failed");
	// 			break;
	// 	}

	// }

}
