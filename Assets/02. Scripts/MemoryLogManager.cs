using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class MemoryLogManager : MonoBehaviour {

	public Text memoryLog;
	private string[] logStr;
	private string[,] obtainLog;
	private int [] obtainCount;
	DateTime time;

	void Start () {
		logStr = new string[99];
		logStr[0] = "missing_memory";

		obtainLog = new string[6, 12];

		obtainCount = new int[6];
		for (int i = 0; i < 6; i++) {
			obtainCount [i] = 0;
		}
	}

	private void LogUpdate(){
		int strIndex = 0;
		for (int i = 0; i < 6; i++) {
			if (obtainCount [i] > 0) {
				logStr [strIndex] = "MEMORY_NO " + i;
				strIndex++;
				for (int j = 1; j <= obtainCount [i]; j++) {
					logStr [strIndex] = obtainLog [i, j];
					strIndex++;
				}
			} else if (i == 0) {
				logStr [0] = "missing_memory";
			}
		}
		memoryLog.text = string.Join ("\n", logStr);
	}

	public void MemoryChipObtain(int memoryChipNum){
		if (obtainCount [memoryChipNum - 1] < 12) {
			obtainCount [memoryChipNum - 1]++;
			obtainLog [memoryChipNum - 1, obtainCount [memoryChipNum - 1]] = "-" + obtainCount [memoryChipNum - 1] + ". " + time.ToString ("hh.mm.ss");
		}
	}
}
