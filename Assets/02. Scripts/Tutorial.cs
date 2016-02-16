using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	public GameObject penguin, tank2;
	private Animator anim;
	float penguinSpeed;
	float currentTime=0;
	// Use this for initialization
	void Start () {
		anim = penguin.GetComponent<Animator>();
		penguinSpeed = 2;
		anim.SetFloat ("Speed", 10);
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += 1*Time.deltaTime;

		//////// 고속도로 타고온다 ///
		///탱크 임의 조작 막아뒤야 한다 //

		//if (tank2.transform.position.z + 5 < penguin.transform.position.z) {
		if (currentTime <= 7) {
			anim.SetFloat ("Speed", 10);
			penguin.transform.LookAt (tank2.transform);
			penguin.transform.Translate (transform.forward * penguinSpeed * Time.deltaTime);
		}
		//////
		if (currentTime > 6 && currentTime <= 12) {
			anim.SetFloat ("Speed", 0);
			anim.SetBool ("Happy", true);
		}
		//////
		if (currentTime > 10 && currentTime < 13) {
			anim.SetBool ("Happy", false);
			tank2.transform.Translate(new Vector3(0,0,-4*Time.deltaTime)); 
		}
		//////
		if (currentTime > 13 && currentTime < 19) {
				anim.SetFloat ("Speed", 20);
			if(currentTime > 17)
				anim.SetFloat ("Speed", 10);
			penguin.transform.LookAt (tank2.transform);
			penguin.transform.Translate (transform.forward * penguinSpeed * Time.deltaTime);
		}
		////
		if (currentTime > 18 && currentTime < 21) {
			anim.SetFloat ("Speed", 0);
			anim.SetBool ("Happy", true);
		}
		////
		if(currentTime > 21)
			anim.SetBool ("Happy", false);
		if (currentTime > 22 && currentTime < 24) {
			penguin.transform.Rotate(new Vector3(0,100*Time.deltaTime, 0));
		}
		//
		if (currentTime >= 24 && currentTime < 30) {
			anim.SetFloat ("Speed", 20);
			penguin.transform.Translate (transform.forward * penguinSpeed * Time.deltaTime);
		}
		/////// 고속도로 타고 간다 ///////
		Debug.Log (currentTime);
	}
}
