using UnityEngine;
using System.Collections;

public class GameSaveLoad : MonoBehaviour {

	float currentPosition_x,currentPosition_y,currentPosition_z;
	int currentStage;
		

	public void SaveGame()
	{

		currentPosition_x = GameObject.Find ("Tank2").transform.position.x;
		currentPosition_y = GameObject.Find ("Tank2").transform.position.y;
		currentPosition_z = GameObject.Find ("Tank2").transform.position.z;

		PlayerPrefs.SetFloat("Position_x", currentPosition_x);
		PlayerPrefs.SetFloat("Position_y", currentPosition_y);
		PlayerPrefs.SetFloat("Position_z", currentPosition_z);
	
		string _tmpStr = null;
		for (int code = 0; code < Config.itemName.Length; code ++) {   // 사용가능 아이템 검사
			if (Config.canUseItem[code]) {
				_tmpStr += code + ",";
			}
		}
		PlayerPrefs.SetString("MyItems", _tmpStr); // 사용가능 아이템  string 저장

		_tmpStr = null;
		for (int code = 0; code < Config.objectName.Length; code ++) {  
			if (Config.canUseObject[code]) {
				_tmpStr += code + ","; // itemCode를 ' , ' 로 구분해서 저장
			}
		}
		PlayerPrefs.SetString("MyObjects", _tmpStr); 

		currentStage = GameObject.Find ("GameInfo").GetComponent<GameInfo> ().currentStage;
		PlayerPrefs.SetInt("stage", currentStage);

	}

	public void LoadGame()
	{
		float tankPosition_x  = PlayerPrefs.GetFloat("Position_x");
		float tankPosition_y  = PlayerPrefs.GetFloat("Position_y");
		float tankPosition_z  = PlayerPrefs.GetFloat("Position_z");

		GameObject.Find ("Tank2").transform.position.Set (tankPosition_x, tankPosition_y, tankPosition_z);
			
		string[] myItemCodes = PlayerPrefs.GetString ("Myitems").Split (',');

		for (int i = 0; i < myItemCodes.Length; i++) {
			Config.canUseItem [int.Parse(myItemCodes[i])] = true;
		}

		string[] myObjectCodes = PlayerPrefs.GetString ("MyObjects").Split (',');

		for (int i = 0; i < myObjectCodes.Length; i++) {
			Config.canUseObject [int.Parse(myObjectCodes[i])] = true;
		}

		currentStage = PlayerPrefs.GetInt ("stage");
		GameObject.Find ("GameInfo").GetComponent<GameInfo> ().currentStage = currentStage;
	}
}
