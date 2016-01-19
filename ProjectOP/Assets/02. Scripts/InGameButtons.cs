using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class InGameButtons : MonoBehaviour {

	public GameObject settingsButton;
	public GameObject inventoryButton;
	public GameObject pictureButton;

	public void ViewChangeButtonPressed(bool thirdPersonView){
		if (thirdPersonView){
			gameObject.GetComponent<WheelMove> ().isFirstPersonView = false;
			gameObject.GetComponent<ThirdPersonViewCameraMoving> ().isThirdPersonView = true;
			Debug.Log ("thirdPersonView");
		} else {
			gameObject.GetComponent<WheelMove> ().isFirstPersonView = true;
			gameObject.GetComponent<ThirdPersonViewCameraMoving> ().isThirdPersonView = false;
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
		if (isExtended) {
			Debug.Log ("MenuExtension");
		} 
		else if (!isExtended){
			Debug.Log ("MenuReduction");
		}
		settingsButton.GetComponent<Button> ().interactable = isExtended;
		inventoryButton.GetComponent<Button> ().interactable = isExtended;
		pictureButton.GetComponent<Button> ().interactable = isExtended;
	}
}
