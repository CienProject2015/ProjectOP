﻿using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class AlertScreenAnim : MonoBehaviour {

	private bool fadeout;

	void Start(){
		fadeout = true;

		gameObject.GetComponent <Image> ().color = new Color (1, 1, 1, 0);
	}

	public void StartAlertAnim(){
		gameObject.GetComponent <Image> ().color = new Color (1, 1, 1, 1);
		StopCoroutine ("AlertAnim");
		StartCoroutine ("AlertAnim");
	}

	public void StopAlertAnim(){
		StopCoroutine ("AlertAnim");
		StartCoroutine ("AlertAnimEnd");
	}

	IEnumerator AlertAnim(){
		while (true) {
			if (fadeout) {
				gameObject.GetComponent <Image> ().color -= new Color (0, 0, 0, 0.05f);
				if (gameObject.GetComponent <Image> ().color.a < 0.3f) {
					fadeout = false;
				}
			} else if (!fadeout) {
				gameObject.GetComponent <Image> ().color += new Color (0, 0, 0, 0.05f);
				if (gameObject.GetComponent <Image> ().color.a > 1) {
					fadeout = true;
				}
			}
			yield return null;
		}
	}

	IEnumerator AlertAnimEnd(){
		while (gameObject.GetComponent <Image> ().color.a > 0){
			gameObject.GetComponent <Image> ().color -= new Color (0, 0, 0, 0.02f);
			yield return null;
		}
	}
}