using UnityEngine;
using System.Collections;

public class Config : MonoBehaviour {
	

	//item info

	public static string[] itemName = new string[2]				
	{"peng","bb"};

	public static string[] itemInfo = new string[2]				
	{"fff","fff"};

	public Sprite[] itemSprite = new Sprite[2];				

	public static bool[] canUseItem = new bool[2]						
	{true,true};

	public static bool[] canGetItem = new bool[2]						
	{true,true};


	//objects info

	public static string[] objectName = new string[2]				
	{"gagag","gsgseg"};

	public static string[] massegeObject = new string[2]
	{"djdjdj","gkssgni"};

	public static bool[] canUseObject = new bool[2]
	{true,true};

	public static bool[] canFindObject = new bool[2]
	{true,true};

}
