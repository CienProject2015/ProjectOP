using UnityEngine;
using System.Collections;

public class Load_UI_Scene : MonoBehaviour {

	GameObject eventSystem;
	// Use this for initialization
	void Awake () {
		Application.LoadLevelAdditive ("Ingame_UI");

	}
	
	// Update is called once per frame
	void Update () {
		eventSystem = GameObject.Find ("_EventSystem");
		eventSystem.GetComponent<TutorialManager>().isTutorial = false;
	}
}
