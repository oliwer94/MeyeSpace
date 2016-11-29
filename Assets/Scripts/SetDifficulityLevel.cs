using UnityEngine;
using System.Collections;

public class SetDifficulityLevel : MonoBehaviour {

	public void SetDiff(int level)
	{
		GameDataController.gameDataController.gameData.difficulityLevel = level;
	}
}
