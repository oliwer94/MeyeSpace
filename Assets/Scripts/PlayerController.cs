using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{


	public GameObject shot;
	public Transform turret;



	public float nextFire = 0.0f;
	private AudioSource audioSource;
	public GameController gameController;

	// Use this for initialization
	void Start ()
	{
		audioSource = GetComponent<AudioSource> ();

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}





	// Update is called once per frame
	void Update ()
	{		
		if (Time.time > nextFire) {
			nextFire = Time.time + gameController.fireRate;

			Vector3 wayToGo = new Vector3 (0, turret.rotation.eulerAngles.y, turret.rotation.eulerAngles.z);
			Quaternion q = turret.rotation;
			q.eulerAngles = wayToGo;

			Instantiate (shot, turret.position, q);
			audioSource.Play ();
		}



//		Vector3 targetPos = getTargetPosition ();
//	
//		yRotation += Input.GetAxis("Horizontal");
//
//		transform.eulerAngles = new Vector3(0, yRotation, 0);

		transform.eulerAngles = new Vector3 (90, turret.rotation.eulerAngles.y, 0);
	}
}
