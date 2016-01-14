using UnityEngine;
using System.Collections;

public class TankMotion : MonoBehaviour {

    private GameObject searcher;

    void Start () {
        searcher = GameObject.Find("Searcher");
        searcher.SetActive(false);
    }
	
	void Update () {
        Motion();
    }
    private void Motion()
    {
        // 조감모드 OnOff
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (searcher.activeSelf)
                searcher.SetActive(false);
            else {
                searcher.SetActive(true);
            }
            searcher.SendMessage("OnOff",true);
        }
    }
}
