using UnityEngine;
using System.Collections;

public class GameSaveLoad : MonoBehaviour {

	float currentPosition_x,currentPosition_y,currentPosition_z;
	int currentStage;

	void start(){

		SaveGame();
		LoadGame();
	}
		

	void SaveGame()
	{

		PlayerPrefs.SetFloat("Position_x", currentPosition_x);
		PlayerPrefs.SetFloat("Position_y", currentPosition_y);
		PlayerPrefs.SetFloat("Position_z", currentPosition_z);
	
		string _tmpStr = null;
		for (int code = 0; code < Config.itemName.Length; code ++) {   // 사용가능 아이템 검사
			if (Config.canUseItem[code]) {
				_tmpStr = code + ",";
			}
		}
		PlayerPrefs.SetString("MyItems", _tmpStr); // 사용가능 아이템  string 저장

		currentStage = GameObject.Find ("GameInfo").GetComponent<GameInfo> ().currentStage;
		PlayerPrefs.SetInt("stage", currentStage);

	}

	void LoadGame()
	{
		float tankPosition_x  = PlayerPrefs.GetFloat("Position_x");
		float tankPosition_y  = PlayerPrefs.GetFloat("Position_y");
		float tankPosition_z  = PlayerPrefs.GetFloat("Position_z");
		GameObject.Find ("Tank2").transform.position.Set (tankPosition_x, tankPosition_y, tankPosition_z);
			
		string[] myItemCodes = PlayerPrefs.GetString ("Myitems").Split (',');

		for (int i = 0; i < myItemCodes.Length; i++) {
			Config.canUseItem [int.Parse(myItemCodes[i])] = true;
		}

		currentStage = PlayerPrefs.GetInt ("stage");
		GameObject.Find ("GameInfo").GetComponent<GameInfo> ().currentStage = currentStage;
	}
}
