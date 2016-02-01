using UnityEngine;
using System.Collections;

public class WheelMove : MonoBehaviour {

	public bool isFirstPersonView;
    private GameObject tank;

    void Start(){
        tank = GameObject.Find("Tank");
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
					Debug.Log ("오른쪽 앞");
					tank.SendMessage("setRightWheelDirect", 1);
				} else if (Physics.Raycast (ray, out hit) && hit.collider.tag == "BackRight") {
					Debug.Log ("오른쪽 뒤");
					tank.SendMessage("setRightWheelDirect", -1);
				} else if (Physics.Raycast (ray, out hit) && hit.collider.tag == "FrontLeft") {
					Debug.Log ("왼쪽 앞");
					tank.SendMessage("setLeftWheelDirect", 1);
				} else if (Physics.Raycast (ray, out hit) && hit.collider.tag == "BackLeft") {
					Debug.Log ("왼쪽 뒤");
					tank.SendMessage("setLeftWheelDirect", -1);
				}
			}
		}
	}

}
