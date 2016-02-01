using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class InGameButtons : MonoBehaviour {

	public GameObject UIBackground;
	public GameObject stateWindow;
	public GameObject menuButtons;
	public GameObject viewRetrunButton;
	public GameObject menuButtonsText1;
	public GameObject menuButtonsText2;
	public GameObject menuButtonsText3;
	public GameObject menuButtonsText4;
	public GameObject menuButtonsText5;
	public GameObject extensionButtonsText;


	public void ViewChangeButtonPressed(bool thirdPersonView){
		Debug.Log ("Check");

		gameObject.GetComponent<WheelMove> ().isFirstPersonView = !thirdPersonView;
		gameObject.GetComponent<ThirdPersonViewCameraMoving> ().isThirdPersonView = thirdPersonView;
		UIBackground.SetActive (!thirdPersonView);
		viewRetrunButton.SetActive (thirdPersonView);
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
		GameObject.Find ("ViewChangeButton").GetComponent<Button> ().interactable = isExtended;
		GameObject.Find ("MapButton").GetComponent<Button> ().interactable = isExtended;
		menuButtonsText1.SetActive (isExtended);
		menuButtonsText2.SetActive (isExtended);
		menuButtonsText3.SetActive (isExtended);
		menuButtonsText4.SetActive (isExtended);
		menuButtonsText5.SetActive (isExtended);
		stateWindow.SetActive (!isExtended);
		if (isExtended)
			extensionButtonsText.GetComponent<Text> ().text = "축소";
		else if (!isExtended)
			extensionButtonsText.GetComponent<Text> ().text = "확장";
				
			
			
	}
}
