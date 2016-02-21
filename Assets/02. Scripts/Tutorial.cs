using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;



public class Tutorial : MonoBehaviour {	

	NoiseAndGrain noiseAndGrainMain;
	Blur blurMain;
	public GameObject penguin, tank2;
	private Animator anim;
	float penguinSpeed;
	float deltaTime=0,timer;
	bool noiseTab = false;
	bool timeCount = true;
	GameObject UICamera,extensionButton;

	// Use this for initialization
	void Start () {
		
		noiseAndGrainMain = GameObject.Find ("MainCamera").GetComponent<NoiseAndGrain> ();
		blurMain = GameObject.Find ("MainCamera").GetComponent<Blur> ();
		anim = penguin.GetComponent<Animator>();
		penguinSpeed = 3;
		anim.SetFloat ("Speed", 10);
		noiseAndGrainMain.intensityMultiplier = 10;
		blurMain.enabled = true;
		blurMain.iterations = 5;

	}
	
	// Update is called once per frame
	void Update () {

		if (timeCount) {
			deltaTime += Time.deltaTime;
			timer = (int)deltaTime;
		}

		if (timer < 5) {
			UICamera = GameObject.Find ("UI Camera");
			UICamera.GetComponent<Camera> ().enabled = false;
			//extensionButton = GameObject.Find ("ExtensionButton");
			//extensionButton.GetComponent<Button> ().interactable = false;

			if (noiseTab) {
				noiseTab = false;
				noiseAndGrainMain.intensityMultiplier++;
			} else {
				noiseTab = true;
				noiseAndGrainMain.intensityMultiplier--;
			}
		}
		if (timer == 5) {
			noiseAndGrainMain.intensityMultiplier = 0;
			noiseAndGrainMain.enabled = false; 
			blurMain.iterations = 10;
		}
		if (timer > 6 && timer < 7) {
			blurMain.iterations--;
		}
		if (timer == 7) {
			blurMain.enabled = false;
			UICamera.GetComponent<Camera> ().enabled = true;

		}

		if (timer == 8) {
			//extensionButton.GetComponent<Button> ().interactable = true;
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
				timeCount = false;
			}
		}
			
	
		if (GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().onScene13) {
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
	
		if (timer > 10 && timer < 13) {
			if (GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().onScene13) {
				GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().onScene13 = false;
				GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().Scene15 ();
			}
		}
		if (timer == 13) {
			anim.SetBool ("Happy", false);
		}
			
		if (timer > 13 && timer < 16) {
			penguin.transform.Rotate(new Vector3(0,100*Time.deltaTime, 0));
			penguinSpeed = 10;
		}
	
		if (timer >= 16 && timer < 21) {
			anim.SetFloat ("Speed", 20);
			penguin.transform.Translate (transform.forward * penguinSpeed * Time.deltaTime);
		}

		if (timer > 20) {
			if (GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().onScene15) {
				penguin.SetActive (false);
				GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().onScene15 = false;
				GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().Scene17 ();

				GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().Scene19 ();
			}
		}
		/////// 고속도로 타고 간다 ///////

	}
}
