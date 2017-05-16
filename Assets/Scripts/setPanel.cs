using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class setPanel : MonoBehaviour {

	public GameObject LoginPanel;
	public GameObject MainMenuPanel;

	// Use this for initialization
	void Start () {
		if (GameDataController.gameDataController.gameData.token != "" && GameDataController.gameDataController.gameData.token != null) {
			LoginPanel.SetActive (false);
			MainMenuPanel.SetActive (true);
		} else {
			LoginPanel.SetActive (true);
			MainMenuPanel.SetActive (false);
		}
	}

	// Update is called once per frame
	void Update () {
		
//		if (GameDataController.gameDataController.gameData.token != "" && GameDataController.gameDataController.gameData.token != null) {
//			if (LoginPanel.activeSelf) {
//				LoginPanel.SetActive (false);
//				MainMenuPanel.SetActive (true);
//			}
//		} else {
//			LoginPanel.SetActive (true);
//			MainMenuPanel.SetActive (false);
//		}
	}
}
