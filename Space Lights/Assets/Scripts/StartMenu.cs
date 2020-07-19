using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//	Class used by StartScreen scene for change StartMenu and settings

public class StartMenu : MonoBehaviour {

	public GameObject settings;		//	Reference for panel for settings
	public GameObject startMenu;	//	Reference for panel for start menu
	public Text score;				//	Reference for score Text
	
	//	Method called by button when player want to open seeting menu
	public void OpenSettings(){
		settings.SetActive(true);
		startMenu.SetActive(false);
	}
	
	//	Method called by button when player want to open start menu
	public void OpenStartMenu(){
		startMenu.SetActive(true);
		settings.SetActive(false);
	}

	//	Update score text from player prefs script
	void Start(){
		score.text = PlayerPrefsManager.GetScore().ToString();
	}

	//	When player hit to play the game start
	void Update(){
        if (Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)){
                if (hit.collider.name == "TapToPlay"){
                   	SceneManager.LoadScene("Gameplay");
                }
            }
        }
    }

}
