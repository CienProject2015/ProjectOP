using UnityEngine;
using System.Collections;

public class wheel : MonoBehaviour
{
    public Vector2 animRate;
    private Vector2 offset = Vector2.zero;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        offset += animRate * Time.deltaTime;
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", offset);
    }
}