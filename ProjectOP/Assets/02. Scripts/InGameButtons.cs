using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class InGameButtons : MonoBehaviour {

	public GameObject UIBackground;
	public GameObject menuButtons;

	public void ViewChangeButtonPressed(bool thirdPersonView){
		Debug.Log ("Check");

		gameObject.GetComponent<WheelMove> ().isFirstPersonView = !thirdPersonView;
		gameObject.GetComponent<ThirdPersonViewCameraMoving> ().isThirdPersonView = thirdPersonView;
		UIBackground.SetActive (!thirdPersonView);
		menuButtons.SetActive (!thirdPersonView);

	}

	public void FirstAnimPressed(){
		GameObject.Find ("Penguin").GetComponent<Animator>().SetBool("Wave",true);
		GameObject.Find ("Penguin").GetComponent<Animator>().SetBool("Jump",false);
		GameObject.Find ("Penguin").GetComponent<Animator>().SetBool("Swing",false);
	}

	public void SecondAnimPressed(){
		GameObject.Find ("Penguin").GetComponent<Animator>().SetBool("Wave",false);
		GameObject.Find ("Penguin").GetComponent<Animator>().SetBool("Jump",true);
		GameObject.Find ("Penguin").GetComponent<Animator>().SetBool("Swing",false);
	}

	public void ThirdAnimPressed(){
		GameObject.Find ("Penguin").GetComponent<Animator>().SetBool("Wave",false);
		GameObject.Find ("Penguin").GetComponent<Animator>().SetBool("Jump",false);
		GameObject.Find ("Penguin").GetComponent<Animator>().SetBool("Swing",true);
	}

	public void MenuExtensionButtonPressed(bool isExtended){
		GameObject.Find ("SettingsButton").GetComponent<Button> ().interactable = isExtended;
		GameObject.Find ("InventoryButton").GetComponent<Button> ().interactable = isExtended;
		GameObject.Find ("PictureButton").GetComponent<Button> ().interactable = isExtended;
	}
}
