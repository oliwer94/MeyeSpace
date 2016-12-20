using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetSliders : MonoBehaviour {

	public Slider masterSlider;
	public Slider musicSlider;
	public Slider effectsSlider;
	public Slider cameraSizeSlider;

	public void SetAudioSliders()
	{
		masterSlider.value = GameDataController.gameDataController.gameData.masterVol;	
		musicSlider.value = GameDataController.gameDataController.gameData.backgroundMusicVol;
		effectsSlider.value = GameDataController.gameDataController.gameData.soundEffectsVol;
	}

	public void SetCameraSlider()
	{
		cameraSizeSlider.value = GameDataController.gameDataController.gameData.cameraSize;
	}
}
