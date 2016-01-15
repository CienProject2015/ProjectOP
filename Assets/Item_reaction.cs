using UnityEngine;
using UnityEditor;
using System.Collections;

public class Item_reaction : MonoBehaviour {
    public GameObject im_panel;
    public GameObject it_panel;
    //public Rigidbody rb;

    // Use this for initialization
    void Start () {
        //rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
    void Update(){

    }

    void OnTriggerEnter(Collider other){
        //rb.velocity = new Vector3(0, 0, 0);
        if (other.gameObject.name == "Impediments")
        {
            Debug.Log("crush");
            ui_p_item();
        }
        else if(other.gameObject.name == "Items")
        {
            Debug.Log("Nyam Nyam");
            ui_p_impedi();
        }
    }

    private void ui_p_item() {
        im_panel.SetActive(true);
        SendMessage("tank_stop");
    }

    private void ui_p_impedi(){
        it_panel.SetActive(true);
        SendMessage("tank_stop");
    }
}
