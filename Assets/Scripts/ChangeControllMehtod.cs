using UnityEngine;
using System.Collections;

public class ChangeControllMehtod : MonoBehaviour {

	public void SetControllToMouse()
	{
		GameDataController.gameDataController.gameData.controlledByMouse = true;
	}
	public void SetControllToEyeTracker()
	{
		GameDataController.gameDataController.gameData.controlledByMouse = false;
	}
}
