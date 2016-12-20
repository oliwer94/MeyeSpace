using System.Collections.Generic;
using System;

[Serializable]
public class GameData
{	
	public float backgroundMusicVol;
	public float soundEffectsVol;
	public float masterVol;

	public int difficulityLevel;
	public bool controlledByMouse = true;

	public float cameraSize;

	public List<LeaderBoardEntry> leaderBoard = new List<LeaderBoardEntry> ();

	public void AddNewScore (string nameValue, int value)
	{		
		LeaderBoardEntry entry = new LeaderBoardEntry (nameValue, value);

		leaderBoard.Add(entry);	
		leaderBoard.Sort((s1, s2) => -1 * s1.score.CompareTo(s2.score));
		if (leaderBoard.Count > 5) {
			leaderBoard = leaderBoard.GetRange (0, 5);
		}
		GameDataController.gameDataController.Save ();
	}

}

[Serializable]
public class LeaderBoardEntry
{
	public string name;
	public int score;

	public LeaderBoardEntry (string nameValue,int value)
	{
		this.name = nameValue;
		this.score = value;
	}
}
