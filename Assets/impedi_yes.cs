using UnityEngine;
using System.Collections;

public class impedi_yes : MonoBehaviour {
    public GameObject im_panel;
    public GameObject tank;
    private Collider other;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
    }


    public void im_yes_start(Collider other)
    {
        this.other = other;
    }

    public void im_onClick_yes()
    {
        Debug.Log(other);
        Destroy(other.gameObject);
        tank.SendMessage("tank_start");
        im_panel.SetActive(false);
    }
}
