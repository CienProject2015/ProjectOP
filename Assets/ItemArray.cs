using UnityEngine;
using System.Collections;

public class ItemArray : MonoBehaviour {
    ArrayList arr_item = new ArrayList();
    IList item;
    public GameObject obj_panel;
    public GameObject Text_hint;
    public GameObject Text_Active;
    public GameObject Tank2;
    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void GainItem(Collider other){
        SendMessage("tank_stop");
        string[] name = other.gameObject.name.Split('_');
        item = arr_item;

        if (name[0].Equals("Obj"))
        {
            obj_panel.SetActive(true);
            obj_panel = GameObject.Find("obj_panel");
            //만약 오브젝트를 발동시킬 수 있는 아이템이 있다면
            if (name[1].Equals("FirstAid") && item.Contains("Items_Bottle"))
            {
                Text_hint.SetActive(false);
                Text_Active.SetActive(true);
                Debug.Log("Activate Obj");
                //오브젝트 발동!
                obj_panel.SendMessage("obj_yes_start", other);
            }
            else
            {
                Text_Active.SetActive(false);
                Text_hint.SetActive(true);
                Debug.Log("Activate Hint");
                //힌트 창 발동!!
                //obj_panel.SendMessage("obj_onClick_just");
            }
        }
        else if(name[0].Equals("Items"))
        {
            Debug.Log("Gain Items");
            item.Add(other.gameObject.name);
            Debug.Log(item.Contains("Items_Bottle"));
            Tank2.SendMessage("tank_start");
        }
    }
}
