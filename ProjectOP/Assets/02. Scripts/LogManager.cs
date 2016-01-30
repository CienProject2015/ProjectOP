using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class LogManager : MonoBehaviour {

	public GameObject gameLog;
	public GameObject latestLog;
	private string[] logString;
	public int detectedObjectNumber;
	private int fadeoutCount = 0;
	private int count;

	void Start(){
		logString = new string[7];
		for (int i = 0; i < 5; i++) {
			logString [i] = " ";
		}
		logString [5] = "----------------------------";
		logString [6] = "!감지된 오브젝트 " + detectedObjectNumber + "개 !";

		latestLog.GetComponent<Text> ().text = "";
		latestLog.GetComponent<Text> ().color = Color.clear;
	}

	void Update(){
		gameLog.GetComponent<Text> ().text = logString [4] + "\n" + logString [3] + "\n" + logString [2] + "\n" + logString [1] + "\n" + logString [0] + "\n" + logString [5] + "\n" + logString [6];
	}

	public void ReceiveLog(string latestLogText){
		latestLog.GetComponent<Text> ().text = latestLogText;
		latestLog.GetComponent<Text> ().color = Color.white;
		if (fadeoutCount == 0)
			StartCoroutine ("TextFadeout");
		for (int i = 3; i >= 0; i--) 
			logString [i + 1] = logString [i];
		logString [0] = count + " " + latestLogText;
		count++;
	}

	IEnumerator TextFadeout(){
		fadeoutCount++;
		while (latestLog.GetComponent<Text> ().color.a > 0) {
			latestLog.GetComponent<Text> ().color -= new Color (0, 0, 0, 0.01f);
			yield return null;
		}
		fadeoutCount--;
		yield break;
	}
}
