using UnityEngine;
using System.Collections;

public class GameInfo : MonoBehaviour {


	public Sprite[] sprite;

	void Start(){

	}
	void Update(){

		Config.itemSprite [0] = sprite[0];
		Config.itemSprite [1] = sprite[1];


	}
}
