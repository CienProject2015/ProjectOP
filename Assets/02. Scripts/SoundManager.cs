using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public AudioSource bgm;
	public AudioSource piano;	//temp->Obj_Piano
	public AudioSource penguin;
	public AudioSource ui;
	public AudioSource wheel;	//tank2->Body->Box003
	public AudioSource wind;
	public AudioSource windChimes;
	public AudioClip[] Clips;

	void Start () {
		bgm.clip = Clips [0];
		bgm.Play ();
	}

	void Update () {
		
	}

	public void bgmPlay1(){
		bgm.clip = Clips [1];
	}
}
