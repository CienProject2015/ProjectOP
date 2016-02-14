using UnityEngine;
using System.Collections;

public class item_no : MonoBehaviour {
    public GameObject it_panel;
    public GameObject Tank2;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void it_onClick_no()
    {
        it_panel.SetActive(false);
        Tank2.SendMessage("tank_start");
    }

}
