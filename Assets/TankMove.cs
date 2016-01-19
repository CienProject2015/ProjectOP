using UnityEngine;
using UnityEditor;
using System.Collections;

public class TankMove : MonoBehaviour {
    public int moveSpeed;
    // Use this for initialization
    void Start () {
        moveSpeed = 2;
    }
	
	// Update is called once per frame
	void Update () {
        tank_move();
    }

    void tank_move()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
    }

    void tank_stop()
    {
        moveSpeed = 0;
    }

    void tank_start()
    {
        Debug.Log("tank_start");
        moveSpeed = 2;
    }
}
