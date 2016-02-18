using UnityEngine;
using System.Collections;

public class CsFadeIn : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    void StartFadeIn()
    {
        StartCoroutine("FadeIn");
    }

    IEnumerator FadeIn()
    {
        for (float i = 1f; i >= 0; i -= 0.1f)
        {
            Color color = new Vector4(1, 1, 1, i);
            transform.GetComponent<Renderer>().material.color = color;
            yield return 0;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}