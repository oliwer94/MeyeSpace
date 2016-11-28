using UnityEngine;
using System.Collections;

public class UpdateMainMenuMusicVol : MonoBehaviour {

	public GameObject menuObject;

	// Use this for initialization
	void Start () {
	
		float masterVol = GameDataController.gameDataController.gameData.masterVol;
		float musicVol = GameDataController.gameDataController.gameData.backgroundMusicVol;

		SetMusicVol(masterVol > musicVol ? musicVol : masterVol);
	}

	public void UpdateMusicVol()
	{
		float masterVol = GameDataController.gameDataController.gameData.masterVol;
		float musicVol = GameDataController.gameDataController.gameData.backgroundMusicVol;

		SetMusicVol(masterVol > musicVol ? musicVol : masterVol);
	}

	public void SetMusicVol(float value)
	{
		AudioSource asource = menuObject.GetComponent<AudioSource> ();
		asource.volume = value;
	}
}
