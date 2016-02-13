using UnityEngine;
using System.Collections; 

public class ListBoxExampleScript : MonoBehaviour
{

	// Use this for initialization
	public void Start () 
    {
        GLU.terminal = GLU.screen;
        ListBoxExampleForm f = new ListBoxExampleForm();
        f.Show();
	}
	
}
