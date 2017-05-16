using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class sendStat : MonoBehaviour {

	public sendStat()
	{}
	
	public void sendStats (int sceneID) {

		WWWForm form = new WWWForm();
		form.AddField("statObj", JsonUtility.ToJson(GameDataController.gameDataController.gameData.statObj));
		byte[] rawData = form.data;
		string url = "https://meyespace-statservice.herokuapp.com/stats/"+GameDataController.gameDataController.gameData.userId;
		//string url = "http://localhost:5000/stats/"+GameDataController.gameDataController.gameData.userId;

		Debug.Log ("sending data to here "+ url);

		form.headers.Add("Cookie",GameDataController.gameDataController.gameData.token);
		WWW www = new WWW(url, rawData,form.headers);
		StartCoroutine(WaitForRequest(www,sceneID));
	}

	IEnumerator WaitForRequest(WWW www,int sceneID)
	{
		yield return www;

		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.text);

			SceneManager.LoadScene (sceneID);
			GameDataController.gameDataController.gameData.statObj = new Stats ();

		} else {

			Debug.Log("WWW Error: "+ www.error);
		}

	}    
}
