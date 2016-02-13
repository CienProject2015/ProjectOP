using UnityEngine;
using System.Collections;

public class RuntimeFormCreationExampleScript : MonoBehaviour
{

	// Use this for initialization
	public void Start () 
    {
        GLU.terminal = GLU.screen;
        RuntimeCreatedForm f = new RuntimeCreatedForm();
        f.Show();
	}
	
}
