using UnityEngine;
using System.Collections;

public class item_no : MonoBehaviour {
    public GameObject it_panel;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void it_onClick()
    {
        it_panel.SetActive(false);
    }

}
