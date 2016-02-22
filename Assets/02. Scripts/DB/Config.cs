using UnityEngine;
using System.Collections;

public class Config : MonoBehaviour {

	// code 0 : empty

	//item info

	public static string[] itemName = new string[3]
	{"empty","Items_lighter","Items_Penguin"};

	public static string[] itemInfo = new string[3]
	{
		"empty",
  	"불을 붙이는 물건이다. 지구에 있는 라이터와 거의 똑같은걸. 이걸로 쓰레기 더미를 소각한다.",
    "알 수 없는 문양이 나열되어 있는 문서다."
  };

	public static Sprite[] itemSprite = new Sprite[3]
	{ null, null,null };

	public static bool[] canUseItem = new bool[3]
	{false,false,false};


	//memoryChip info

	public static string[] memoryChipName = new string[11]
	{
		"empty",
		"Items_MemoryChip_hyup",
		"Items_MemoryChipBroken_hyup",
		"Items_MemoryChip_maeul",
		"Items_MemoryChip_bada",
		"Items_MemoryChipBroken_bada",
		"Items_MemoryChip_sup1",
		"Items_MemoryChipBroken_sup1",
		"Items_MemoryChip_sup2",
		"Items_MemoryChipBroken_sup2",
		"Items_MemoryChip_dongul"
	};

	public static string[] memoryChipInfo = new string[11]
	{
		"empty",
		"PES-OP가 가지고 있던 메모리칩",
		"PES-OP가 가지고 있던 메모리칩이 박살나서 조각나버렸다.",
		"PES-OP가 가지고 있던 메모리칩",
		"PES-OP가 가지고 있던 메모리칩",
		"PES-OP가 가지고 있던 메모리칩이 박살나서 조각나버렸다.",
		"PES-OP가 가지고 있던 메모리칩",
		"PES-OP가 가지고 있던 메모리칩이 박살나서 조각나버렸다.",
		"PES-OP가 가지고 있던 메모리칩",
		"PES-OP가 가지고 있던 메모리칩이 박살나서 조각나버렸다.",
		"PES-OP가 가지고 있던 메모리칩",

	};

	public static int[] currentMemoryChipNum = new int[11]
	{
		0,0,0,0,0,
		0,0,0,0,0,
		0
	};

	public static int[] totalMemoryChipNum = new int[11]
	{
		0,1,6,1,1,
		6,1,6,1,6,
		1
	};

	public static bool[] canUseMemoryChip = new bool[11]
	{
		false,false,false,false,false,
		false,false,false,false,false,
		false
	};

}
