using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetSliders : MonoBehaviour {

	public Slider masterSlider;
	public Slider musicSlider;
	public Slider effectsSlider;

	public void SetSlider()
	{
		masterSlider.value = GameDataController.gameDataController.gameData.masterVol;	
		musicSlider.value = GameDataController.gameDataController.gameData.backgroundMusicVol;
		effectsSlider.value = GameDataController.gameDataController.gameData.soundEffectsVol;
	}

}
