﻿using UnityEngine;
using System.Collections;

public class TutorialManager : MonoBehaviour {

	public bool isTutorial;
	public bool onScene7;
	public bool onScene8;
	public bool onScene9;
	public bool onScene12;

	private float timer;

	private bool scene4Run;

	void Start () {
		isTutorial = true;
		onScene7 = false;
		onScene8 = false;
		onScene9 = false;
		onScene12 = false;

		timer = 0;

		scene4Run = true;
	}

	void Update () {
		if (isTutorial) {
			timer += Time.deltaTime;

			Scene4 ();
		}
	}

	public void Scene4(){
		if (timer > 2 && scene4Run) {
			gameObject.SendMessage ("ReceiveLog", "움직이지 않는다. 긴급키트를 사용하자.");
			scene4Run = false;
		}
	}

	public void Scene6(){
		gameObject.SendMessage ("ReceiveLog", "수리가 완료되었다. 작동확인을 해보자.");
		Invoke ("Scene7", 2);
	}

	public void Scene7(){
		gameObject.SendMessage ("ReceiveLog", "두 바퀴를 움직여 전진한다.");
		onScene7 = true;
	}

	public void Scene8(){
		onScene7 = false;
		gameObject.SendMessage ("ReceiveLog", "오른쪽 바퀴를 움직여 좌회전한다.");
		onScene8 = true;
	}

	public void Scene9(){
		onScene8 = false;
		gameObject.SendMessage ("ReceiveLog", "왼쪽 바퀴를 움직여 우회전한다.");
		onScene9 = true;
	}

	public void Scene10(){
		onScene9 = false;
	}

	public void Scene12(){
		gameObject.SendMessage ("ReceiveLog", "이상한 생명체다. 도망가자.");
		onScene12 = true;
	}

	public void Scene13(){
		onScene12 = false;
	}

	public void Scene15(){
		gameObject.SendMessage ("ReceiveLog", "반기는 것 같은데 이유를 알 수 없다.");
	}

	public void Scene17(){
		gameObject.SendMessage ("ReceiveLog", "팽귄을 따라가자.");
	}

	public void Scene19(){
		isTutorial = false;
	}
}