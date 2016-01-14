using UnityEngine;
using System.Collections;

public class impedi_no : MonoBehaviour {
    public GameObject im_panel;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void im_onClick ()
    {
        im_panel.SetActive(false);
    }
}
