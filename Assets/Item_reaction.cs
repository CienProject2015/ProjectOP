using UnityEngine;
using System.Collections;

public class Item_reaction : MonoBehaviour {
    public GameObject im_panel;
    public GameObject it_panel;
    public GameObject Text_trash;
    public GameObject Text;
    //public Rigidbody rb;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
    void Update(){

    }

    void OnTriggerEnter(Collider other){
        string[] name = other.gameObject.name.Split('_');
        if (name[0] == "Impedi")
        {
            ui_p_item(other);
        }
        else if(name[0] == "Items")
        {
            Debug.Log(name[0]);
            ui_p_impedi(other);
        }
    }

    private void ui_p_item(Collider other) {
        string[] name = other.gameObject.name.Split('_');
        if(name[1] == "trash")
        {
            Text.SetActive(false);
            Text_trash.SetActive(true);
        }
        else
        {
            Text.SetActive(true);
            Text_trash.SetActive(false);
        }
        im_panel.SetActive(true);
        im_panel = GameObject.Find("im_panel");
        im_panel.SendMessage("im_yes_start", other);
        SendMessage("tank_stop");
    }

    private void ui_p_impedi(Collider other)
    {
        it_panel.SetActive(true);
        it_panel = GameObject.Find("it_panel");
        it_panel.SendMessage("it_yes_start", other);
        SendMessage("tank_stop");
    }
}
