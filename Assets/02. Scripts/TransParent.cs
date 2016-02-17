using UnityEngine;
using System.Collections;

public class TransParent : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Renderer>().material.color = new Color(0.3f, 0.3f, 0.3f, 0.3f);
    }
	
	// Update is called once per frame
	void Update (){

    }
}
