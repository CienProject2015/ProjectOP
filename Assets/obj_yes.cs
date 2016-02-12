using UnityEngine;
using System.Collections;

public class obj_yes : MonoBehaviour {
    public GameObject obj_panel;
    public GameObject Tank2;
    private Collider other;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void obj_yes_start(Collider other)
    {
        this.other = other;
    }

    public void obj_onClick_yes()
    {
        Tank2.SendMessage("tank_start");
        obj_panel.SetActive(false);
    }
}
