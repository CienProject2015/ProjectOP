using UnityEngine;
using UnityEditor;
using System.Collections;

public class Item_reaction : MonoBehaviour {

    public GameObject UIDSDF;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	   
	}

    void OnTriggerEnter(Collider other){
        if(other.gameObject.name == "Impediments")
        {
            Debug.Log("crush");
            GameObject.Destroy(other.gameObject);
            fdsa();
        }
    }

    private void fdsa() {
        UIDSDF.SetActive(true);
    }
}
