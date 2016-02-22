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
	public AudioClip[] clips;

	void Start () {
		bgm.PlayOneShot (clips [0], 3f);
	}

	void Update () {
		
	}

	public void bgmPlay1(){
		bgm.clip = clips [1];
	}

	public void ClickSound(){
		ui.PlayOneShot (clips[15]);
	}
}
