using UnityEngine;
using System.Collections;

public class GameInfo : MonoBehaviour {

	public int currentStage;
	public Sprite[] sprite;

	void Awake(){
		Config.itemSprite [0] = sprite [0];
		Config.itemSprite [1] = sprite [1];
	}
}
