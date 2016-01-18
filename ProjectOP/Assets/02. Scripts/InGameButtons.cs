using UnityEngine;
using System.Collections;

public class InGameButtons : MonoBehaviour {

	public void ViewChangeButtonPressed(bool thirdPersonView){
		if (thirdPersonView){
			Debug.Log ("thirdPersonView");
		} else {
			Debug.Log ("FirstPersonView");
		}
	}

	public void FirstAnimPressed(){
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
