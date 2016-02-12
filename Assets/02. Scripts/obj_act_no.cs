using UnityEngine;
using System.Collections;

public class obj_act_no : MonoBehaviour {
    public GameObject obj_act_panel;
    public GameObject Tank2;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void obj_onClick_no()
    {
        obj_act_panel.SetActive(false);
        Tank2.SendMessage("tank_start");
    }
}
