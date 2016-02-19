using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class InGameButtons : MonoBehaviour {

	public GameObject UIBackground;
	public GameObject stateWindow;
	public GameObject menuButtons;
	public GameObject viewRetrunButton;
	public GameObject pictureMenu,tank2Button,sheacherButton,UIButton,penguinButton;
	public GameObject menuButtonsText1, menuButtonsText2, menuButtonsText3, menuButtonsText4, menuButtonsText5, GameCloseButtonImage;
	public GameObject extensionButtonsText;
	public GameObject SettingsMenuCanvus, SettingsMenu, CreditMenu;
	public GameObject ItemMenuCanvus, MapCanvus;
	public GameObject GameClosePopUp;
	public GameObject[] UIs;
	GameObject penguin;
	//GameObject tempPenguin;

	void Start(){
		penguin = GameObject.Find ("Penguin");
	}


	public void ViewChangeButtonPressed(bool thirdPersonView){

		gameObject.GetComponent<WheelMove> ().isFirstPersonView = !thirdPersonView;
		gameObject.GetComponent<ThirdPersonViewCameraMoving> ().isThirdPersonView = thirdPersonView;
		if (!pictureMenu.activeSelf) {
			UIBackground.SetActive (!thirdPersonView);
			viewRetrunButton.SetActive (thirdPersonView);
		}
	}

	public void PictureButtonPressed(bool pictureMenuOpened){
		pictureMenu.SetActive (pictureMenuOpened);

		if (!pictureMenuOpened) {
			GameObject.Find ("Tank2").transform.FindChild ("Body").gameObject.SetActive (true);
			ViewChangeButtonPressed (false);
			penguin.transform.position = new Vector3(penguin.transform.position.x,0,penguin.transform.position.z);
			penguin.GetComponent<Rigidbody> ().useGravity = true;
			tank2Button.GetComponent<Image> ().enabled = true;
			sheacherButton.GetComponent<Image> ().enabled = true;
			UIButton.GetComponent<Image> ().enabled = true;
			penguinButton.GetComponent<Image> ().enabled = true;
		}
	}

	public void PictureMenuButtonsPressed(GameObject pictureMenuButton){
		if (pictureMenuButton.GetComponent<Image> ().enabled) {
			pictureMenuButton.GetComponent<Image> ().enabled = false;

			if (pictureMenuButton.name == "Tank2Button")
				GameObject.Find ("Tank2").transform.FindChild ("Body").gameObject.SetActive (false);
			else if (pictureMenuButton.name == "SearcherButton") {
				ViewChangeButtonPressed (true);
			} else if (pictureMenuButton.name == "UIButton") {
				foreach (GameObject UI in UIs) {
					UI.SetActive (false);
				}	
			} else if (pictureMenuButton.name == "PenguinButton") {
				penguin.transform.Translate (new Vector3 (0, -4, 0));
				penguin.GetComponent<Rigidbody> ().useGravity = false;
			} else if (pictureMenuButton.name == "ShootButton")
				Application.CaptureScreenshot ("WarmyLand.png");

		} else {
			pictureMenuButton.GetComponent<Image> ().enabled = true;

			if (pictureMenuButton.name == "Tank2Button")
				GameObject.Find ("Tank2").transform.FindChild ("Body").gameObject.SetActive (true);
			else if (pictureMenuButton.name == "SearcherButton") {
				ViewChangeButtonPressed (false);
			} else if (pictureMenuButton.name == "UIButton") {
				foreach (GameObject UI in UIs) {
					UI.SetActive (true);
				}
			} else if (pictureMenuButton.name == "PenguinButton") {
				penguin.transform.position = new Vector3(penguin.transform.position.x,0,penguin.transform.position.z);
				penguin.GetComponent<Rigidbody> ().useGravity = true;
			}
		}
	}
		
	public void MenuExtensionButtonPressed(bool isExtended){
		GameObject.Find ("SettingsButton").GetComponent<Button> ().interactable = isExtended;
		GameObject.Find ("InventoryButton").GetComponent<Button> ().interactable = isExtended;
		GameObject.Find ("PictureButton").GetComponent<Button> ().interactable = isExtended;
		GameObject.Find ("ViewChangeButton").GetComponent<Button> ().interactable = isExtended;
		GameObject.Find ("MapButton").GetComponent<Button> ().interactable = isExtended;
		GameObject.Find ("GameCloseButton").GetComponent <Button> ().interactable = isExtended;
		menuButtonsText1.SetActive (isExtended);
		menuButtonsText2.SetActive (isExtended);
		menuButtonsText3.SetActive (isExtended);
		menuButtonsText4.SetActive (isExtended);
		menuButtonsText5.SetActive (isExtended);
		GameCloseButtonImage.SetActive (isExtended);
		stateWindow.SetActive (!isExtended);
		if (isExtended) {
			if (gameObject.GetComponent<TutorialManager> ().isTutorial) {
				if (gameObject.GetComponent<TutorialManager> ().isItemTutorial) {
					GameObject.Find ("_EventSystem").GetComponent<TutorialButtonGuide> ().StopTwinkle (GameObject.Find ("ExtensionButton"));
					GameObject.Find ("_EventSystem").GetComponent<TutorialButtonGuide> ().StartTwinkle (GameObject.Find ("InventoryButton"));
				}
			}
			extensionButtonsText.GetComponent<Text> ().text = "축소";
		}else if (!isExtended)
			extensionButtonsText.GetComponent<Text> ().text = "확장";
	}

	public void SettingsButtonPressed(){
		SettingsMenuCanvus.SetActive (true);
		SettingsMenu.SetActive (true);
		CreditMenu.SetActive (false);
	}

	public void SettingsTapPressed(){
		SettingsMenu.SetActive (true);
		CreditMenu.SetActive (false);
	}

	public void CreditTapPressed(){
		SettingsMenu.SetActive (false);
		CreditMenu.SetActive (true);
	}

	public void ItemButtonPressed(){
		ItemMenuCanvus.SetActive (true);
		if (gameObject.GetComponent<TutorialManager> ().isTutorial) {
			if (gameObject.GetComponent<TutorialManager> ().isItemTutorial) {
				GameObject.Find ("_EventSystem").GetComponent<TutorialButtonGuide> ().StopTwinkle (GameObject.Find ("InventoryButton"));
				GameObject.Find ("_EventSystem").GetComponent<TutorialButtonGuide> ().StartTwinkle (GameObject.Find ("Item Image 1"));
			}
		}
	}

	public void MapButtonPressed(){
		MapCanvus.SetActive (true);
	}

	public void CloseButtonPressed(){
		SettingsMenuCanvus.SetActive (false);
		ItemMenuCanvus.SetActive (false);
		MapCanvus.SetActive (false);
		GameClosePopUp.SetActive (false);
	}

	public void GameCloseButtonPressed(){
		GameClosePopUp.SetActive (true);
	}

	public void GameClose(){
		GameObject.Find ("GameInfo").GetComponent<GameSaveLoad> ().SaveGame ();
		Application.Quit();
	}
}
