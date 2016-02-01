using UnityEngine;
using System.Collections;

public class item_yes : MonoBehaviour {
    public GameObject it_panel;
    public GameObject tank;
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
        Debug.Log(other);
        Destroy(other.gameObject);
        tank.SendMessage("tank_start");
        it_panel.SetActive(false);
    }
}
