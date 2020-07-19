using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  PlayerPrefsManager is class for seting two things player score and music on/off and its used when player start game

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";   //  Volume const key
    const string SCORE_KEY = "score";                   //  Score const key
    const string NO_ADS_KEY = "no_ads";                 //  No ads cons key

	public static void SetMasterVolume(int volume) {
        if (volume == 0){
            PlayerPrefs.SetInt(MASTER_VOLUME_KEY, volume);
        }
        else if(volume == 1){
            PlayerPrefs.SetInt(MASTER_VOLUME_KEY, volume);
        }else{
			Debug.LogError("Not a valid number");
		}
    }

    public static float GetMasterVolume() {
        return PlayerPrefs.GetInt(MASTER_VOLUME_KEY);
    }

	public static void SetScore(int score) {
       
        PlayerPrefs.SetInt(SCORE_KEY, score);
       
    }

    public static float GetScore() {
        return PlayerPrefs.GetInt(SCORE_KEY);
    }

    public static void SetNoAds(string noAdsKey){
        PlayerPrefs.SetString(NO_ADS_KEY, noAdsKey);
    }

    public static string GetNoAds(){
        return PlayerPrefs.GetString(NO_ADS_KEY);
    }

}
