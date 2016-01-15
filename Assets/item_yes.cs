using UnityEngine;
using System.Collections;

public class item_yes : MonoBehaviour {
    public GameObject it_panel;
    public GameObject it;
    public GameObject tank;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void it_onClick()
    {
        Destroy(it);
        it_panel.SetActive(false);
        tank.SendMessage("tank_start");
    }
}
