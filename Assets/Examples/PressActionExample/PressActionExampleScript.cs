using UnityEngine;
using System.Collections;

public class PressActionExampleScript : MonoBehaviour
{

	// Use this for initialization
	public void Start () 
    {
        GLU.terminal = GLU.screen;
        PressActionExampleForm f = new PressActionExampleForm();
        f.Show();
	}
	
}
