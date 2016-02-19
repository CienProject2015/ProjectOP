using UnityEngine;
using System.Collections;

public class PenguinMove : MonoBehaviour {

    public float speed;

    private Animator anim;
	public GameObject tank2;
    private float distance, distanceMin = 20, distanceMax = 20, tankSpeed = 20;
    
    
	void Start () {
        anim = GetComponent<Animator>();
		Physics.gravity  = new Vector3(0,-100f,0);
	}

	void Update () {
		transform.LookAt(tank2.transform);
		tankSpeed = tank2.GetComponent<TankMove>().speed;
        anim.SetFloat("Speed", speed);
		distance = Vector3.Distance(tank2.transform.position, transform.position);
        if (distance > distanceMin)
        {
			anim.SetBool("Wave", false);
			anim.SetBool("Jump", false);
			anim.SetBool("Swing", false);
			transform.LookAt(tank2.transform);
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
