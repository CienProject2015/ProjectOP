using UnityEngine;
using System.Collections;

public class ThirdPersonViewCameraMoving : MonoBehaviour {

	public bool isThirdPersonView;
	public Camera searchCamera;
	public float cameraRotateXSpeed;
	public float cameraRotateYSpeed;

    private bool onOff;
    private GameObject searcher,tank;

    void Start()
    {
        onOff = false;
        //searchCamera = GameObject.Find("SearchCamera").GetComponent<Camera>();
        tank = GameObject.Find("Tank");
    }
    void Update()
    {
        if (onOff)
            Moving();
    }

    void Moving () {
		if (isThirdPersonView) {
            tank.GetComponent<TankMove>().speed = 0;
            searchCamera.transform.Rotate (0, 0, 0 - searchCamera.transform.rotation.z);
			for (int i = 0; i < Input.touchCount; i++) {
				Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch(i).position);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit) && hit.collider.tag == "Camera Moving Field") {
                    transform.Rotate(0, Input.GetTouch(i).deltaPosition.x * cameraRotateXSpeed, 0);
                    searchCamera.transform.Rotate (Input.GetTouch (i).deltaPosition.y * cameraRotateYSpeed, 0, 0);
					Debug.Log (Input.GetTouch (i).deltaPosition.x);
				}
			}
        }
        else
        {
            tank.GetComponent<TankMove>().speed = 15;
        }
	}

    public void OnOff(bool onOff)
    {
        this.onOff = onOff;
    }
}
