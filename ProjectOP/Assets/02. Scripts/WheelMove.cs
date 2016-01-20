using UnityEngine;
using System.Collections;

public class WheelMove : MonoBehaviour {

	public bool isFirstPersonView;

	void Update(){
		if (isFirstPersonView) {
			for (int i = 0; i < Input.touchCount; i++) {
				
				Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (i).position);
				RaycastHit hit;

				if (Physics.Raycast (ray, out hit) && hit.collider.tag == "FrontRight") {
					Debug.Log ("오른쪽 앞");
				} else if (Physics.Raycast (ray, out hit) && hit.collider.tag == "BackRight") {
					Debug.Log ("오른쪽 뒤");
				} else if (Physics.Raycast (ray, out hit) && hit.collider.tag == "FrontLeft") {
					Debug.Log ("왼쪽 앞");
				} else if (Physics.Raycast (ray, out hit) && hit.collider.tag == "BackLeft") {
					Debug.Log ("왼쪽 뒤");
				}
			}
		}
	}
}
