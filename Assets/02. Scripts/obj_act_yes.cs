using UnityEngine;
using System.Collections;

public class obj_act_yes : MonoBehaviour {
    public GameObject obj_act_panel;
    public GameObject Tank2;
    private Collider other;
    string[] name;
    // Use this for initialization
	void Start () {			
		GameObject.Find ("SoundManager").GetComponent<SoundManager> ().piano.Play ();
		GameObject.Find ("SoundManager").GetComponent<SoundManager> ().wind.Play ();
		GameObject.Find ("SoundManager").GetComponent<SoundManager> ().windChimes.Play ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void obj_act_yes_start(Collider other)
    {
        this.other = other;
    }

    public void obj_onClick_yes()
    {
        string[] name = other.gameObject.name.Split('_');

        if (name[1].Equals("Trash"))
        {
            Destroy(other.gameObject);
        }
        else if (name[1].Equals("Piano"))
        {
            //GameObject.Find("_EventSystem").SendMessage("ReceiveLog", "...바람이 불어온다.");
            Debug.Log(" ...바람이 불어온다.");
			GameObject.Find ("SoundManager").GetComponent<SoundManager> ().piano.Play ();
			GameObject.Find ("SoundManager").GetComponent<SoundManager> ().wind.Play ();
			GameObject.Find ("SoundManager").GetComponent<SoundManager> ().windChimes.Play ();
		}
        Tank2.SendMessage("tank_start");
        obj_act_panel.SetActive(false);
    }
}
