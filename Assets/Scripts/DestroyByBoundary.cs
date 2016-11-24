using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	void OnTriggerExit(Collider other)
	{
		if(other.transform.position.x < -21 || other.transform.position.x > 21 || other.transform.position.z > 11 || other.transform.position.z < -11)
		Destroy (other.gameObject);
	}
}
