using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderStartListener : MonoBehaviour {

	private Slider slider;
	public bool master;
	public bool music;
	public bool effects;
	public bool camera;

	// Use this for initialization
	void Start () {
		slider = gameObject.GetComponent<Slider> ();
		slider.onValueChanged.AddListener (delegate {
			ValueChanged ();
		});
			
	}
	
	public void ValueChanged()
	{
		if (master)
			setMasterVol ();
		if (music)
			setBackgroundMusicVol ();
		if (effects)
			setSoundEffectsVol ();
		if (camera)
			setCameraSize ();
			
	}

	public void setMasterVol()
	{
		GameDataController.gameDataController.gameData.masterVol = slider.value;
	}

	public void setBackgroundMusicVol()
	{
		GameDataController.gameDataController.gameData.backgroundMusicVol = slider.value;
	}
	public void setSoundEffectsVol()
	{
		GameDataController.gameDataController.gameData.soundEffectsVol = slider.value;
	}

	public void setCameraSize()
	{
		GameDataController.gameDataController.gameData.cameraSize = slider.value;
	}
}
