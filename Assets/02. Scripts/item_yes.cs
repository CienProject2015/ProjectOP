using UnityEngine;
using System.Collections;

public class item_yes : MonoBehaviour {
    public GameObject it_panel;
    public GameObject Tank2;
    private Collider other;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    public void it_yes_start(Collider other)
    {
        this.other = other;
    }
    public void it_onClick_yes()
    {
        Destroy(other.gameObject);
        Tank2.SendMessage("tank_start");
        Tank2.SendMessage("GainItem", other);
        it_panel.SetActive(false);
    }
}
