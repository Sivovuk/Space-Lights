using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//	Class Spawner is locate on GameObjact Spawner and it sole purpose is to call script ObjectPooling and 
//	spawn object in sablon that it define in code

public class Spawner : MonoBehaviour {

	public GameObject[] prefab;							//	Array of gameobjects that will be chosen to be spawn 
	public Sprite[] colors;								//	Sprites that will be change after ChangeColorEvent method is called
	public List<float> xAxis = new List<float>();		//	Positions that will be chosen randomly where will start point for spawning object
	public float timeBetweenSpawns;						//	Number of seconds between spawning groups of objects
	public float spawningTimeBetweenObjects;			//	Number of seconds between every object individually

	private int timer;									//	How many rounds of the current scenario have pass
	private int timerLimit = 3;
	ObjectPooling pool;		

	private float x;
	private float y;	
	private float xAxisPositive;
	private float xAxisNegative;
	private Vector2 newPos;
	private Vector2 screenPosition;


	void Start () {
		pool = ObjectPooling.Instance; 					//	Calling and starting instance of class ObjectPooling

		x = Screen.width;
		y = Screen.height;
		newPos = new Vector2(x, y);
		screenPosition = Camera.main.ScreenToWorldPoint(newPos);
		
		xAxisPositive = screenPosition.x;
		xAxisNegative = -screenPosition.x;

		SettingXaxis();
		StartCoroutine(RoundOne());						//	Starting the game
	}

	//	Method is called when is need to stop and restart the coroutine
	public void RestartCorutine(string name){
		StopCoroutine(name);
		StartCoroutine(name);
	}

	//	In front we can se coroutines one coroutine for one scenario

	IEnumerator RoundOne(){
		yield return new WaitForSeconds(1f);
		int randomObject = UnityEngine.Random.Range(0, prefab.Length);
		int randomPos = UnityEngine.Random.Range(0, xAxis.Count);

		for(int i = 0; i < 6; i++){

			Vector2 position = new Vector2(xAxis[randomPos], 0);

			pool.SpawningObjects(prefab[randomObject].tag, position, prefab[randomObject].transform.rotation);
			if(pool == null){
				RestartCorutine(RoundOne().ToString());
			}
			
			yield return new WaitForSeconds(spawningTimeBetweenObjects);
		}
		float timeBetweenSpawnsForRoundOne = timeBetweenSpawns / 3f;
		yield return new WaitForSeconds(timeBetweenSpawnsForRoundOne);

		timer++;
		if(timer < timerLimit){
			StartCoroutine(RoundOne());
		}else{
			StartCoroutine(RoundTwo());
			timer = 0;
		}
		
	}

	IEnumerator RoundTwo(){
		int randomObject = UnityEngine.Random.Range(0, prefab.Length);
		int randomPos = UnityEngine.Random.Range(0, xAxis.Count);
		int invers = 0;
		if(xAxis[randomPos] < 0){
			invers = 1;
		}else{
			invers = 2;
		}
		
		if(invers == 2){

			for (int i = randomPos, k = 0; k <= 4; i++, k++){
				
				Vector2 position = new Vector2(xAxis[i], 0);

				pool.SpawningObjects(prefab[randomObject].tag, position, prefab[randomObject].transform.rotation);
				
				if(pool == null){
					RestartCorutine(RoundTwo().ToString());
				}
				
				yield return new WaitForSeconds(spawningTimeBetweenObjects);
			}

			for (int i = randomPos + 3, k = 0; k < 3; i--, k++){
				Vector2 position = new Vector2(xAxis[i], 0);

				pool.SpawningObjects(prefab[randomObject].tag, position, prefab[randomObject].transform.rotation);
				
				if(pool == null){
					RestartCorutine(RoundTwo().ToString());
				}
				
				yield return new WaitForSeconds(spawningTimeBetweenObjects);
			}
			invers=0;
		}
		if(invers == 1){

			for (int i = randomPos, k = 0; k <= 4; i--, k++){
				
				Vector2 position = new Vector2(xAxis[i], 0);

				pool.SpawningObjects(prefab[randomObject].tag, position, prefab[randomObject].transform.rotation);
				
				if(pool == null){
					RestartCorutine(RoundTwo().ToString());
				}
				
				yield return new WaitForSeconds(spawningTimeBetweenObjects);
			}

			for (int i = randomPos - 3, k = 0; k < 3; i++, k++){
				Vector2 position = new Vector2(xAxis[i], 0);

				pool.SpawningObjects(prefab[randomObject].tag, position, prefab[randomObject].transform.rotation);
				
				if(pool == null){
					RestartCorutine(RoundTwo().ToString());
				}
				
				yield return new WaitForSeconds(spawningTimeBetweenObjects);
			}
			invers=0;
		}
		

		yield return new WaitForSeconds(timeBetweenSpawns-0.1f);

		timer++;
		if(timer < timerLimit){
			StartCoroutine(RoundTwo());
		}else{
			timer = 0;
			StartCoroutine(RoundThree());
		}
		
	}

