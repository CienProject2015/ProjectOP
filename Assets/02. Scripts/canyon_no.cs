using UnityEngine;
using System.Collections;

public class canyon_no : MonoBehaviour {
    public GameObject canyon_panel;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void canyon_no_onclick()
    {
        canyon_panel.SetActive(false);
    }
}
