using UnityEngine;
using System.Collections;

public class InGameInfo : MonoBehaviour {


	public int timer;
	public int currentStage=1, oldStage;
	public bool onFirstLoad = true, onSave = true, onLoad = true;

	void Start(){
		// PlayerPrefs test tool
		PlayerPrefs.DeleteAll();
		oldStage = PlayerPrefs.GetInt ("stage",0);
	}
	void Update(){
		timer = (int)Time.time;

		if (oldStage > 0) {
			onFirstLoad = false;
		}

		if (!onFirstLoad) {
			if (onLoad){
				GameObject.Find ("GameInfo").GetComponent<GameSaveLoad> ().LoadGame ();
				onLoad = false;
			}
		}

		if (timer % 10 == 1) { //10초 저 장
			if (onSave) {
				GameObject.Find ("GameInfo").GetComponent<GameSaveLoad> ().SaveGame ();
				onSave = false;
			}
		}else{
			onSave = true;
		}

	}
}
