using UnityEngine;
using System.Collections;

public class WheelMove : MonoBehaviour {

	public bool isFirstPersonView;
	public float draggingBuffer;
	private bool[] moveInfo = new bool[20];
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
				if (Physics.Raycast (ray, out hit) && hit.collider.tag == "LeftWheel") {
					if (Input.GetTouch (i).deltaPosition.y > draggingBuffer) {
						moveInfo [i] = true;
						//Debug.Log ("왼쪽 앞");
						tank.SendMessage("setLeftWheelDirect", 1);
					} else if (Input.GetTouch (i).deltaPosition.y < 0 - draggingBuffer) {
						moveInfo [i] = false;
						//Debug.Log ("왼쪽 뒤");
						tank.SendMessage("setLeftWheelDirect", -1);
					} else {
						if (moveInfo [i]) {
							//Debug.Log ("왼쪽 앞");
							tank.SendMessage("setLeftWheelDirect", 1);
						} else {
							//Debug.Log ("왼쪽 뒤");
							tank.SendMessage("setLeftWheelDirect", -1);
						}
					}
				}
				if (Physics.Raycast (ray, out hit) && hit.collider.tag == "RightWheel") {
					if (Input.GetTouch (i).deltaPosition.y > draggingBuffer) {
						moveInfo [i] = true;
						//Debug.Log ("오른쪽 앞");
						tank.SendMessage("setRightWheelDirect", 1);
					} else if (Input.GetTouch (i).deltaPosition.y < 0 - draggingBuffer) {
						moveInfo [i] = false;
						//Debug.Log ("오른쪽 뒤");
						tank.SendMessage("setRightWheelDirect", -1);
					} else {
						if (moveInfo [i]) {
							//Debug.Log ("오른쪽 앞");
							tank.SendMessage("setRightWheelDirect", 1);
						} else {
							//Debug.Log ("오른쪽 뒤");
							tank.SendMessage("setRightWheelDirect", -1);
						}
					}
				}
			}
		}
	}

}
