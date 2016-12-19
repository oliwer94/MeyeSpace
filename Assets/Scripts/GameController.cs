using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public GameObject hazard2;
	public GameObject hazard3;

	public GameObject MediPack;
	public GameObject Skull;
	public GameObject Lightning;
	public GameObject Bomb;


	public GameObject turret;
	public GameObject explosion;
	public GameObject playerExplosion;
	public GameObject targetingLine;

	public Vector3 spawnValues;
	private Vector3 spawnPosition;

	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GameObject infoPanel;


	public int lives;

	public InputField nameInput;

	public Text scoreTextOnPanel;
	public Text timerTextOnPanel;

	public GameObject gameOverPanel;

	private bool gameOver;
	private bool restart;

	public GUIText scoreTextOnGameScreen;
	public GUIText livesTextOnGameScreen;
	private bool isFireRateBoosted;
	private int numberOfFireRate;
	private float timeOfexpiration;
	public int dropRate;
	public float fireRate = 0.5f; //0.413993
	private float baseFireRate;
	private int score;

	// Use this for initialization
	void Start () {

		SetInGameSoundVol ();

		switch (GameDataController.gameDataController.gameData.difficulityLevel) {

		case 0:
			hazardCount = (int)Constants.asteroidSpawnNumber.easy;
			fireRate = ((float)Constants.fireRate.easy) / 100;
			dropRate = (int)Constants.powerUpPercentage.easy;
			spawnWait = ((float)Constants.spawnWait.easy)/100;
			break;
		case 1:
			hazardCount = (int)Constants.asteroidSpawnNumber.medium;
			fireRate = ((float)Constants.fireRate.medium)/100;
			dropRate = (int)Constants.powerUpPercentage.medium;
			spawnWait = ((float)Constants.spawnWait.medium)/100;
			break;
		case 2:
			hazardCount =(int) Constants.asteroidSpawnNumber.hard;
			fireRate = ((float)Constants.fireRate.hard)/100;
			dropRate = (int)Constants.powerUpPercentage.hard;
			spawnWait = ((float)Constants.spawnWait.hard)/100;
			break;
		}
		baseFireRate = fireRate;
		isFireRateBoosted = false;
		gameOver = false;
		restart = false;
		lives = 3;
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}


	//Spawn waves of asteroids
	IEnumerator SpawnWaves()
	{		

		yield return new WaitForSeconds (startWait);

		while (true)
		{
			

			for (int i = 0; i < hazardCount; i++) 
			{
				if (gameOver) {	
					break;
				}
			
				int random = Random.Range (0, 4);
				Quaternion spawnRotation = Quaternion.identity;

				switch (random) {
				//spawns top edge
				case 0:
					spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					spawnRotation.eulerAngles = new Vector3 (0,0f+ Random.Range(-30,30), 0);
					break;

				//spawns bottom edge
				case 1:
					spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, -spawnValues.z);
					spawnRotation.eulerAngles = new Vector3 (0, 180f+ Random.Range(-30,30), 0);	
					break;

				//spawns right edge
				case 2:
					spawnPosition = new Vector3 (spawnValues.x + 4.0f, spawnValues.y, Random.Range (-spawnValues.z + 2, spawnValues.z - 2));
					spawnRotation.eulerAngles = new Vector3 (0, 90f+ Random.Range(-30,30), 0);
					break;

				//spawns left edge
				case 3:
					spawnPosition = new Vector3 (-spawnValues.x - 4.0f, spawnValues.y, Random.Range (-spawnValues.z + 2, spawnValues.z - 2));
					spawnRotation.eulerAngles = new Vector3 (0, -90f + Random.Range(-30,30), 0);
					break;
				}

				if (Random.Range (0, 1000) < dropRate) 
				{
					switch (Random.Range (0, 4)) {
					case 0:
						Instantiate (Bomb, spawnPosition, spawnRotation);
						break;
					case 1:
						Instantiate (Skull, spawnPosition, spawnRotation);
						break;
					case 2:
						Instantiate (MediPack, spawnPosition, spawnRotation);
						break;
					case 3:
						Instantiate (Lightning, spawnPosition, spawnRotation);
						break;
					}

				} else {

					switch (Random.Range (0, 3)) {
					case 0:
						Instantiate (hazard, spawnPosition, spawnRotation);
						break;
					case 1:
						Instantiate (hazard2, spawnPosition, spawnRotation);
						break;
					case 2:
						Instantiate (hazard3, spawnPosition, spawnRotation);
						break;
					}
				
				}
				yield return new WaitForSeconds (spawnWait);
			}

			if (gameOver) {
				break;
			} else {
				
				hazardCount += 50;
				spawnWait -= 0.001f;
			}

			yield return new WaitForSeconds (waveWait);
		}
	}

	void Update()
	{
		if (restart) {
		
			//if (Input.GetKeyDown (KeyCode.R)) {
				Scene scene = SceneManager.GetActiveScene (); 
				SceneManager.LoadScene (scene.name);
			//}
		}

		if(Time.time > timeOfexpiration && isFireRateBoosted)
		{
			infoPanel.SetActive (false);
			isFireRateBoosted = false;
			this.fireRate = baseFireRate;
		}
			
		if (isFireRateBoosted) {
			
			this.timerTextOnPanel.text = "Time left: " + (Mathf.Round((this.timeOfexpiration - Time.time) *10) / 10).ToString();
		}
	}

	public void IncreaseFireRate()
	{
		infoPanel.SetActive (true);
		isFireRateBoosted = true;
		this.fireRate -= 0.05f;
		this.timeOfexpiration = Time.time +  10f;
		Debug.Log (Time.time);
		Debug.Log (this.timeOfexpiration);

	}

	public void IncreaseLives()
	{
		this.lives++;
		livesTextOnGameScreen.text = "Lives: " + lives;
	}

	public void DecreaseLives()
	{
		this.lives--;
		livesTextOnGameScreen.text = "Lives: " + lives;
	}

	public void GameOver()
	{
		infoPanel.SetActive (false);
		isFireRateBoosted = false;
		this.fireRate = baseFireRate;
		gameOverPanel.SetActive (true);
		gameOver = true;
		scoreTextOnPanel.text = scoreTextOnGameScreen.text;
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore () {

		scoreTextOnGameScreen.text = "Score: " + score;
	}

	public void RestartGame()
	{
		restart = true;
	}

	public void AddScoreToLeaderBoard()
	{
		if (GameDataController.gameDataController != null) 
		{
			if (GameDataController.gameDataController.gameData.leaderBoard != null) 
			{
				if (GameDataController.gameDataController.gameData.leaderBoard != null) 
				{
					GameDataController.gameDataController.gameData.AddNewScore (nameInput.textComponent.text,score);
				} 
				else 
				{
					Debug.Log ("Scores is NULL");
				}
			} 
			else
			{
				Debug.Log ("LeaderBoard is NUll");
			}
		}	
		else
		{
			Debug.Log ("gameData is NULL");
		}
	}

	public void SetInGameSoundVol()
	{

		float masterVol = GameDataController.gameDataController.gameData.masterVol;
		float musicVol = GameDataController.gameDataController.gameData.backgroundMusicVol;
		float effectsVol = GameDataController.gameDataController.gameData.soundEffectsVol;

		SetMusicVol(masterVol > musicVol ? musicVol : masterVol);
		SetEffectVol(masterVol > effectsVol ? effectsVol : masterVol);
	}
	public void SetMusicVol(float value)
	{
		AudioSource asource = GetComponent<AudioSource> ();
		asource.volume = value;
	}
	public void SetEffectVol(float value)
	{
		AudioSource asource = turret.GetComponent<AudioSource> ();
		asource.volume = value;
		asource = explosion.GetComponent<AudioSource> ();
		asource.volume = value;
		asource = playerExplosion.GetComponent<AudioSource> ();
		asource.volume = value;
	}
}
