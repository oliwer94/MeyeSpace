using UnityEngine;
using System.Collections;

public class RotateComponent : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		controlledByMouse = GameDataController.gameDataController.gameData.controlledByMouse;
		if (!controlledByMouse) {
			gp = new GazePoint ();
		}
		Debug.Log("controlledByMouse:" + controlledByMouse);

	}

	public float yRotation = 5.0F;

	private GazePoint gp;
	private bool controlledByMouse;

	void Update ()
	{
//		yRotation = getRotationChange ();
//		transform.eulerAngles = new Vector3 (0, yRotation, 0);


		Vector3 targetPos;
		if (controlledByMouse) 
		{
			targetPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		} 
		else 
		{
			targetPos = Camera.main.ScreenToWorldPoint (gp.getGazeCoordsToUnityWindowCoords());			
		}

		Vector2 nonDebilTargetPos = new Vector2 (targetPos.x, targetPos.z);
 		
	  	float angle = Mathf.Atan2(nonDebilTargetPos.y, nonDebilTargetPos.x) * Mathf.Rad2Deg;

		Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
		q.eulerAngles = new Vector3 (90, q.eulerAngles.y+90, q.eulerAngles.z);
		transform.rotation = Quaternion.Slerp (transform.rotation, q, Time.time * 0.058f);
	}


	/*
	float getRotationChange ()
	{
		Vector3 targetPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 nonDebilTargetPos = new Vector2 (targetPos.x, targetPos.z);
		Vector2 flatVector = new Vector2 (1, 0);
		float angle = Vector2.Angle (flatVector, nonDebilTargetPos);
		return angle;
	}*/
}
