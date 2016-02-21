using UnityEngine;
using System.Collections;

public class PenguinMove : MonoBehaviour {

    public float speed;

    private Animator anim;
	public GameObject tank2;
	public GameObject spot;
    private float distance, distanceMin = 15, distanceMax = 20, tankSpeed =0;
	float temp, timer = 0;
	bool isSpot = false, onRandomAnim=true;
	int currentAnimNum =0;
    
	void Start () {
        anim = GetComponent<Animator>();
		Physics.gravity  = new Vector3(0,-100f,0);
	}

	void Update () {
		

		transform.LookAt(tank2.transform);
		tankSpeed = tank2.GetComponent<TankMove>().speed;
        anim.SetFloat("Speed", speed);
		distance = Vector3.Distance(tank2.transform.position, transform.position);
		if (distance >= distanceMin) {
			isSpot = false;
			onRandomAnim = true;
			transform.LookAt (tank2.transform);
			transform.Translate (transform.forward * speed * Time.deltaTime);
		
			if (distance > distanceMax)
				speed = 15;
			else
				speed = 5;
		} else {
			if (!isSpot) {
				transform.LookAt (spot.transform);
				transform.Translate (transform.forward * speed * Time.deltaTime);
			} else {
				speed = 0;	
				if (onRandomAnim) {
					anim.SetBool (choiceAnim (currentAnimNum), false);
					randomAnim ();
					onRandomAnim = false;
				} else {
				}

			}
		}
	}

	void randomAnim(){
		int num=0;
		for (int i = 0; i < 10; i++) {
			num = Random.Range (1, 12);
		}
		currentAnimNum = num;
		Debug.Log (currentAnimNum  + "Anim");
		anim.SetBool (choiceAnim (currentAnimNum), true);
	}

	string choiceAnim(int num){
		string name = null;

		switch (num) {
		case 1: // happy
			name = "Happy";
			break;
		case 2: // wave
			name = "Wave";
			break;
		case 3: // swing
			name = "Swing";
			break;
		case 4: // curius
			name = "Curius";
			break;
		case 5: // sullen
			name = "Sullen";
			break;
		case 6: // totem
			name = "Totem";
			break;
		case 7: // tool
			name = "Tool";
			break;
		case 8: // hug
			name = "Hug";
			break;
		case 9: // block
			name = "Block";
			break;
		case 10: // sad
			name = "Sad";
			break;
		case 11: // urge
			name = "Urge";
			break;
		default:
			name = "block";
			break;
		}

		return name;
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.name == "Spot") {
			isSpot = true;
		}
	}
}

