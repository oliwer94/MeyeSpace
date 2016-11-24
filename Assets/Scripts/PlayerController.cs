using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		audioSource = GetComponent<AudioSource> ();
	}

	public GameObject shot;
	public Transform turret;


	public float fireRate = 0.01f;
	public float nextFire = 0.0f;
	private AudioSource audioSource;
	public float yRotation = 5.0F;


	// Update is called once per frame
	void Update ()
	{		
		if (Input.GetKey (KeyCode.Space) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;

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
