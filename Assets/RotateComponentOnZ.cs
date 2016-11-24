using UnityEngine;
using System.Collections;

public class RotateComponentOnZ : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	public float rotationSpeed;

	// Update is called once per frame
	void Update () {
		transform.eulerAngles += new Vector3 (0, 0, rotationSpeed);
	}
}
