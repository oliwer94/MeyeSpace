using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetValue : MonoBehaviour {

	// Use this for initialization
	public Text text;
	public int indexInHighScoresList;
	public bool score;

	void Start () 
	{
		text = GetComponent<Text> ();
		UpdateText ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateText ();
	}

	private void UpdateText()
	{
		if (GameDataController.gameDataController.gameData.leaderBoard != null && GameDataController.gameDataController.gameData.leaderBoard.Count > indexInHighScoresList ) {

			if (score)
			{
				text.text = GameDataController.gameDataController.gameData.leaderBoard [indexInHighScoresList].score.ToString ();
			}
			else
			{
				text.text = GameDataController.gameDataController.gameData.leaderBoard [indexInHighScoresList].name.ToString ();
			}

		} else 
		{
			if (score)
			{
				text.text = "NaN";
			}
			else
			{
				text.text = "unknow";
			}
		}
	}
}
