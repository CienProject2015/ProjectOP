using UnityEngine;
using System.Collections;

public class ThirdPersonViewCameraMoving : MonoBehaviour {

	public bool isThirdPersonView;
	public Camera mainCamera;
	public float cameraRotateSpeed;

	void Update () {
		if (isThirdPersonView) {
			for (int i = 0; i < Input.touchCount; i++) {
				Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch(i).position);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit) && hit.collider.tag == "Camera Moving Field") {
					mainCamera.transform.Rotate (0, Input.GetTouch (i).deltaPosition.x * cameraRotateSpeed, 0);
					Debug.Log (Input.GetTouch (i).deltaPosition.x);
				}
			}
		}
	}
}
