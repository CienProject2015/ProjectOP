using UnityEngine;
using System.Collections;

public class ThirdPersonViewCameraMoving : MonoBehaviour {

	public bool isThirdPersonView;
	public GameObject searcher;
	public Camera searchCamera;
	public float cameraRotateXSpeed;
	public float cameraRotateYSpeed;


    void Update()
    {
		if (isThirdPersonView) {
			searchCamera.enabled = true;
			searchCamera.transform.Rotate (0, 0, 0 - searchCamera.transform.rotation.z);
			for (int i = 0; i < Input.touchCount; i++) {
				Ray ray = searchCamera.ScreenPointToRay (Input.GetTouch (i).position);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit) && hit.collider.tag == "Camera Moving Field") {
					searcher.transform.Rotate (0, Input.GetTouch (i).deltaPosition.x * cameraRotateXSpeed, 0);
					searchCamera.transform.Rotate (Input.GetTouch (i).deltaPosition.y * cameraRotateYSpeed, 0, 0);
					Debug.Log (Input.GetTouch (i).deltaPosition.x);
				}
			}
		} else {
			searchCamera.enabled = false;
		}
    }
}