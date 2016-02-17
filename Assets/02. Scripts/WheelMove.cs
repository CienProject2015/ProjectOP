using UnityEngine;
using System.Collections;

public class WheelMove : MonoBehaviour {

	public bool isFirstPersonView;
    private GameObject tank;

	private int count;

	void Start(){
        tank = GameObject.Find("Tank2");

		count = 0;
    }

	void Update(){
		WheelTouch ();
	}

	public void WheelTouch(){
		if (isFirstPersonView) {
			for (int i = 0; i < Input.touchCount; i++) {
				
				Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (i).position);
				RaycastHit hit;

				if (gameObject.GetComponent<TutorialManager> ().isTutorial) {
					if (gameObject.GetComponent<TutorialManager> ().onScene7) {
						if (Physics.Raycast (ray, out hit) && hit.collider.tag == "FrontRight") {
							if (Physics.Raycast (ray, out hit) && hit.collider.tag == "FrontLeft") {
								tank.SendMessage ("setRightWheelDirect", 1);
								tank.SendMessage ("setLeftWheelDirect", 1);
								count++;
								if (count == 120) {
									count = 0;
									gameObject.SendMessage ("Scene8");
								}
							}
						}
					}
					if (gameObject.GetComponent<TutorialManager> ().onScene8) {
						if (Physics.Raycast (ray, out hit) && hit.collider.tag == "FrontRight") {
							if (!Physics.Raycast (ray, out hit) && hit.collider.tag == "FrontLeft") {
								tank.SendMessage ("setRightWheelDirect", 1);
								count++;
								if (count == 90) {
									count = 0;
									gameObject.SendMessage ("Scene9");
								}
							}
						}
					}
					if (gameObject.GetComponent<TutorialManager> ().onScene9) {
						if (!Physics.Raycast (ray, out hit) && hit.collider.tag == "FrontRight") {
							if (Physics.Raycast (ray, out hit) && hit.collider.tag == "FrontLeft") {
								tank.SendMessage ("setLeftWheelDirect", 1);
								count++;
								if (count == 90) {
									count = 0;
									gameObject.SendMessage ("Scene10");
								}
							}
						}
					}
					if (gameObject.GetComponent<TutorialManager> ().onScene12) {
						if (!Physics.Raycast (ray, out hit) && hit.collider.tag == "BackRight") {
							if (Physics.Raycast (ray, out hit) && hit.collider.tag == "BackLeft") {
								tank.SendMessage("setRightWheelDirect", -1);
								tank.SendMessage("setLeftWheelDirect", -1);
								count++;
								if (count == 120) {
									count = 0;
									gameObject.SendMessage ("Scene13");
								}
							}
						}
					}
				} else {
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

}
