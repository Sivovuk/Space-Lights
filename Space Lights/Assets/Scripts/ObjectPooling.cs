using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour {

	//	Class Pool storage information about object that will be creted on start
	[System.Serializable]
	public class Pool{
		public string tag;
		public GameObject prefab;
		public int numberToSpawn;
	}

	//	Instance used in other skripts that not conected with this one
	#region Singleton
	public static ObjectPooling Instance;
	
	private void Awake(){
		Instance = this;
	}
	#endregion

	public Dictionary<string, Queue<GameObject>> objectPoolDictionary; 	//	Where objects are placed when been created
	public List<Pool> numberOfObjects;		//	List using class Pool to get more information about object that is created

	//	On very start we Instantiate evry object that is need ti be and added to Dictionary

	void Start () {
		objectPoolDictionary = new Dictionary<string, Queue<GameObject>>();

		foreach (Pool obstacle in numberOfObjects){
			Queue<GameObject> objectPool = new Queue<GameObject>();

			for(int i = 0; i < obstacle.numberToSpawn; i++){

				GameObject spawn = Instantiate(obstacle.prefab);
				spawn.transform.parent = gameObject.transform;
				spawn.SetActive(false);
				objectPool.Enqueue(spawn);
				
			}
			objectPoolDictionary.Add(obstacle.prefab.tag, objectPool);
		}
	}

	//	SpawningObjects method is called by spawner to activate object from Dictionary and return that same object with new position and rotation

	public GameObject SpawningObjects(string objectTag, Vector2 position, Quaternion rotation){

	
		GameObject objectToSpawn = objectPoolDictionary[objectTag].Dequeue();

		objectToSpawn.SetActive(true);
		objectToSpawn.transform.localPosition = position;
		objectToSpawn.transform.localRotation = rotation;

		objectPoolDictionary[objectTag].Enqueue(objectToSpawn);
		
		return objectToSpawn;
		
	}

}
