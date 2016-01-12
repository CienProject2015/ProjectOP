using UnityEngine;
using System.Collections;

public class TankMove : MonoBehaviour {

    public int speed = 3; // 기본 3
    int rotateSpeed;
    public bool outoMove = false;
    bool outoMoveForward = false;
	void Start () {
        rotateSpeed = speed * 5;
    }
	
	// Update is called once per frame
	void Update () {
        Moving();
        OutoMoving();
        
    }

    void Moving()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            outoMove = false;
            outoMoveForward = true; // 앞쪽 자동이동
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            outoMove = false;
            outoMoveForward = false; // 뒤쪽 자동이동
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            outoMove = false; // 자동이동 취소
            transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            outoMove = false;
            transform.Rotate(new Vector3(0, -rotateSpeed * Time.deltaTime, 0));
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (outoMove)
                outoMove = false;
            else
                outoMove = true;
        }
    } 

    void OutoMoving()
    {
        if (outoMove)
        {
            if(outoMoveForward)
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            else
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
    }
}
