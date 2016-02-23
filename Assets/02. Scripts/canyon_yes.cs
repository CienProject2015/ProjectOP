using UnityEngine;
using System.Collections;

public class canyon_yes : MonoBehaviour {
    public GameObject Tank2;
    public GameObject Penguin;
    public GameObject canyon_panel;
    public GameObject Fade;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void canyon_yes_onclick()
    {
        Tank2.transform.position = new Vector3(-108, 100, -905);
        Penguin.transform.position = new Vector3(-108, 30, -905);
        Fade.SetActive(true);
        Fade.SendMessage("Fade");
        canyon_panel.SetActive(false);
    }
}
