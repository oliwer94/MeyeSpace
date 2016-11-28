using UnityEngine;
using System.Collections;
using EyeTribe.ClientSdk;
using EyeTribe.ClientSdk.Data;

public class GazePoint : IGazeListener 
{
	private double gX;
	private double gY;

	public GazePoint()
	{
		// Connect client
		GazeManager.Instance.Activate(GazeManager.ApiVersion.VERSION_1_0, GazeManager.ClientMode.Push);

		// Register this class for events
		GazeManager.Instance.AddGazeListener(this);

		// Thread.Sleep(5000); // simulate app lifespan (e.g. OnClose/Exit event)

		// Disconnect client
		// GazeManager.Instance.Deactivate();
	}

	public void OnGazeUpdate(GazeData gazeData)
	{
		gX = gazeData.SmoothedCoordinates.X;
		gY = gazeData.SmoothedCoordinates.Y;
		// Move point, do hit-testing, log coordinates etc.
	}

	public Vector3 getPosition() 
	{
		return new Vector3 ((float)this.gX, (float)this.gY, 0.0f);
	}

	public  Vector3 getGazeCoordsToUnityWindowCoords()
	{
		double rx = gX * ((double)Screen.width / GazeManager.Instance.ScreenResolutionWidth);
		double ry = (GazeManager.Instance.ScreenResolutionHeight - gY) * ((double)Screen.height / GazeManager.Instance.ScreenResolutionHeight);
		return new Vector3((float)rx,(float) ry,0.0f);
	}
}
