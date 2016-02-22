using UnityEngine;
using System.Collections;

public class MainButtons : MonoBehaviour {

	public void StartPressed(){

		//PlayerPrefs.DeleteAll();
		int oldStage = PlayerPrefs.GetInt ("stage",0);

		Debug.Log (oldStage);

		if (oldStage > 0) {
			Application.LoadLevel ("InGame");
		} else {
			Application.LoadLevel ("Tutorial_Scene");
		}


	}
}
