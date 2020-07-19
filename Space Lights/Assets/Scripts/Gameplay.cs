using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//	Class is set on a player and used for score manager, life manager, changing color on a player and particals

public class Gameplay : MonoBehaviour {

	public GameObject spawner;		//	Reference to gameobject spawner
	public Text scoreText;			//	Reference to gameobject Text for score
	public GameObject partical;		//	Partical prefab

	public GameObject[] hearts;		//	Array for hearts gameobject
	public GameObject levelManager;	//	Reference to level manager gameobject
	private int lifeCounts = 3;		//	Amount of lifes

	private int score;				//	Number if score points
	private int scoreTracker;		//	Tracker for score points

	//	Seting tag for player and color
	void Start () {
		gameObject.tag = "Green";
		gameObject.GetComponent<SpriteRenderer>().color = Color.green;
	}
	
	//	If player collide with object with the same tag he get a point and score get update, and if not he lose one hart
	// 	If tracker get 20 or above ChangeColorEvent is called on player and obstacles
	// 	If player lose all hearts GameOver method is colled from level manager

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.CompareTag(gameObject.tag)){
			score++;
			scoreText.text = "" + score;
			scoreTracker++;
			GameObject effect = Instantiate(partical, transform.position, Quaternion.identity);
			Destroy(effect, 1);
			collider.gameObject.SetActive(false);
		}else{
			if( lifeCounts > 0){
				hearts[lifeCounts-1].SetActive(false);
				lifeCounts--;
				collider.gameObject.SetActive(false);
				if(lifeCounts == 0){
					Time.timeScale = 0;
					if(PlayerPrefsManager.GetScore() < score){
						PlayerPrefsManager.SetScore(score);			//	If the current score is greater than the last one set new highscore
					}
					
					levelManager.GetComponent<GameMenu>().GameOver();
				}
			}
			
		}

		if(scoreTracker >= 20){
			scoreTracker = 0;
			spawner.GetComponent<Spawner>().ColorChangeEvent();
			gameObject.GetComponent<ChangeColorEvent>().ChangeColorPlayer(gameObject);
		}
	}

	public void AdWatched(){
		foreach (GameObject heart in hearts){
			heart.SetActive(true);
		}
		lifeCounts = 3;
		spawner.GetComponent<Spawner>().RestartSpawner();
		levelManager.GetComponent<GameMenu>().GameOverMenu.SetActive(false);
		Time.timeScale = 1;
	}

}
