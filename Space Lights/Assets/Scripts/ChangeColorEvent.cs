using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//	ChangeColorEvent is attached to that is spawning and player when is used in change color event

public class ChangeColorEvent : MonoBehaviour {

	private SpriteRenderer renderer;

	void Start(){
		renderer = gameObject.GetComponent<SpriteRenderer>();		//	Take sprite renderer of the game object that is attached
	}

	//	Using switch to change sprite and set new tag on object
	public void ChangeColor(Sprite[] color){

		switch(gameObject.tag){
			case "Green":
				renderer.sprite = color[3];
				gameObject.tag = "Red";
			break;
			case "Red":
				renderer.sprite = color[2];
				gameObject.tag = "Purple";
			break;
			case "Blue":
				renderer.sprite = color[1];
				gameObject.tag = "Green";
			break;
			case "Yellow":
				renderer.sprite = color[0];
				gameObject.tag = "Blue";
			break;
			case "Purple":
				renderer.sprite = color[4];
				gameObject.tag = "Yellow";
			break;
		}
	}

	//	Method used only by player for changing color to itself
	public void ChangeColorPlayer(GameObject player){

		switch(player.tag){
			case "Green":
				renderer.color = Color.red;
				gameObject.tag = "Red";
			break;
			case "Red":
				renderer.color = Color.magenta;
				gameObject.tag = "Purple";
			break;
			case "Blue":
				renderer.color = Color.green;
				gameObject.tag = "Green";
			break;
			case "Yellow":
				renderer.color = Color.blue;
				gameObject.tag = "Blue";
			break;
			case "Purple":
				renderer.color = Color.yellow;
				gameObject.tag = "Yellow";
			break;
		}
	}
}
