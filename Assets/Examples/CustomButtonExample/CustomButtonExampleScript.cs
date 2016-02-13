using UnityEngine;
using System.Collections;

public class CustomButtonExampleScript : MonoBehaviour
{

	// Use this for initialization
	public void Start () 
    {
        GLU.terminal = GLU.screen;
        CustomButtonExampleForm f = new CustomButtonExampleForm();
        f.Show();
	}
	
}
