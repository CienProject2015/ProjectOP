using UnityEngine;
using System.Collections;
using System;

public class MapSearch : MonoBehaviour {
	// 1~ 7 / 1 ~ 7
	int mapRowMax = 8-1, mapColumnMax = 8-1; 
	public GameObject[,] map = new GameObject[8,8];	

	string[] tempName;
	int row,column;


	void Update(){
		for (int i = 1; i < mapRowMax; i++) {
			for (int j = 1; j < mapColumnMax; j++) {
				map [i,j] = GameObject.Find (i + "-" + j);
			}
		}
		MapSetting ();
	}

	void MapSetting(){


		for (int i = 1; i < mapRowMax; i++) {
			for (int j = 1; j < mapColumnMax; j++) {

				// 9개 로

				if(i == row -1 && j == column -1){
					if (map [i,j] == null) {
						Debug.Log ("No Local");
					} else {
						map [i,j].GetComponent<Terrain> ().enabled = true;
					}
				}
				if(i == row -1  && j == column){
					if (map [i,j] == null) {
						Debug.Log ("No Local");
					} else {
						map [i,j].GetComponent<Terrain> ().enabled = true;
					}
				}
				if(i == row && j -1 == column + 1){
					if (map  [i,j] == null) {
						Debug.Log ("No Local");
					} else {
						map [i,j].GetComponent<Terrain> ().enabled = true;
					}
				}
				if(i == row && j == column -1){
					if (map [i,j]== null) {
						Debug.Log ("No Local");
					} else {
						map [i,j].GetComponent<Terrain> ().enabled = true;
					}
				}
				if(i == row && j == column){
					if (map [i,j] == null) {
						Debug.Log ("No Local");
					} else {
						map [i,j].GetComponent<Terrain> ().enabled = true;
					}
				}
				if(i == row && j == column +1){
					if (map [i,j] == null) {
						Debug.Log ("No Local");
					} else {
						map [i,j].GetComponent<Terrain> ().enabled = true;
					}
				}
				if(i == row +1 && j  == column -1){
					if (map [i,j] == null) {
						Debug.Log ("No Local");
					} else {
						map [i,j].GetComponent<Terrain> ().enabled = true;
					}
				}
				if(i == row +1 && j == column){
					if (map [i,j] == null) {
						Debug.Log ("No Local");
					} else {
						map [i,j].GetComponent<Terrain> ().enabled = true;
					}
				}
				if(i == row +1 && j == column +1){
					if (map [i,j] == null) {
						Debug.Log ("No Local");
					} else {
						map [i,j].GetComponent<Terrain> ().enabled = true;
					}
				}
			}
		}
	}

	void OnTriggerEnter(Collider other){
		tempName = other.name.Split('-');
		row = Int32.Parse (tempName [0]);
		column = Int32.Parse (tempName [1]);

	}

}
