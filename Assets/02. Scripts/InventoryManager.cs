using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour {

	public int[] inventoryList;

	public GameObject selectedItemImage;
	public GameObject[] items;
	private Sprite[] itemImages;
	public ToggleGroup itemToggleGroup;
	private Toggle[] itemSelects;
	public Sprite sprite_None;

	public Text itemName;
	public Text itemInfo;

	public GameObject item_Using_Question;
	public GameObject M_Chip_Using_Question;

	void Start(){
		inventoryList = new int[22];

		itemImages = new Sprite[22];
		for (int i = 0; i < 22; i++)
			itemImages [i] = items [i].GetComponent <Image> ().sprite;

		itemSelects = new Toggle[22];
		for (int i = 0; i < 22; i++)
			itemSelects [i] = items [i].GetComponent <Toggle> ();

		itemName.text = "아이템을 선택하세요.";
		itemInfo.text = "";

		item_Using_Question.SetActive (false);
		M_Chip_Using_Question.SetActive (false);
	}

	public void GetItemInfo(){
		if (itemToggleGroup.AnyTogglesOn ()) {
			for (int i = 0; i < 22; i++) {
				if (itemSelects [i].isOn)
					selectedItemImage.GetComponent <Image> ().sprite = itemImages [i];
			}
		} else {
			selectedItemImage.GetComponent <Image> ().sprite = sprite_None;
		}

		if (selectedItemImage.GetComponent <Image> ().sprite == sprite_None) {
			itemName.text = "아이템을 선택하세요.";
			itemInfo.text = "";		
			item_Using_Question.SetActive (false);
			M_Chip_Using_Question.SetActive (false);
		}
	}
}