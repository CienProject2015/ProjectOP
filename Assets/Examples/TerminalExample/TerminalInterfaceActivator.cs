using UnityEngine;
using System.Collections;

public class TerminalInterfaceActivator : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GLU.terminal = GLUTerminal.GetTerminal("plane");
        GLU.terminal.modalBackgroundColor = new GLUColor(0, 0.75f);
        TerminalForm f = new TerminalForm();
        f.Show();
        GLU.terminal = GLU.screen;
        
        TerminalHUDForm tf = new TerminalHUDForm();
        tf.Show();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
