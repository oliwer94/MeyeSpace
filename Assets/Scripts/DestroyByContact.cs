using UnityEngine;
using System.Collections;


public class DestroyByContact : MonoBehaviour
{


	public int scoreValue;
	private GameController gameController;


	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary") {
			return;
		}

		Instantiate (gameController.explosion, transform.position, transform.rotation);

		if (other.tag == "Player") {

			SpecialCases (other);

			Instantiate (gameController.playerExplosion, other.transform.position, other.transform.rotation);
		}

		if (other.tag == "Bolt") {

			SpecialCases (other);

			//destroys the gameObject that it collided with so laserBolt/Player (hitbox)
			Destroy (other.gameObject);
		}

		//destroys itself (asteroid)
		Destroy (gameObject);		
	}

	//destroys player sprites
	private void GameOver(Collider other)
	{
		//ship rigidbody 
		if(other.transform.parent != null)
		Destroy (other.transform.parent.gameObject);
		//destroys turret
		Destroy (gameController.turret);
		Destroy (gameController.targetingLine);
		//destroys the gameObject that it collided with so laserBolt/Player (hitbox)
		Destroy (other.gameObject);
		gameController.GameOver ();		
	}

	private void SpecialCases(Collider other)
	{

		if (gameObject.tag == "MediPack")
		{
			gameController.IncreaseLives ();
		}
		if (gameObject.tag == "Lightning") 
		{
			gameController.IncreaseFireRate ();
		}
		if( gameObject.tag == "Skull"&& other.tag == "Player")
		{
			gameController.DecreaseLives ();
		}
		if (gameObject.tag == "Bomb") 
		{
			RaycastHit[] hits = Physics.SphereCastAll (new Ray (gameObject.transform.position,gameObject.transform.position*5F) , 5.0f);

			for (int i = 0; i < hits.Length; i++) {
				GameObject objectInRange = hits [i].collider.gameObject;

				if (objectInRange.tag == "Asteroid") {
					
					Destroy (objectInRange);
					Instantiate (gameController.explosion, objectInRange.transform.position,objectInRange.transform.rotation);
				}
			}
		}
		if(gameObject.tag == "Asteroid" && other.tag == "Player")
		{
			gameController.DecreaseLives ();
		}

		gameController.AddScore (scoreValue);

		if (gameController.lives == 0) 
		{
			//destroys player sprites
			GameOver (other);
		}
	}
}