using UnityEngine;
using System.Collections;

public class InGameButtons : MonoBehaviour {

	public void ViewChangeButtonPressed(bool thirdPersonView){

		if (thirdPersonView){
			gameObject.GetComponent<WheelMove> ().isFirstPersonView = false;
			gameObject.GetComponent<ThirdPersonViewCameraMoving> ().isThirdPersonView = true;
			//Debug.Log ("thirdPersonView");
		} else {
			gameObject.GetComponent<WheelMove> ().isFirstPersonView = true;
			gameObject.GetComponent<ThirdPersonViewCameraMoving> ().isThirdPersonView = false;
			//Debug.Log ("FirstPersonView");
		}
	}

	public void FirstAnimPressed(){
		GameObject.Find ("Penguin").GetComponent<Animator>().SetBool("jump",true);
		Debug.Log ("FirstAnim");
	}

	public void SecondAnimPressed(){
		Debug.Log ("SecondAnim");
	}

	public void ThirdAnimPressed(){
		Debug.Log ("ThirdAnim");
	}

	public void MenuExtensionButtonPressed(bool isExtended){
		if (isExtended == true) {
			Debug.Log ("MenuExtension");
		} 
		else {
			Debug.Log ("MenuReduction");
		}
	}
}
