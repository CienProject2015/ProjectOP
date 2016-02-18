using UnityEngine;
using System.Collections;

public class GameInfo : MonoBehaviour {

	public int currentStage;
	public Sprite[] sprite;

	void Start(){
		Config.itemSprite [0] = sprite[0];
	}
}
