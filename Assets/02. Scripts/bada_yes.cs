using UnityEngine;
using System.Collections;

public class bada_yes : MonoBehaviour {
    public GameObject Tank2;
    public GameObject Penguin;
    public GameObject bada_panel;
    public GameObject Fade;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void bada_yes_onclick()
    {
        Tank2.transform.position = new Vector3(1102, 40, -1308);
        Tank2.transform.Rotate(0, 180, -20);
        Penguin.transform.position = new Vector3(1102, 40, -1308);
        Fade.SetActive(true);
        Fade.SendMessage("Fade");
        bada_panel.SetActive(false);
    }
}
