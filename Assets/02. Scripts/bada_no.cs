using UnityEngine;
using System.Collections;

public class bada_no : MonoBehaviour {
    public GameObject bada_panel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void bada_no_onclick()
    {
        bada_panel.SetActive(false);
    }
}
