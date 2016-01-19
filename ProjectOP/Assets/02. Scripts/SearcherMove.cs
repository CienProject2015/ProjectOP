using UnityEngine;
using System.Collections;

public class SearcherMove : MonoBehaviour {

    public int cycleSpeed = 20;
    private bool onOff;
    private GameObject searchCamera;

    public Vector2 nowPos, prePos;
    public Vector3 movePos;

    void Start () {
        onOff = false;
        searchCamera = transform.Find("SearchCamera").gameObject;
    }

	void Update () {
        if(onOff)
            Moving();
	}

    private void Moving()
    {
        if (Input.GetKey(KeyCode.W))
            searchCamera.transform.Rotate(new Vector3(-cycleSpeed * Time.deltaTime, 0, 0));
        else if (Input.GetKey(KeyCode.S))
            searchCamera.transform.Rotate(new Vector3(cycleSpeed * Time.deltaTime,0, 0));
        else if (Input.GetKey(KeyCode.A))
            transform.Rotate(new Vector3(0, -cycleSpeed * Time.deltaTime, 0));
        else if (Input.GetKey(KeyCode.D))
            transform.Rotate(new Vector3(0, cycleSpeed * Time.deltaTime, 0));
    }
    public void OnOff(bool onOff)
    {
            this.onOff = onOff; 
    }
}
