using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;


public class GameDataController : MonoBehaviour {


	public static GameDataController gameDataController;

//	public HighScores highScores;
//	public LeaderBoard leaderBoard;

	public GameData gameData;

	// Use this for initialization
	void Awake () {

		if (gameDataController == null) 
		{			
			Debug.Log ("I CREATED A NEWONE");
			DontDestroyOnLoad (gameObject);
			gameDataController = this;		
			this.gameData = new GameData ();
			Load ();
		}
		else if (gameDataController != null)
		{
			Destroy (gameObject);
		}
	}

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream fs = File.Create (Application.persistentDataPath + "/playerInfo.dat");

	
		bf.Serialize (fs, gameData);
		fs.Close ();
	}

	public void Load()
	{
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
		
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream fs = File.Open(Application.persistentDataPath + "/playerInfo.dat",FileMode.Open);
		
			this.gameData = (GameData) bf.Deserialize (fs);

			fs.Close ();
		}
	}
}
