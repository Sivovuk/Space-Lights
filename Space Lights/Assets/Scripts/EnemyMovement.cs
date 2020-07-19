using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//	This Class regulate movement of the enemy and speed

public class EnemyMovement : MonoBehaviour {

	public float speed;

	void Update () {
		
		transform.Translate(Vector2.down * Time.deltaTime * speed);

	}
}
