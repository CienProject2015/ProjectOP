using UnityEngine;
using UnityEditor;
using System.Collections;

public class TankMove : MonoBehaviour {
    public int moveSpeed = 2;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        //var moveSpeed = 1;
	    if(Input.GetKey(KeyCode.LeftArrow) == true)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
    }
    void tank_stop(int speed)
    {
        transform.Translate(Vector3.back * speed);
    }
}
