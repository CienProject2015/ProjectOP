using UnityEngine;
using System.Collections;

public class PushAlarmMessage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		LocalNotification.SendNotification(1, 30*60, "WarmyLand", "아기펭귄이 외로워하고 있습니다", new Color32(0xff, 0x44, 0x44, 255));
		LocalNotification.SendNotification(1, 1*60*60, "WarmyLand", "똑..똑..똑똑…. 부리와 같은 뾰족한 무언가가 로봇의 몸을 두드리는 것 같습니다", new Color32(0xff, 0x44, 0x44, 255));
		LocalNotification.SendNotification(1, 2*60*60, "WarmyLand", "2시간", new Color32(0xff, 0x44, 0x44, 255));
		LocalNotification.SendNotification(1, 5*60*60, "WarmyLand", "5시간", new Color32(0xff, 0x44, 0x44, 255));
	}

	// Update is called once per frame
	void Update () {

	}
}
