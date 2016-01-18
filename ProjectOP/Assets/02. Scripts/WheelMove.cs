using UnityEngine;
using System.Collections;

public class WheelMove : MonoBehaviour {

	public bool isFirstPersonView;
	public float draggingBuffer;
	private bool[] moveInfo = new bool[20];

	void Update(){
		if (isFirstPersonView) {
			for (int i = 0; i < Input.touchCount; i++) {
				Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (i).position);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit) && hit.collider.tag == "LeftWheel") {
					if (Input.GetTouch (i).deltaPosition.y > draggingBuffer) {
						moveInfo [i] = true;
						Debug.Log ("왼쪽 앞");
					} else if (Input.GetTouch (i).deltaPosition.y < 0 - draggingBuffer) {
						moveInfo [i] = false;
						Debug.Log ("왼쪽 뒤");
					} else {
						if (moveInfo [i]) {
							Debug.Log ("왼쪽 앞");
						} else {
							Debug.Log ("왼쪽 뒤");
						}
					}
				}
				if (Physics.Raycast (ray, out hit) && hit.collider.tag == "RightWheel") {
					if (Input.GetTouch (i).deltaPosition.y > draggingBuffer) {
						moveInfo [i] = true;
						Debug.Log ("오른쪽 앞");
					} else if (Input.GetTouch (i).deltaPosition.y < 0 - draggingBuffer) {
						moveInfo [i] = false;
						Debug.Log ("오른쪽 뒤");
					} else {
						if (moveInfo [i]) {
							Debug.Log ("오른쪽 앞");
						} else {
							Debug.Log ("오른쪽 뒤");
						}
					}
				}
			}
		}
	}
}
