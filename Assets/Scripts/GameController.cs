using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject hazard;

	public GameObject turret;
	public Vector3 spawnValues;
	private Vector3 spawnPosition;

	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText gameOverText;
	public GUIText restartText;

	private bool gameOver;
	private bool restart;

	public GUIText scoreText;
	private int score;

	// Use this for initialization
	void Start () {

		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";

		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	//TODO: calculate angles properly.
	//Spawn waves of asteroids
	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);

		while (true)
		{
			for (int i = 0; i < hazardCount; i++) {
			
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

				Instantiate (hazard, spawnPosition, spawnRotation);

				if (gameOver) {

					restartText.text = "Press 'R' for Restart";
					restart = true;
					break;
				}

				yield return new WaitForSeconds (spawnWait);
			}

			if (gameOver) {

				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
			yield return new WaitForSeconds (waveWait);


		}

	}

	void Update()
	{
		if (restart) {
		
			if (Input.GetKeyDown (KeyCode.R)) {
				Scene scene = SceneManager.GetActiveScene(); 
				SceneManager.LoadScene(scene.name);
			}
		}
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over";
		gameOver = true;
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore () {

		scoreText.text = "Score: " + score;
	}
}
