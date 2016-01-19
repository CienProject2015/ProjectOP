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
		GameObject.Find ("Penguin").GetComponent<Animator>().SetBool("Wave",true);
		GameObject.Find ("Penguin").GetComponent<Animator>().SetBool("Jump",false);
		GameObject.Find ("Penguin").GetComponent<Animator>().SetBool("Swing",false);
		//Debug.Log ("FirstAnim");
	}

	public void SecondAnimPressed(){
		GameObject.Find ("Penguin").GetComponent<Animator>().SetBool("Wave",false);
		GameObject.Find ("Penguin").GetComponent<Animator>().SetBool("Jump",true);
		GameObject.Find ("Penguin").GetComponent<Animator>().SetBool("Swing",false);
		//Debug.Log ("SecondAnim");
	}

	public void ThirdAnimPressed(){
		GameObject.Find ("Penguin").GetComponent<Animator>().SetBool("Wave",false);
		GameObject.Find ("Penguin").GetComponent<Animator>().SetBool("Jump",false);
		GameObject.Find ("Penguin").GetComponent<Animator>().SetBool("Swing",true);
		//Debug.Log ("ThirdAnim");
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
