using UnityEngine;
using System.Collections;

public class forest_no : MonoBehaviour {
    public GameObject forest_panel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void forest_no_onclick()
    {
        forest_panel.SetActive(false);
    }
}
