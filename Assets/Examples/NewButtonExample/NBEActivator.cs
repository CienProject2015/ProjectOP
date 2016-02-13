using UnityEngine;
using System.Collections;

public class NBEActivator : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GLU.terminal = GLU.screen;
        NBEForm f = new NBEForm();
        f.Show();

        GLU.terminal = GLUTerminal.GetTerminal("plane");
        f = new NBEForm();
        f.Show();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
