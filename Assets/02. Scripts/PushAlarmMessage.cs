using UnityEngine;
using System.Collections;

public class PushAlarmMessage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		LocalNotification.SendNotification(1, 10, "WarmyLand", "드루와드루와", new Color32(0xff, 0x44, 0x44, 255));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
