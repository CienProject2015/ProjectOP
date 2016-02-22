using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	private AudioSource audioSource;
	public AudioClip[] AudioClips;

	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
