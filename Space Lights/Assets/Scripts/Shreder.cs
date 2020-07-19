using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//	This class have one job and that is to deactivate object on method OnTriggerEnter2D and is a attached to Shreder GameObject

public class Shreder : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){
		collider.gameObject.SetActive(false);
	}
}
