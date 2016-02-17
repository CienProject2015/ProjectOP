﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;



public class Tutorial : MonoBehaviour {	

	NoiseAndGrain noiseAndGrain;
	Blur blur;
	public GameObject penguin, tank2;
	private Animator anim;
	float penguinSpeed;
	float deltaTime=0,timer;
	bool noiseTab = false;
	bool timeCount = true;

	// Use this for initialization
	void Start () {
		noiseAndGrain = GameObject.Find ("MainCamera").GetComponent<NoiseAndGrain> ();
		blur = GameObject.Find ("MainCamera").GetComponent<Blur> ();
		anim = penguin.GetComponent<Animator>();
		penguinSpeed = 3;
		anim.SetFloat ("Speed", 10);
		noiseAndGrain.intensityMultiplier = 10;
		blur.enabled = true;
		blur.iterations = 10;

	}
	
	// Update is called once per frame
	void Update () {

		if (timeCount) {
			deltaTime += Time.deltaTime;
			timer = (int)deltaTime;
		}

		if (timer < 5) {
			if (noiseTab) {
				noiseTab = false;
				noiseAndGrain.intensityMultiplier++;
			} else {
				noiseTab = true;
				noiseAndGrain.intensityMultiplier--;
			}
		}
		if (timer == 5) {
			noiseAndGrain.intensityMultiplier = 0;
			noiseAndGrain.enabled = false; 
		}
		if (timer > 6 && timer < 7) {
			blur.iterations--;
		}
		if (timer == 7) {
			blur.enabled = false;
		}

		if (timer == 8) {
			timeCount = false;
			timer++;
		}



		//////// 고속도로 타고온다 ///

		if (GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().onScene10) {
			if (tank2.transform.position.z + 20 < penguin.transform.position.z ) {
				penguinSpeed = 10;
				anim.SetFloat ("Speed", 20);	
				penguin.transform.LookAt (tank2.transform);
				penguin.transform.Translate (transform.forward * penguinSpeed * Time.deltaTime);
			}
			if (tank2.transform.position.z + 20 >= penguin.transform.position.z && tank2.transform.position.z + 10 < penguin.transform.position.z) {
				penguinSpeed = 3;
				anim.SetFloat ("Speed", 10);	
				penguin.transform.LookAt (tank2.transform);
				penguin.transform.Translate (transform.forward * penguinSpeed * Time.deltaTime);
			}
			if(tank2.transform.position.z + 10 >= penguin.transform.position.z && tank2.transform.position.z + 3 < penguin.transform.position.z){
				anim.SetFloat ("Speed", 0);
				anim.SetBool ("Happy", true);
				timeCount = true;
			}
		}
	
		if (timer == 10) {
			if (GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().onScene10) {
				GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().onScene10 = false;
				GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().Scene12 ();
			}
		}

		if (timer > 19 && timer < 21) {
			GameObject.Find ("Alert_Screen").GetComponent<AlertScreenAnim> ().StartAlertAnim ();
		}
		if (timer >= 21 && timer <= 22) {
			GameObject.Find ("Alert_Screen").GetComponent<AlertScreenAnim> ().StopAlertAnim ();
		}
		if (timer > 20 && timer < 23) {
			anim.SetBool ("Happy", false);
			tank2.transform.Translate(new Vector3(0,0,-4*Time.deltaTime)); 
		}
		/////
		if (timer > 23 && timer < 29) {
				anim.SetFloat ("Speed", 20);
			if(timer > 17)
				anim.SetFloat ("Speed", 10);
			penguin.transform.LookAt (tank2.transform);
			penguin.transform.Translate (transform.forward * penguinSpeed * Time.deltaTime);
		}
		////
		if (timer > 28 && timer < 31) {
			anim.SetFloat ("Speed", 0);
			anim.SetBool ("Happy", true);
		}
		////
		if(timer > 31)
			anim.SetBool ("Happy", false);
		if (timer > 32 && timer < 34) {
			penguin.transform.Rotate(new Vector3(0,100*Time.deltaTime, 0));
		}
		//
		if (timer >= 34 && timer < 40) {
			anim.SetFloat ("Speed", 20);
			penguin.transform.Translate (transform.forward * penguinSpeed * Time.deltaTime);
		}
		/////// 고속도로 타고 간다 ///////

	}
}
