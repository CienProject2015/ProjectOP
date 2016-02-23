using UnityEngine;
using System.Collections;
using System;

public class MapSearch : MonoBehaviour {
	// 1~ 7 / 1 ~ 7
	int mapRowMax = 8-1, mapColumnMax = 8-1; 
	public GameObject[,] map = new GameObject[8,8];	

	string[] tempName;
	int row,column;

	bool onFirst = true;

	void Update(){
		for (int i = 1; i < mapRowMax; i++) {
			for (int j = 1; j < mapColumnMax; j++) {
				map[i,j] = GameObject.Find ("MapAdmin").GetComponent<MapAdmin>().map[i,j];
			}
		}

		if (GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().isItemTutorial) {
			if (onFirst) {
				for (int i = 1; i < mapRowMax; i++) {
					for (int j = 1; j < mapColumnMax; j++) {
						map [i, j].SetActive (false);
					}
				}
				onFirst = false;
			}
			map [1, 1].SetActive (true);
			map [1, 2].SetActive (true);
		} else {
			MapSetting ();
		}
	}

	void MapSetting(){

		for (int i = 1; i < mapRowMax; i++) {
			for (int j = 1; j < mapColumnMax; j++) {

				// 5개 load
			/*
				if(i == row -1  && j == column){
					if (map [i,j] == null) {
						Debug.Log ("No Local");
					} else {
						map[i,j].SetActive(true);
					}
				}else if(i == row && j == column -1){
					if (map [i,j]== null) {
						Debug.Log ("No Local");
					} else {
						map[i,j].SetActive(true);
					}
				}else if(i == row && j == column){
					if (map [i,j] == null) {
						Debug.Log ("No Local");
					} else {
						map[i,j].SetActive(true);
					}
				}else if(i == row && j == column +1){
					if (map [i,j] == null) {
						Debug.Log ("No Local");
					} else {
						map[i,j].SetActive(true);
					}
				}else if (i == row + 1 && j == column) {
					if (map [i, j] == null) {
						Debug.Log ("No Local");
					} else {
						map [i, j].SetActive (true);
					}
				}
				*/
				if (i == row && j == column) {
					if (map [i, j] == null) {
						Debug.Log ("No Local");
					} else {
						map [i, j].SetActive (true);
					}
				}else {
					if (map [i, j].activeSelf) {
						if (!onFirst) {
							map [i, j].SetActive (false);
						}
					}
				}
			}
		}
	}
		
	void OnTriggerEnter(Collider other){
		tempName = other.name.Split('-');
		row = Int32.Parse (tempName [0]);
		column = Int32.Parse (tempName [1]);

		onFirst = false;
	}

}
