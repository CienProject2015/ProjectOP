using UnityEngine;
using System.Collections;

public class TankMove : MonoBehaviour {

	public float speed = 5;
	public float cycleSpeed = 2;
	private int leftWheelDiret, rightWheelDiret;
	private int currentStage=0;


	void Start () {


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
		transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
    }
	public void MoveBack(){
		transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
	}
	public void TurnRight(){
		transform.Rotate(new Vector3(0, cycleSpeed * Time.deltaTime, 0));
	}
	public void TurnLeft(){
			transform.Rotate(new Vector3(0, -cycleSpeed * Time.deltaTime, 0));
	}
	void tank_stop(){
		speed = 0;
	}
	void tank_start()
	{
		speed = 5;
	}

	void OnTriggerEnter(Collider other){
		// stage change

		GameObject.Find ("GameInfo").GetComponent<InGameInfo> ().currentStage = 1;

		if (other.name == "TerrainR") {
			Debug.Log ("TerrainR");
		}
		if (other.name == "TerrainL") {
			Debug.Log ("TerrainL");
		}
		if (other.name == "TerrainF") {
			Debug.Log ("TerrainF");
		}
		if (other.name == "Terrain") {
			Debug.Log ("Terrain");
		}
	}
}
