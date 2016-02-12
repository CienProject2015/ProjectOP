using UnityEngine;
using System.Collections;

public class ObjMove : MonoBehaviour {
    public GameObject Items_memorychip;
    Vector3 localPos;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        localPos = Items_memorychip.transform.localPosition;
        transform.position+= Vector3.up * Time.deltaTime;
        if (localPos.y >= 16)
        {
            transform.position -= Vector3.up * Time.deltaTime;
        } 
    }
}
