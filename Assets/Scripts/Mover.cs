using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;
	Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();

		if (gameObject.tag != "Bolt") {
			switch (GameDataController.gameDataController.gameData.difficulityLevel) {
			case 0:
				speed = (float)Constants.Asteroidspeed.easy;
				break;
			case 1:
				speed = (float)Constants.Asteroidspeed.medium;
				break;
			case 2:
				speed = (float)Constants.Asteroidspeed.hard;
				break;
			}
		}

		rigidBody.velocity = transform.forward * speed; 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
