using UnityEngine;
using System.Collections;

using UnityStandardAssets.ImageEffects;

public class NoiseControl : MonoBehaviour {
	NoiseAndGrain noise;
	// Use this for initialization
	void Start () {
		noise = GameObject.Find ("MainCamera").GetComponent<NoiseAndGrain> ();
		//GameObject.Find
	}
	
	// Update is called once per frame
	void Update () {

		//noise.generalIntensity += 1;
	
	}
}
