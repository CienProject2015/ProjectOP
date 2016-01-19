using UnityEngine;
using System.Collections;

public class ThirdPersonViewCameraMoving : MonoBehaviour {

	public bool isThirdPersonView;
	public Camera mainCamera;
	public float cameraRotateXSpeed;
	public float cameraRotateYSpeed;

	void Update () {
		if (isThirdPersonView) {
			mainCamera.transform.Rotate (0, 0, 0 - mainCamera.transform.rotation.z);
			for (int i = 0; i < Input.touchCount; i++) {
				Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch(i).position);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit) && hit.collider.tag == "Camera Moving Field") {
					mainCamera.transform.Rotate (Input.GetTouch (i).deltaPosition.y * cameraRotateYSpeed, Input.GetTouch (i).deltaPosition.x * cameraRotateXSpeed, 0);
					Debug.Log (Input.GetTouch (i).deltaPosition.x);
				}
			}
		}
	}
}
