﻿using UnityEngine;
using System.Collections;

public class Config : MonoBehaviour {
	
	// code 0 : empty

	//item info

	public static string[] itemName = new string[2]				
	{"empty","bb"};

	public static string[] itemInfo = new string[2]				
	{"fff","fff"};

	public static Sprite[] itemSprite = new Sprite[2]
	{ null, null };

	public static bool[] canUseItem = new bool[2]						
	{true,true};

	public static bool[] canGetItem = new bool[2]						
	{true,true};


	//objects info

	public static string[] objectName = new string[2]				
	{"empty","gsgseg"};

	public static string[] massegeObject = new string[2]
	{"djdjdj","gkssgni"};

	public static bool[] canUseObject = new bool[2]
	{true,true};

	public static bool[] canFindObject = new bool[2]
	{true,true};



	//memoryChip info

	public static string[] memoryChipName = new string[2]				
	{"empty","mnmnmnm"};

	public static string[] memoryChipInfo = new string[2]
	{"asddd","ffssa"};

	public static int[] totalMemoryChip = new int[2]
	{5,3};

	public static bool[] onMemoryChip = new bool[2]
	{true,true};

}
