using UnityEngine;
using System.Collections;

using UnityStandardAssets.ImageEffects;

public class NoiseControl : MonoBehaviour {
	NoiseAndGrain noise;
	bool noiseTab;
	// Use this for initialization
	void Start () {
		noise = GameObject.Find ("MainCamera").GetComponent<NoiseAndGrain> ();
		noise.generalIntensity = 10f;
		noiseTab = false;
		//GameObject.Find
	}
	
	// Update is called once per frame
	void Update () {
		if (noiseTab) {
			noiseTab = false;
			noise.generalIntensity = 8f;
		} else {
			noiseTab = true;
			noise.generalIntensity = 10f;
		}
		noise.generalIntensity += 1f;
	}
}
