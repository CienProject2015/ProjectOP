using UnityEngine;
using System.Collections;

public class impedi_no : MonoBehaviour {
    public GameObject im_panel;
    public GameObject Tank2;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void im_onClick_no ()
    {
        im_panel.SetActive(false);
        Tank2.SendMessage("tank_start");
    }
}
