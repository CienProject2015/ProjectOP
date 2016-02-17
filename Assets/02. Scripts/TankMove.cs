using UnityEngine;
using System.Collections;

public class TankMove : MonoBehaviour {

	public float speed = 15;
	private float cycleSpeed;
	private int leftWheelDiret, rightWheelDiret;

	private int count = 0;

	void Start () {
        cycleSpeed = speed * 5;
    }
	
	void Update () {
		MoveWheel ();
		rightWheelDiret = 0;
		leftWheelDiret = 0;
    }

	// direct -> 1 : forward / 0 : stop / -1 : back
	public void MoveWheel(){
		if (leftWheelDiret == 1) { 
			if (rightWheelDiret == 1)
				MoveForward ();
			else
				TurnRight ();
		} else if (leftWheelDiret == 0) {
			if (rightWheelDiret == 1)
				TurnLeft ();
			else if (rightWheelDiret == -1)
				TurnRight ();
		} else if(leftWheelDiret == -1){
			if (rightWheelDiret == -1)
				MoveBack ();
			else
				TurnLeft ();
		}
	}

    public void setLeftWheelDirect(int direct){
		leftWheelDiret = direct;
    }
	public void setRightWheelDirect(int direct){
		rightWheelDiret = direct;
    }

	public void MoveForward(){
		if (GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().isTutorial) {
			if (GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().onScene7) {
				transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
				count++;
				if (count == 30) {
					count = 0;
					GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().Scene8 ();
				}
			}
		}else
			transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
    }
	public void MoveBack(){
		if (GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().isTutorial) {
			if (GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().onScene12) {
				transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
				count++;
				if (count == 60) {
					count = 0;
					GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().Scene13 ();
				}
			}
		}else
			transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
	}
	public void TurnRight(){
		if (GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().isTutorial) {
			if (GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().onScene9) {
				transform.Rotate(new Vector3(0, cycleSpeed * Time.deltaTime, 0));
				count++;
				if (count == 40) {
					count = 0;
					GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().Scene10 ();
				}
			}
		}else
			transform.Rotate(new Vector3(0, cycleSpeed * Time.deltaTime, 0));
	}
	public void TurnLeft(){
		if (GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().isTutorial) {
			if (GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().onScene8) {
				transform.Rotate(new Vector3(0, -cycleSpeed * Time.deltaTime, 0));
				count++;
				if (count == 40) {
					count = 0;
					GameObject.Find ("_EventSystem").GetComponent<TutorialManager> ().Scene9 ();
				}
			}
		}else
			transform.Rotate(new Vector3(0, -cycleSpeed * Time.deltaTime, 0));
	}
	void tank_stop(){
		speed = 0;
	}
	void tank_start()
	{
		Debug.Log("tank_start");
		speed = 15;
	}
}
