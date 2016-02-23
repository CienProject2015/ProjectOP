using UnityEngine;
using System.Collections;

public class forest_yes : MonoBehaviour {
    public GameObject Tank2;
    public GameObject Penguin;
    public GameObject forest_panel;
    public GameObject Fade;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void forest_yes_onclick()
    {
        Tank2.transform.position = new Vector3(1030, 31, -767);
        Tank2.transform.Rotate(0, 90, -20);
        Penguin.transform.position = new Vector3(1030, 31, -767);
        Fade.SetActive(true);
        Fade.SendMessage("Fade");
        forest_panel.SetActive(false);
    }
}
