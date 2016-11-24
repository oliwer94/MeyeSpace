using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

	// Use this for initialization

	private Rigidbody rigidBody;
	public float tumble;

	void Start () {
	
		rigidBody = GetComponent<Rigidbody> ();

		rigidBody.angularVelocity = Random.insideUnitSphere * tumble;
	}


	// Update is called once per frame
	void Update () {
	
	}
}
