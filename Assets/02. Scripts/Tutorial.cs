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
		noiseAndGrainMain.enabled = true;
		noiseAndGrainMain.intensityMultiplier = 10;
		blurMain.enabled = true;
		blurMain.iterations = 1;
		GameObject.Find ("Penguin").GetComponent<PenguinMove> ().onPenguinMove = false;

	}
	
	// Update is called once per frame
	void Update () {

		//GameObject.Find ("Sun").SetActive (true);
		
		if (timeCount) {
			deltaTime += Time.deltaTime;
			timer = (int)deltaTime;
		}

		if (timer < 5) {
			GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().currentScene = 1;
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
			GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().currentScene = 2;
			noiseAndGrainMain.intensityMultiplier = 0;
			noiseAndGrainMain.enabled = false; 
			blurMain.iterations = 10;
		}

		if (timer == 8)
			blurMain.iterations --;
		if (timer == 9) {
			GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().currentScene = 3;
			blurMain.enabled = false;
			UICamera.GetComponent<Camera> ().enabled = true;

		}

		if (timer == 10) {
			//extensionButton.GetComponent<Button> ().interactable = true;
			timeCount = false;
			timer++;
		}


		//////// 고속도로 타고온다 ///

		if (GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().onScene10) {
			
			GameObject.Find ("Penguin").GetComponent<PenguinMove> ().onPenguinMove = true;

			float distance = Vector3.Distance (tank2.transform.position, penguin.transform.position);
	
			if (distance < 10 ){
				GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().currentScene = 11;
				GameObject.Find ("Penguin").GetComponent<PenguinMove> ().onPenguinMove = false;
				anim.SetFloat ("Speed", 0);
				anim.SetBool ("Happy", true);
				timeCount = true;
			}
		}
	
		if (timer == 13) {
			if (GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().onScene10) {
				GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().onScene10 = false;
				GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().Scene12 ();
				timeCount = false;
			}
		}
			
	
		if (GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().onScene13) {

			GameObject.Find ("Penguin").GetComponent<PenguinMove> ().onPenguinMove = true;

			float distance = Vector3.Distance (tank2.transform.position, penguin.transform.position);

			if (distance < 10 ){
				GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().currentScene = 14;
				GameObject.Find ("Penguin").GetComponent<PenguinMove> ().onPenguinMove = false;
				anim.SetFloat ("Speed", 0);
				anim.SetBool ("Happy", true);
				timeCount = true;

				timeCount = true;
			}
		}
	
		if (timer > 13 && timer < 16) {
			if (GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().onScene13) {
				GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().onScene13 = false;
				GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().Scene15 ();
			}
		}
		if (timer == 16) {
			anim.SetBool ("Happy", false);
		}
			
		if (timer > 16 && timer < 19) {
			GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().currentScene = 16;
			penguin.transform.Rotate(new Vector3(0,100*Time.deltaTime, 0));
			penguinSpeed = 10;
		}
	
		if (timer >= 19 && timer < 27) {
			anim.SetFloat ("Speed", 20);
			penguin.transform.Translate (transform.forward * penguinSpeed * Time.deltaTime);
		}

		if (timer > 26 && timer <33) {
			if (GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().onScene15) {
				penguin.SetActive (false);
				GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().onScene15 = false;
				GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().Scene17 ();

				GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().Scene19 ();
			}
		}

		if (timer > 32) {
			tank2.GetComponent<TutorialTankMove> ().speed = 0;
			noiseAndGrainMain.enabled = true;
			if (timer == 34) {
				UICamera = GameObject.Find ("UI Camera");
				UICamera.GetComponent<Camera> ().enabled = false;
				noiseAndGrainMain.intensityMultiplier++;
			}

			if (timer == 40) {
				//Application.LoadLevel ("Obj_Scene");
			}
		}
			
		/////// 고속도로 타고 간다 ///////

	}
}
