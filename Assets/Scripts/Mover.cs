using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;
	Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		rigidBody.velocity =  transform.forward * speed; 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
