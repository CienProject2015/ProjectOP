using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;


public class TutorialManager : MonoBehaviour {




	public bool isTutorial;
	public bool onScene7;
	public bool onScene8;
	public bool onScene9;
	public bool onScene10;
	public bool onScene12;
	public bool onScene13;
	public bool onScene15;

	private float deltaTime,timer;
	bool timeCount = true;

	private bool scene4Run;

	void Start () {

		isTutorial = true;
		onScene7 = false;
		onScene8 = false;
		onScene9 = false;
		onScene10 = false;
		onScene12 = false;
		onScene13 = false;
		onScene15 = false;

		timer = 0;

		scene4Run = true;


	}

	void Update () {
		if (timeCount) {
			deltaTime += Time.deltaTime;
			timer = (int)deltaTime;
		}

		timeAction ();

	}

	public void timeAction(){
		
		if (timer == 8 && scene4Run) {
			timeCount = false;
			timer = 9;
			Scene4 ();
			scene4Run = false;
		}
			
	}

	public void Scene4(){
		gameObject.SendMessage ("ReceiveLog", "움직이지 않는다. 긴급키트를 사용하자.");
		GameObject.Find ("Alert_Screen").GetComponent<AlertScreenAnim> ().StartAlertAnim ();
		GameObject.Find ("_EventSystem").GetComponent<TutorialButtonGuide> ().StartTwinkle (GameObject.Find("ExtensionButton"));
	}

	public void Scene6(){
		gameObject.SendMessage ("ReceiveLog", "수리가 완료되었다. 작동확인을 해보자.");
		GameObject.Find ("Alert_Screen").GetComponent<AlertScreenAnim> ().StopAlertAnim ();
		GameObject.Find ("_EventSystem").GetComponent<TutorialButtonGuide> ().StopTwinkle (GameObject.Find("ExtensionButton"));
		Invoke ("Scene7", 2);
	}

	public void Scene7(){
		gameObject.SendMessage ("ReceiveLog", "두 바퀴를 움직여 전진한다.");
		GameObject.Find ("_EventSystem").GetComponent<TutorialButtonGuide> ().StartTwinkle (GameObject.Find ("_FrontRightWheel"));
		GameObject.Find ("_EventSystem").GetComponent<TutorialButtonGuide> ().StartTwinkle (GameObject.Find ("_FrontLeftWheel"));
		onScene7 = true;
	}

	public void Scene8(){
		onScene7 = false;
		gameObject.SendMessage ("ReceiveLog", "오른쪽 바퀴를 움직여 좌회전한다.");
		GameObject.Find ("_EventSystem").GetComponent<TutorialButtonGuide> ().StartTwinkle (GameObject.Find ("_FrontRightWheel"));
		onScene8 = true;
	}

	public void Scene9(){
		onScene8 = false;
		gameObject.SendMessage ("ReceiveLog", "왼쪽 바퀴를 움직여 우회전한다.");
		GameObject.Find ("_EventSystem").GetComponent<TutorialButtonGuide> ().StartTwinkle (GameObject.Find ("_FrontLeftWheel"));
		onScene9 = true;
	}

	public void Scene10(){
		onScene9 = false;
		onScene10 = true;
		timeCount = true;
	}

	public void Scene12(){
		GameObject.Find ("Alert_Screen").GetComponent<AlertScreenAnim> ().StartAlertAnim ();
		GameObject.Find ("_EventSystem").GetComponent<TutorialButtonGuide> ().StartTwinkle (GameObject.Find ("_BackRightWheel"));
		GameObject.Find ("_EventSystem").GetComponent<TutorialButtonGuide> ().StartTwinkle (GameObject.Find ("_BackLeftWheel"));
		gameObject.SendMessage ("ReceiveLog", "이상한 생명체다. 도망가자.");
		onScene12 = true;
	}

	public void Scene13(){
		GameObject.Find ("Alert_Screen").GetComponent<AlertScreenAnim> ().StopAlertAnim ();
		GameObject.Find ("_EventSystem").GetComponent<TutorialButtonGuide> ().StopTwinkle (GameObject.Find ("_BackRightWheel"));
		GameObject.Find ("_EventSystem").GetComponent<TutorialButtonGuide> ().StopTwinkle (GameObject.Find ("_BackLeftWheel"));
		onScene12 = false;
		onScene13 = true;
	}

	public void Scene15(){
		gameObject.SendMessage ("ReceiveLog", "반기는 것 같은데 이유를 알 수 없다.");
		onScene15 = true;
	}

	public void Scene17(){
		gameObject.SendMessage ("ReceiveLog", "팽귄을 따라가자.");
	}

	public void Scene19(){
		isTutorial = false;
	}
}
