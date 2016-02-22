using UnityEngine;
using System.Collections;

public class slide_no : MonoBehaviour {
    public GameObject slide_panel;
    public GameObject Tank2;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void slide_onClick_no()
    {
        Tank2.SendMessage("tank_start");
        slide_panel.SetActive(false);
    }
}
