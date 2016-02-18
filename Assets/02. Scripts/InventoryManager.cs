﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour {
	private int[] inventoryList;
	private int inventoryLimit;
	
	public ToggleGroup itemToggleGroup;
	private Toggle[] itemSlots;
	public GameObject selectedItemImage;
	public int selectedItemSlotNum;

	public GameObject[] items;
	private Sprite[] itemImages;
	public Sprite sprite_None;

	public Text itemName;
	public Text itemInfo;

	public GameObject item_Using_Question;
	public GameObject M_Chip_Using_Question;

	void Start(){

		inventoryLimit = 22;

		inventoryList = new int[inventoryLimit];
		for (int i = 0; i < inventoryLimit; i++)
			inventoryList[i] = -1;

		itemImages = new Sprite[inventoryLimit];
		for (int i = 0; i < inventoryLimit; i++)
			itemImages [i] = items [i].GetComponent <Image> ().sprite;

		itemSlots = new Toggle[inventoryLimit];
		for (int i = 0; i < inventoryLimit; i++)
			itemSlots [i] = items [i].GetComponent <Toggle> ();

		itemName.text = "아이템을 선택하세요.";
		itemInfo.text = "";

		item_Using_Question.SetActive (false);
		M_Chip_Using_Question.SetActive (false);
	}

	void Update(){
		GetInventoryItemImage ();
	}

	private void GetInventoryItemImage(){
		for (int i = 0; i < 22; i++) {
			items [i].GetComponent <Image> ().sprite = Config.itemSprite [inventoryList [i]];
			if (inventoryList [i] == -1)
				items [i].GetComponent <Image> ().sprite = sprite_None;
		}
	}

	public void GetItemInfo(){
		if (itemToggleGroup.AnyTogglesOn ()) {
			for (int i = 0; i < 22; i++) {
				if (itemSlots [i].isOn) {
					selectedItemSlotNum = i;

					selectedItemImage.GetComponent <Image> ().sprite = itemImages [i];
					itemName.text = Config.itemName [inventoryList [i]];
					itemInfo.text = Config.itemInfo [inventoryList [i]];
					if (Config.canUseItem [inventoryList [i]]) {
						if (i < 16) {
							item_Using_Question.SetActive (true);
							M_Chip_Using_Question.SetActive (false);
						} else {
							M_Chip_Using_Question.SetActive (true);
							item_Using_Question.SetActive (false);
						}
					} else {
						item_Using_Question.SetActive (false);
						M_Chip_Using_Question.SetActive (false);
					}
				}
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

	public void UseItem(){
		Debug.Log (selectedItemSlotNum + "번 슬롯의 아이템을 사용");
		items [selectedItemSlotNum].GetComponent<Image>().sprite = sprite_None;
		itemImages [selectedItemSlotNum] = sprite_None;
		GetItemInfo ();
		if (gameObject.GetComponent<TutorialManager>().isTutorial && selectedItemSlotNum == 0) {
			gameObject.SendMessage ("Scene6");
		}
	}

	public void LeaveItem(){
		Debug.Log (selectedItemSlotNum + "번 슬롯의 아이템을 버림");
		if (gameObject.GetComponent<TutorialManager> ().isTutorial && selectedItemSlotNum == 0) {
			gameObject.SendMessage ("ReceiveLog", "이 아이템은 버릴 수 없다.");
		} else {
			
		}
		inventoryList [selectedItemSlotNum] = -1;
		GetItemInfo ();
	}

	public void PlayM_Chip(){
		Debug.Log ((selectedItemSlotNum - 16) + "번 슬롯의 메모리칩을 재생");
	}
}