using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class TutorialButtonGuide : MonoBehaviour {

	private bool fadeout;

	void Start(){
		fadeout = true;
	}

	public void StartTwinkle(GameObject target){
		target.transform.Find("ButtonGuide").GetComponent <Image> ().color = new Color (1, 1, 1, 1);
		StartCoroutine (TwinkleAnim(target));
	}

	public void StopTwinkle(GameObject target){
		target.transform.Find("ButtonGuide").GetComponent <Image> ().color = new Color (1, 1, 1, 0);
	}

	IEnumerator TwinkleAnim(GameObject target){
		while (true) {
			if (target.transform.Find ("ButtonGuide").GetComponent <Image> ().color.a == 0)
				yield break;
			if (fadeout) {
				target.transform.Find("ButtonGuide").GetComponent <Image> ().color -= new Color (0, 0, 0, 0.02f);
				if (target.transform.Find("ButtonGuide").GetComponent <Image> ().color.a < 0.3f) {
					fadeout = false;
				}
			} else if (!fadeout) {
				target.transform.Find("ButtonGuide").GetComponent <Image> ().color += new Color (0, 0, 0, 0.02f);
				if (target.transform.Find("ButtonGuide").GetComponent <Image> ().color.a > 1) {
					fadeout = true;
				}
			}
			yield return null;
		}
	}
}