	IEnumerator RoundThree(){
		int randomObject = UnityEngine.Random.Range(0, prefab.Length);
		int randomPos = UnityEngine.Random.Range(0, xAxis.Count);
		bool first = false;
		bool second = false;


		if(first == false){
			Vector2 position = new Vector2(xAxis[randomPos], 0);

			pool.SpawningObjects(prefab[randomObject].tag, position, prefab[randomObject].transform.rotation);
			
			if(pool == null){
				RestartCorutine(RoundTwo().ToString());
			}
			
			yield return new WaitForSeconds(spawningTimeBetweenObjects);
			first = true;
		}
		if(second == false){
			int k = randomPos+1;
			int j = randomPos-1;
			for(int i = 0; i < 3; i++, k++, j--){
				Vector2 firstPosition = new Vector2();
				Vector2 secondPosition = new Vector2();
				
				if(k < xAxis.Count){
					firstPosition = new Vector2(xAxis[k], 0);
				}
				if(j > -1){
					secondPosition = new Vector2(xAxis[j], 0);
				}
				
				if(firstPosition != null && k < xAxis.Count){
					pool.SpawningObjects(prefab[randomObject].tag, firstPosition, prefab[randomObject].transform.rotation);
				}
				if(pool == null){
					RestartCorutine(RoundTwo().ToString());
				}

				if(secondPosition != null && j > -1){
					pool.SpawningObjects(prefab[randomObject].tag, secondPosition, prefab[randomObject].transform.rotation);
				}

				if(pool == null){
					RestartCorutine(RoundTwo().ToString());
				}
				
				yield return new WaitForSeconds(spawningTimeBetweenObjects);
			}
			second = true;
		}

		yield return new WaitForSeconds(timeBetweenSpawns-0.2f);

		timer++;
		if(timer < timerLimit){
			StartCoroutine(RoundThree());
		}else{
			timer = 0;
			StartCoroutine(RoundFour());
		}
	}
	
	IEnumerator RoundFour(){
		int randomObject = UnityEngine.Random.Range(0, prefab.Length);
		int randomPos = UnityEngine.Random.Range(0, xAxis.Count);

		if(randomPos > xAxis.Count / 2){
			for(int i = 0,k = randomPos; i < 3; i++){
				Vector2 position = new Vector2(xAxis[k], 0);
				
				pool.SpawningObjects(prefab[randomObject].tag, position, prefab[randomObject].transform.rotation);
				if(pool == null){
					RestartCorutine(RoundFour().ToString());
				}
				k-=2;
			}
			yield return new WaitForSeconds(spawningTimeBetweenObjects);
			for(int i = 0; i < 2; i++){
				int k = randomPos;
				int j = randomPos - 4;
				Vector2 firstPosition = new Vector2(xAxis[k], 0);
				pool.SpawningObjects(prefab[randomObject].tag, firstPosition, prefab[randomObject].transform.rotation);
				if(pool == null){
					RestartCorutine(RoundFour().ToString());
				}
			
				Vector2 secondPosition = new Vector2(xAxis[j], 0);
				pool.SpawningObjects(prefab[randomObject].tag, secondPosition, prefab[randomObject].transform.rotation);
				if(pool == null){
					RestartCorutine(RoundFour().ToString());
				}
				yield return new WaitForSeconds(spawningTimeBetweenObjects);

			}
		}else if(randomPos < xAxis.Count / 2){
			for(int i = 0,k = randomPos; i < 3; i++){
				Vector2 position = new Vector2(xAxis[k], 0);
				
				pool.SpawningObjects(prefab[randomObject].tag, position, prefab[randomObject].transform.rotation);
				if(pool == null){
					RestartCorutine(RoundFour().ToString());
				}
				k+=2;
				
			}
			yield return new WaitForSeconds(spawningTimeBetweenObjects);
			for(int i = 0; i < 2; i++){
				int k = randomPos;
				int j = randomPos + 4;
				Vector2 firstPosition = new Vector2(xAxis[k], 0);
				pool.SpawningObjects(prefab[randomObject].tag, firstPosition, prefab[randomObject].transform.rotation);
				if(pool == null){
					RestartCorutine(RoundFour().ToString());
				}
			
				Vector2 secondPosition = new Vector2(xAxis[j], 0);
				pool.SpawningObjects(prefab[randomObject].tag, secondPosition, prefab[randomObject].transform.rotation);
				if(pool == null){
					RestartCorutine(RoundFour().ToString());
				}
				yield return new WaitForSeconds(spawningTimeBetweenObjects);

			}
		}

		yield return new WaitForSeconds(timeBetweenSpawns-0.3f);

		timer++;
		if(timer < 20){
			StartCoroutine(RoundFour());
		}else{
			StartCoroutine(RoundOne());
			timer = 0;
		}
		
	}

	//	ColorChangeEvent is a method for calling script ChangeColorEvent on prefabs and changing sprites(color) of a prifabs

	public void ColorChangeEvent(){
		ChangeColorEvent[] change = gameObject.GetComponentsInChildren<ChangeColorEvent>();

		for(int i = 0; i < change.Length; i++){
			change[i].ChangeColor(colors);
		}

	}

	public void RestartSpawner(){
		for(int i = 0; i < gameObject.transform.childCount; i++){
			transform.GetChild(i).gameObject.SetActive(false);
		}
	}

	private void SettingXaxis(){
		
		if(screenPosition.x < 2){
			xAxis.RemoveAt(12);
			xAxis.RemoveAt(11);
			xAxis.RemoveAt(10);
			xAxis.RemoveAt(2);
			xAxis.RemoveAt(1);
			xAxis.RemoveAt(0);
		}else if(screenPosition.x < 2.5){
			xAxis.RemoveAt(12);
			xAxis.RemoveAt(11);
			xAxis.RemoveAt(1);
			xAxis.RemoveAt(0);
		}else if(screenPosition.x < 3){
			xAxis.RemoveAt(12);
			xAxis.RemoveAt(0);
		}
		
	}

}
