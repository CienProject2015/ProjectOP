using UnityEngine;
using System.Collections;

public class Twinkle : MonoBehaviour {

    public float duration = 3.0F;
    public float originalRange;
    public Light lt;
    void Start()
    {
        lt = GetComponent<Light>();
        Debug.Log(lt);
        originalRange = lt.range;
    }
    void Update()
    {
        float amplitude = Mathf.PingPong(Time.time, duration);
        amplitude = amplitude / duration * 0.5F + 0.5F;
        lt.range = originalRange * amplitude;
    }
}
