using UnityEngine;
using System.Collections;
using System;

public class GameSaveLoad : MonoBehaviour {

	float currentTank2Position_x,currentTank2Position_y,currentTank2Position_z;
	float currentPenguinPosition_x,currentPenguinPosition_y,currentPenguinPosition_z;
	int currentStage;
		

	public void SaveGame()
	{

		currentTank2Position_x = GameObject.Find ("Tank2").transform.position.x;
		currentTank2Position_y = GameObject.Find ("Tank2").transform.position.y;
		currentTank2Position_z = GameObject.Find ("Tank2").transform.position.z;

		PlayerPrefs.SetFloat("Tank2Position_x", currentTank2Position_x);
		PlayerPrefs.SetFloat("Tank2Position_y", currentTank2Position_y);
		PlayerPrefs.SetFloat("Tank2Position_z", currentTank2Position_z);

		currentPenguinPosition_x = GameObject.Find ("Penguin").transform.position.x;
		currentPenguinPosition_y = GameObject.Find ("Penguin").transform.position.y;
		currentPenguinPosition_z = GameObject.Find ("Penguin").transform.position.z;

		PlayerPrefs.SetFloat("PenguinPosition_x", currentPenguinPosition_x);
		PlayerPrefs.SetFloat("PenguinPosition_y", currentPenguinPosition_y);
		PlayerPrefs.SetFloat("PenguinPosition_z", currentPenguinPosition_z);
	
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

		//맵 로그 저장

		Debug.Log ("Game Save");
	}

	public void LoadGame()
	{
		float tank2Position_x  = PlayerPrefs.GetFloat("Tank2Position_x");
		float tank2Position_y  = PlayerPrefs.GetFloat("Tank2Position_y");
		float tank2Position_z  = PlayerPrefs.GetFloat("Tank2Position_z");

		GameObject.Find ("Tank2").transform.position.Set (tank2Position_x, tank2Position_y, tank2Position_z);

		float penguinPosition_x  = PlayerPrefs.GetFloat("PenguinPosition_x");
		float penguinPosition_y  = PlayerPrefs.GetFloat("PenguinPosition_y");
		float penguinPosition_z  = PlayerPrefs.GetFloat("PenguinPosition_z");

		GameObject.Find ("Penguin").transform.position.Set (penguinPosition_x, penguinPosition_y, penguinPosition_z);
			
		string[] myItemCodes = PlayerPrefs.GetString ("Myitems").Split (',');

		for (int i = 0; i < myItemCodes.Length-1; i++) { // code 마지막값 버림( -1)
			int itemCode = Int32.Parse(myItemCodes[i]);
			Config.canUseItem [itemCode] = true;
		}

		string[] myObjectCodes = PlayerPrefs.GetString ("MyObjects").Split (',');

		for (int i = 0; i < myObjectCodes.Length-1; i++) {
			int objectCode = Int32.Parse(myObjectCodes[i]);
			Config.canUseObject [objectCode] = true;

		}

		currentStage = PlayerPrefs.GetInt ("stage");
		GameObject.Find ("GameInfo").GetComponent<GameInfo> ().currentStage = currentStage;

		//맵 로그 불러오기

		Debug.Log ("Game Load");
	}
}
