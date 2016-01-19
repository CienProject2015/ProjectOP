using UnityEngine;
using System.Collections;

public class PenguinMove : MonoBehaviour {

    public float speed;

    private Animator anim;
    private GameObject tank;
    private float distance, distanceMin = 20, distanceMax = 20, tankSpeed;
    
    
	void Start () {
        anim = GetComponent<Animator>();
        tank = GameObject.Find("Tank");
	}

	void Update () {
        tankSpeed = tank.GetComponent<TankMove>().speed;
        anim.SetFloat("Speed", speed);
        distance = Vector3.Distance(tank.transform.position, transform.position);
        if (distance > distanceMin)
        {
			anim.SetBool("Wave", false);
			anim.SetBool("Jump", false);
			anim.SetBool("Swing", false);
            transform.LookAt(tank.transform);
            transform.Translate(transform.forward * speed * Time.deltaTime);
            if (distance > distanceMax)
                speed = 15;
            else
                speed = 5;
        }
        else
            speed = 0;
	}
}
