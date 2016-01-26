using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class InGameButtons : MonoBehaviour {

	public GameObject UIBackground;
	public GameObject ExtensionButton;

	public void ViewChangeButtonPressed(bool thirdPersonView){
		Debug.Log ("Check");

		gameObject.GetComponent<WheelMove> ().isFirstPersonView = !thirdPersonView;
		gameObject.GetComponent<ThirdPersonViewCameraMoving> ().isThirdPersonView = thirdPersonView;
		UIBackground.SetActive (!thirdPersonView);
		ExtensionButton.SetActive (!thirdPersonView);
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
		if (isExtended) {
			Debug.Log ("MenuExtension");
		} 
		else if (!isExtended){
			Debug.Log ("MenuReduction");
		}
		GameObject.Find ("SettingsButton").GetComponent<Button> ().interactable = isExtended;
		GameObject.Find ("InventoryButton").GetComponent<Button> ().interactable = isExtended;
		GameObject.Find ("PictureButton").GetComponent<Button> ().interactable = isExtended;
	}
}
