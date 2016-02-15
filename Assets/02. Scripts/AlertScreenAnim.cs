using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class AlertScreenAnim : MonoBehaviour {

	private bool fadeout;
	public bool AlertAnimStop;

	void Start(){
		fadeout = true;
		AlertAnimStop = false;

		gameObject.GetComponent <Image> ().color = new Color (1, 1, 1, 0);
	}

	public void StartAlertAnim(){
		gameObject.GetComponent <Image> ().color = new Color (1, 1, 1, 1);
		AlertAnimStop = false;
		StartCoroutine ("AlertAnim");
	}

	public void StopAlertAnim(){
		AlertAnimStop = true;
	}

	IEnumerator AlertAnim(){
		while (true) {
			if (AlertAnimStop) {
				gameObject.GetComponent <Image> ().color = new Color (1, 1, 1, 0);
				yield break;
			}
			if (fadeout) {
				gameObject.GetComponent <Image> ().color -= new Color (0, 0, 0, 0.05f);
				if (gameObject.GetComponent <Image> ().color.a < 0.1f) {
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
}
