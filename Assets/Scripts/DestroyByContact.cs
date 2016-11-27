using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {


	public int scoreValue;
	private GameController gameController;


	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary") {
			return;
		}
		Instantiate (gameController.explosion, transform.position, transform.rotation);

		if (other.tag == "Player") {

			Instantiate (gameController.playerExplosion, other.transform.position, other.transform.rotation);
			//destroys player sprite
			Destroy (other.transform.parent.gameObject);
			//destroys turret
			Destroy (gameController.turret);

			gameController.GameOver ();		
		}

		if (other.tag == "Bolt") {
			gameController.AddScore (scoreValue);
		}
		//destroys the gameObject that it collided with so laserBolt/Player (hitbox)
		Destroy (other.gameObject);
		//destroys itself (asteroid)
		Destroy (gameObject);		
	}

}