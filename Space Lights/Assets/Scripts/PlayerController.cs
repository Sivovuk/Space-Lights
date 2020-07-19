using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//	PlayerController class as name of the class says is used for controlling player

public class PlayerController : MonoBehaviour {

	public float speed;		//	How fast player is moving

	private float x;
	private float y;
	private Vector2 newPos;
	private Vector2 screenPosition;

	void Start(){
		x = Screen.width;
		y = Screen.height;

		newPos = new Vector2(x, y);

		screenPosition = Camera.main.ScreenToWorldPoint(newPos);
	}

	void Update(){
		

		if(Input.touchCount > 0){
			Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			if(touchPos.x > 0 && transform.position.x < screenPosition.x){
				transform.Translate(Vector2.right * Time.deltaTime * speed);				//	Go right
			} 
			if(touchPos.x < 0 && transform.position.x > -screenPosition.x){
				transform.Translate(Vector2.left * Time.deltaTime * speed);					//	Go left
			}

		}
	}

}