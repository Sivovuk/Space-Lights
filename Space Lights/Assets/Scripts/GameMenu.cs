using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//	Class have method for UI traffic

public class GameMenu : MonoBehaviour {

	public GameObject InGameMenu = null;	//	Reference to in game panel
	public GameObject GameOverMenu = null; 	//	Reference to game over panel

	public void Back(string sceneName){
		Time.timeScale = 1;
		SceneManager.LoadScene(sceneName);
	}

	public void Restart(){
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		
		InGameMenu.SetActive(true);
	}

	public void Quit(){

		Application.Quit();

	}

	public void GameOver(){
		Time.timeScale = 0;
		GameOverMenu.SetActive(true);

	}

}
