using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;



public class Tutorial : MonoBehaviour {	

	NoiseAndGrain noiseAndGrain;
	Blur blur;
	public GameObject penguin, tank2;
	private Animator anim;
	float penguinSpeed;
	float currentTime=0;
	int timer;
	bool noiseTab = false;

	// Use this for initialization
	void Start () {
		noiseAndGrain = GameObject.Find ("MainCamera").GetComponent<NoiseAndGrain> ();
		blur = GameObject.Find ("MainCamera").GetComponent<Blur> ();
		anim = penguin.GetComponent<Animator>();
		penguinSpeed = 2;
		anim.SetFloat ("Speed", 10);
		noiseAndGrain.intensityMultiplier = 10;
		blur.enabled = true;
		blur.iterations = 10;

	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
		timer = (int)currentTime;
		if (currentTime < 5) {
			if (noiseTab) {
				noiseTab = false;
				noiseAndGrain.intensityMultiplier++;
			} else {
				noiseTab = true;
				noiseAndGrain.intensityMultiplier--;
			}
		}
		if (currentTime >= 5 && currentTime <= 6) {
			noiseAndGrain.intensityMultiplier = 0;
			noiseAndGrain.enabled = false; 
			Debug.Log ("check");

		}
		if (currentTime > 6 && currentTime < 7) {
			blur.iterations--;
		}
		if (currentTime >= 7 && currentTime <= 8) {
			blur.enabled = false;
		}

		if (currentTime > 7 && currentTime < 10) {
			gameObject.SendMessage ("ReceiveLog", "움직이지 않는다. 긴급키트를 사용하자.");
			GameObject.Find ("Alert_Screen").GetComponent<AlertScreenAnim> ().StartAlertAnim ();
			GameObject target = GameObject.Find ("FrontRightWheel");
			//GameObject.Find ("_EventSystem").GetComponent<TutorialButtonGuide> ().StartTwinkle (target);
			//	GameObject.Find ("FrontRightWheel");
		}
		if (currentTime >= 10 && currentTime <= 11) {
			GameObject.Find ("Alert_Screen").GetComponent<AlertScreenAnim> ().StopAlertAnim ();
		}

		//////// 고속도로 타고온다 ///
		///탱크 임의 조작 막아뒤야 한다 //

		//if (tank2.transform.position.z + 5 < penguin.transform.position.z) {
		if (currentTime > 10 && currentTime <= 17) {
			anim.SetFloat ("Speed", 10);	
			penguin.transform.LookAt (tank2.transform);
			penguin.transform.Translate (transform.forward * penguinSpeed * Time.deltaTime);
		}
		//////
		if (currentTime > 16 && currentTime <= 22) {
			anim.SetFloat ("Speed", 0);
			anim.SetBool ("Happy", true);
		}
		//////
		if (currentTime > 19 && currentTime < 21) {
			GameObject.Find ("Alert_Screen").GetComponent<AlertScreenAnim> ().StartAlertAnim ();
		}
		if (currentTime >= 21 && currentTime <= 22) {
			GameObject.Find ("Alert_Screen").GetComponent<AlertScreenAnim> ().StopAlertAnim ();
		}
		if (currentTime > 20 && currentTime < 23) {
			anim.SetBool ("Happy", false);
			tank2.transform.Translate(new Vector3(0,0,-4*Time.deltaTime)); 
		}
		/////
		if (currentTime > 23 && currentTime < 29) {
				anim.SetFloat ("Speed", 20);
			if(currentTime > 17)
				anim.SetFloat ("Speed", 10);
			penguin.transform.LookAt (tank2.transform);
			penguin.transform.Translate (transform.forward * penguinSpeed * Time.deltaTime);
		}
		////
		if (currentTime > 28 && currentTime < 31) {
			anim.SetFloat ("Speed", 0);
			anim.SetBool ("Happy", true);
		}
		////
		if(currentTime > 31)
			anim.SetBool ("Happy", false);
		if (currentTime > 32 && currentTime < 34) {
			penguin.transform.Rotate(new Vector3(0,100*Time.deltaTime, 0));
		}
		//
		if (currentTime >= 34 && currentTime < 40) {
			anim.SetFloat ("Speed", 20);
			penguin.transform.Translate (transform.forward * penguinSpeed * Time.deltaTime);
		}
		/////// 고속도로 타고 간다 ///////
		Debug.Log (timer);
	}
}
