using UnityEngine;
using System.Collections;

public class MapAdmin : MonoBehaviour {

	public GameObject[] rowMap1;
	public GameObject[] rowMap2;
	public GameObject[] rowMap3;
	public GameObject[] rowMap4;
	public GameObject[] rowMap5;
	public GameObject[] rowMap6;
	public GameObject[] rowMap7;
	public GameObject[,] map = new GameObject[8,8];	

	
	// Update is called once per frame
	void Update () {
		for (int i = 1; i < 8; i++) {
			map [1,i] = rowMap1 [i];
		}
		for (int i = 1; i < 8; i++) {
			map [2,i] = rowMap2 [i];
		}
		for (int i = 1; i < 8; i++) {
			map [3,i] = rowMap3 [i];
		}
		for (int i = 1; i < 8; i++) {
			map [4,i] = rowMap4 [i];
		}
		for (int i = 1; i < 8; i++) {
			map [5,i] = rowMap5 [i];
		}
		for (int i = 1; i < 8; i++) {
			map [6,i] = rowMap6 [i];
		}
		for (int i = 1; i < 8; i++) {
			map [7,i] = rowMap7 [i];
		}
	}
}
