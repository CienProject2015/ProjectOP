using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour {

	public GameObject selectedItemImage;
	public GameObject[] items;
	private Sprite[] itemImages;
	public ToggleGroup itemToggleGroup;
	private Toggle[] itemSelects;
	public Sprite sprite_None;

	void Start(){
		itemImages = new Sprite[22];
		for (int i = 0; i < 22; i++)
			itemImages [i] = items [i].GetComponent <Image> ().sprite;

		itemSelects = new Toggle[22];
		for (int i = 0; i < 22; i++)
			itemSelects [i] = items [i].GetComponent <Toggle> ();
	}

	public void GetItemImage(){
		if (itemToggleGroup.AnyTogglesOn ()) {
			for (int i = 0; i < 22; i++) {
				if (itemSelects [i].isOn)
					selectedItemImage.GetComponent <Image> ().sprite = itemImages [i];
			}
		}
		else
			selectedItemImage.GetComponent <Image> ().sprite = sprite_None;
	}

	public void GetItemInfo(){
		
	}
}