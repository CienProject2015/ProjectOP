﻿using UnityEngine;
using System.Collections;

public class TankMove : MonoBehaviour {

	public float speed = 15;
	private float cycleSpeed;
	private int leftWheelDiret, rightWheelDiret;

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

	private void MoveForward(){
		transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    }
	private void MoveBack(){
		transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
	}
	private void TurnRight(){
			transform.Rotate(new Vector3(0, cycleSpeed * Time.deltaTime, 0));
	}
	private void TurnLeft(){
			transform.Rotate(new Vector3(0, -cycleSpeed * Time.deltaTime, 0));
	}
}
