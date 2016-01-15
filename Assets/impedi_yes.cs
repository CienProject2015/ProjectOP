using UnityEngine;
using System.Collections;

public class impedi_yes : MonoBehaviour {
    public GameObject im_panel;
    public GameObject impedi;
    public GameObject tank;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void im_onClick()
    {
        im_panel.SetActive(false);
        Destroy(impedi);
        tank.SendMessage("tank_start");
    }
}
