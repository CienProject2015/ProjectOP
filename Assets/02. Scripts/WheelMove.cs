using UnityEngine;
using System.Collections;

public class WheelMove : MonoBehaviour {

	public bool isFirstPersonView;
    private GameObject tank;

	void Start(){
        tank = GameObject.Find("Tank2");

    }

	void Update(){
		WheelTouch ();
	}

	public void WheelTouch(){
		if (isFirstPersonView) {
			for (int i = 0; i < Input.touchCount; i++) {
				
				Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (i).position);
				RaycastHit hit;

				if (Physics.Raycast (ray, out hit) && hit.collider.tag == "FrontRight") {
					tank.SendMessage("setRightWheelDirect", 1);
				} else if (Physics.Raycast (ray, out hit) && hit.collider.tag == "BackRight") {
					tank.SendMessage("setRightWheelDirect", -1);
				} else if (Physics.Raycast (ray, out hit) && hit.collider.tag == "FrontLeft") {
					tank.SendMessage("setLeftWheelDirect", 1);
				} else if (Physics.Raycast (ray, out hit) && hit.collider.tag == "BackLeft") {
					tank.SendMessage("setLeftWheelDirect", -1);
				}
			}
		}
	}

}
