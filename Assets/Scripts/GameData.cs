using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

	[NonSerialized]
	public string userId = "";
	[NonSerialized]
	public string userName = "";

	[NonSerialized]
	public string country = "";

	[NonSerialized]
	public string token = "";

	[NonSerialized]
	public Stats statObj = new Stats();

	public void AddNewScore (string nameValue, int value)
	{		
		LeaderBoardEntry entry = new LeaderBoardEntry (nameValue, value);

		leaderBoard.Add (entry);	
		leaderBoard.Sort ((s1, s2) => -1 * s1.score.CompareTo (s2.score));
		if (leaderBoard.Count > 5) {
			leaderBoard = leaderBoard.GetRange (0, 5);
		}
		GameDataController.gameDataController.Save ();
	}
}

public class Stats 
{
	public float mostSkullCountInOneLife = 0;
	public float mostSkullCountInOneGame = 0;
	public float totalSkullCount = 0;
	public float mostLightningCountInOneLife = 0;
	public float mostLightningCountInOneGame = 0;
	public float totalLightningCount = 0;
	public float mostMediKitCountInOneLife = 0;
	public float mostMediKitCountInOneGame = 0;
	public float totalMediKitCount = 0;
	public float mostBombCountInOneLife = 0;
	public float mostBombCountInOneGame = 0;
	public float totalBombCount = 0;
	public float mostAsteroidsDestroyedInOneLife = 0;
	public float mostAsteroidsDestroyedInOneGame = 0;
	public float totalAsteroidsDestroyed = 0;
	public float mostLivesLostInOneGame = 0;
	public float totalLivesLost = 0;
	public float mostScoreInOneLife = 0;
	public float mostScoreInOneGame = 0;
	public float totalScoreEarned = 0;
	public float longestGame = 0;
	public float timePlayedTotal = 0;
	public List<int> scores = new List<int> ();
}

[Serializable]
public class LeaderBoardEntry
{
	public string name;
	public int score;

	public LeaderBoardEntry (string nameValue, int value)
	{
		this.name = nameValue;
		this.score = value;
	}
}
