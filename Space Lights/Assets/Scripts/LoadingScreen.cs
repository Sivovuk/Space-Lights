using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//	LoadingScreen class is used only on SplashScreen for rotation player icon and loading GameMenu scene

public class LoadingScreen : MonoBehaviour {

	public string SceneName;

	private float rotationZ;
	
	void Start(){
		StartCoroutine(LoadStartScene());
	}

	void Update () {
		transform.eulerAngles = new Vector3(0,0,rotationZ);
		rotationZ -= 5f;
	}

	IEnumerator LoadStartScene(){
		yield return new WaitForSeconds(2);

		SceneManager.LoadScene(SceneName);

	}
}
