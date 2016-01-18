using UnityEngine;
using System.Collections;

public class TankMove : MonoBehaviour {

    public float speed = 15; // 기본
    private float cycleSpeed;
    private bool outoMove, outoMoveForward;

	void Start () {
        cycleSpeed = speed * 5;
        outoMove = false;
        outoMoveForward = false;
    }
	
	void Update () {
        Moving();
        OutoMoving();
    }

    //기본 이동
    private void Moving()
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
            transform.Rotate(new Vector3(0, cycleSpeed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            outoMove = false;
            transform.Rotate(new Vector3(0, -cycleSpeed * Time.deltaTime, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (outoMove)
                outoMove = false;
            else
                outoMove = true;
        }
    } 

    // 자동이동
    private void OutoMoving()
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
