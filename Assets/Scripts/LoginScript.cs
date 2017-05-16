using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class LoginScript : MonoBehaviour
{

	// Use this for initialization
	public InputField emailInput;
	public InputField passwordnput;

	public GameObject loginPanel;
	public GameObject MainMenuPanel;

	public void sendCredentials ()
	{
		WWWForm form = new WWWForm ();
		form.AddField ("email", emailInput.text);
		form.AddField ("password", passwordnput.text);
		//Hashtable headers = form.headers;
		byte[] rawData = form.data;
		string url = "https://meyespace-userservice.herokuapp.com/login";
		//string url = "http://localhost:3000/login";

		WWW www = new WWW (url, rawData);

		StartCoroutine (WaitForRequest (www));
	}

	IEnumerator WaitForRequest (WWW www)
	{
		yield return www;
		Debug.Log ("I came back boiiiii" + www);
		// check for errors
		if (www.error == null) {
			loginPanel.SetActive (false);
			MainMenuPanel.SetActive (true);
			Debug.Log ("WWW Ok!: " + www.text);

			LoginData loginData = JsonUtility.FromJson<LoginData> (www.text);
		
			GameDataController.gameDataController.gameData.statObj = new Stats ();
		
			GameDataController.gameDataController.gameData.userId = loginData.userId;
			GameDataController.gameDataController.gameData.country = loginData.country;
			GameDataController.gameDataController.gameData.token = loginData.token;

		} else {
			
			Debug.Log ("WWW Error: " + www.error);
		}    
	}


	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

public class LoginData
{
	public string token;
	public string userId;
	public string country;
}
