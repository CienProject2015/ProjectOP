using UnityEngine;
using System.Collections;

public class item_yes : MonoBehaviour {
    public GameObject it_panel;
    public GameObject it;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void it_onClick()
    {
        Destroy(it);
        it_panel.SetActive(false);
    }
}
