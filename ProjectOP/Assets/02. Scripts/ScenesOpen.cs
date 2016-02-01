using UnityEngine;
using System.Collections;

public class ScenesOpen : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Scenes();
    }

    // Update is called once per frame
    void Update()
    {



    }
    void Scenes()
    {
        Application.LoadLevelAdditive(3);
   
    }
}
