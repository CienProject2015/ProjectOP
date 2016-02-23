using UnityEngine;
using System.Collections;

public class slide_yes : MonoBehaviour {
    public GameObject slide_panel;
    public GameObject Tank2;
    public GameObject Penguin;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void slide_onClick_yes()
    {
        Tank2.SendMessage("tank_start");
        Tank2.transform.position = new Vector3(446, 158, 62);
        Penguin.transform.position = new Vector3(446, 158, 62);
        Tank2.transform.Rotate(0, 180, 0);
        slide_panel.SetActive(false);
    }
}
