using UnityEngine;
using System.Collections;

public class Load_UI_Scene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Application.LoadLevelAdditive ("Ingame_UI");

	}
	
	// Update is called once per frame
	void Update () {
		GameObject.Find ("_EventSystem").GetComponent<TutorialManager>().isTutorial = false;
	}
}
