using UnityEngine;
using System;
using System.Collections;

public class RallyPoint : MonoBehaviour 
{
    public static RallyPoint instance = null;
    public float moveSpeed = 1;
    public float timeQuantum = 0.033f;
    public Vector3 hideDelta = new Vector3(0, -0.6f, 0);
    public int circleScalingSteps = 32;
    public Vector3 startCircleScale = new Vector3(0, 0, 0);
    public Vector3 endCircleScale = new Vector3(1, 1, 1);

    [NonSerialized]
    public GameObject rallyCircle = null;


    public void Awake()
    {
        instance = this;
        rallyCircle = GameObject.Find("rallyCircle");
    }

    [NonSerialized]
    private bool smoothMoveInProgress = false;

    private IEnumerator SmoothMoveTo(Vector3 target)
    {
        /* if (smoothMoveInProgress)
            yield break;
        smoothMoveInProgress = true; */
        Vector3 startPosition = transform.position;
        Vector3 v;
        Vector3 dv = (target - transform.position).normalized * moveSpeed;
        // Debug.Log("1: dv = " + dv);
        do
        {
            v = transform.position + dv*/*Time.deltaTime*/timeQuantum;
            // Debug.Log("1: v = " + v);
            if ((transform.position - target).magnitude <= (v - target).magnitude)
            {
                transform.position = target;
                break;
            }
            else
                transform.position = v;
            yield return new GLUWaitForSeconds(timeQuantum);
        }
        while (true);

        yield return new WaitForSeconds(0.1f);
        
        target = startPosition;
        dv = (target - transform.position).normalized * moveSpeed;
        // Debug.Log("2: dv = " + dv);
        do
        {
            v = transform.position + dv * /*Time.deltaTime*/timeQuantum;
            // Debug.Log("2: v = " + v);
            if ((transform.position - target).magnitude <= (v - target).magnitude)
            {
                transform.position = target;
                break;
            }
            else
                transform.position = v;
            yield return new GLUWaitForSeconds(timeQuantum);
        }
        while (true);

        // smoothMoveInProgress = false;

    }



    private IEnumerator ShowRallyCircle(Vector3 position)
    {
        rallyCircle.active = true;
        rallyCircle.transform.position = position;
        float v;
        for (int i = 0; i < circleScalingSteps; i++)
        {
            v = (float)i / circleScalingSteps;
            rallyCircle.transform.localScale = Vector3.Lerp(startCircleScale, endCircleScale, v*v);
            // yield return new GLUWaitForSeconds(timeQuantum);
            yield return new GLUWaitForSeconds(timeQuantum*0.5f);
        }
    }
    
    [NonSerialized]
    private GLUCoroutine currentRallyPointCoroutine = null;

    [NonSerialized]
    private GLUCoroutine currentRallyCircleCoroutine = null;

    public void ShowRallyPoint(Vector3 position)
    {
        transform.position = position + hideDelta;
        GLU.terminal = GLU.screen;
        if (currentRallyPointCoroutine != null)
            GLU.StopCoroutine(currentRallyPointCoroutine);
        if (currentRallyCircleCoroutine != null)
            GLU.StopCoroutine(currentRallyCircleCoroutine);
        currentRallyPointCoroutine = GLU.StartCoroutine(SmoothMoveTo(position));
        currentRallyCircleCoroutine = GLU.StartCoroutine(ShowRallyCircle(position + new Vector3(0, 0.001f, 0)));
    }

    public void Start()
    {
        // hideDelta.y = transform.localScale
    }
}
