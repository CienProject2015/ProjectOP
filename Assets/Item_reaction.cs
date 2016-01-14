using UnityEngine;
using UnityEditor;
using System.Collections;

public class Item_reaction : MonoBehaviour {
    public GameObject im_panel;
    public GameObject it_panel;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
    void Update(){

    }

    void OnTriggerEnter(Collider other){
        int speed=0;
        if (other.gameObject.name == "Impediments")
        {
            Debug.Log("crush");
            SendMessage("tank_stop",speed, SendMessageOptions.DontRequireReceiver);
            ui_p_item();
        }
        else if(other.gameObject.name == "Items")
        {
            Debug.Log("Nyam Nyam");
            SendMessage("tank_stop", speed, SendMessageOptions.DontRequireReceiver);
            ui_p_impedi();
        }
    }

    private void ui_p_item() {
        im_panel.SetActive(true);     
    }

    private void ui_p_impedi(){
        it_panel.SetActive(true);
    }
}
