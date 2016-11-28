using UnityEngine;
using System.Collections;

public class RotateComponent : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	//	gp = new GazePoint();
	}

	public float yRotation = 5.0F;

	private GazePoint gp;

	void Update ()
	{
//		yRotation = getRotationChange ();
//		transform.eulerAngles = new Vector3 (0, yRotation, 0);



		//Vector3 targetPos = Camera.main.ScreenToWorldPoint (gp.getGazeCoordsToUnityWindowCoords());
		Vector3 targetPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 nonDebilTargetPos = new Vector2 (targetPos.x, targetPos.z);
 		//Vector2 flatVector = new Vector2 (transform.eulerAngles.x, transform.eulerAngles.z);

	  	float angle = Mathf.Atan2(nonDebilTargetPos.y, nonDebilTargetPos.x) * Mathf.Rad2Deg;

		Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
		q.eulerAngles = new Vector3 (90, q.eulerAngles.y+90, q.eulerAngles.z);
		transform.rotation = Quaternion.Slerp (transform.rotation, q, Time.time * 0.058f);
	}



	float getRotationChange ()
	{
		Vector3 targetPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 nonDebilTargetPos = new Vector2 (targetPos.x, targetPos.z);
		Vector2 flatVector = new Vector2 (1, 0);
		float angle = Vector2.Angle (flatVector, nonDebilTargetPos);
		return angle;
	}
}
