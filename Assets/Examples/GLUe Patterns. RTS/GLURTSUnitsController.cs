using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

[Serializable]
public class GLURTSUnitsController : MonoBehaviour
{
    public static GLURTSUnitsController instance = null;
    [NonSerialized]
    public List<GLURTSUnit> units = new List<GLURTSUnit>();
    public GameObject unit;
    public Rect constraints = new Rect(-5, -2.5f, 10, 5);
    public int botsCount = 16;
    // public Vector3 botSize = new Vector3(0.25f, 0.25f, 0.25f);
    public GLUMinMaxPair botSpeedVariation = new GLUMinMaxPair(1, 2);

    public void Spawn()
    {
        // GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject go = GameObject.Instantiate(unit) as GameObject;
        go.name = "Unit"+units.Count;
        // go.transform.localScale = new Vector3(
        GLURTSUnit us = go.GetComponent<GLURTSUnit>();
        if (us == null)
            us = go.AddComponent<GLURTSUnit>();

        us.movingSpeed = UnityEngine.Random.Range(botSpeedVariation.min, botSpeedVariation.max);
        // us.transform.localScale = botSize;
        us.constraints = constraints;
        us.transform.position = us.GetSpawnPosition();
        units.Add(us);
    }

    // Use this for initialization
    public void Start()
    {
        GLU.terminal = GLU.screen;
        GLUForm f;
        f = new GLURTSGUIForm();
        f.Show();

        for (int i = 0; i < botsCount; i++)
            Spawn();
    }

    // Update is called once per frame
    public void Update()
    {

    }

    public void Awake()
    {
        instance = this;
    }

    public static bool Intersects(Vector3 aStartVertex, Vector3 aEndVertex, Vector3 bStartVertex, Vector3 bEndVertex)
    {
        float ax1 = aStartVertex.x;
        float ay1 = aStartVertex.y;
        float ax2 = aEndVertex.x;
        float ay2 = aEndVertex.y;

        float bx1 = bStartVertex.x;
        float by1 = bStartVertex.y;
        float bx2 = bEndVertex.x;
        float by2 = bEndVertex.y;

        return (((bx2 - bx1) * (ay1 - by1) - (by2 - by1) * (ax1 - bx1)) * ((bx2 - bx1) * (ay2 - by1) - (by2 - by1) * (ax2 - bx1)) <= 0) && (((ax2 - ax1) * (by1 - ay1) - (ay2 - ay1) * (bx1 - ax1)) * ((ax2 - ax1) * (by2 - ay1) - (ay2 - ay1) * (bx2 - ax1)) <= 0);
    }

    public static bool Contained(Vector3 point, params Vector3[] vertices)
    {

        if (vertices.Length > 2)
        {
            Vector3 ep = point + new Vector3(100000, 0, 0);
            Vector3 sv = vertices[0];
            Vector3 ev;
            int ic = 0;
            for (int i = 1; i < vertices.Length; i++)
            {
                ev = vertices[i];
                if (Intersects(sv, ev, point, ep))
                    ic++;
                sv = ev;
            }
            if (Intersects(vertices[0], vertices[vertices.Length - 1], point, ep))
                ic++;
            // Debug.Log(point + " contained == " + ((ic & 0x1) == 1));
            return (ic & 0x1) == 1;
        }
        else
            return false;
    }

    public List<IGLUGameUnit> Select(params Vector3[] vertices)
    {
        // List<GLURTSUnit> sl = new List<GLURTSUnit>();
        List<IGLUGameUnit> sl = new List<IGLUGameUnit>();
        foreach (GLURTSUnit u in units)
        {
            u.selected = Contained(new Vector3(u.transform.position.x, u.transform.position.z), vertices);
            if (u.selected)
                sl.Add(u);
        }
        return sl;
    }

    public List<IGLUGameUnit> Select(GLURect rect)
    {
        // List<GLURTSUnit> sl = new List<GLURTSUnit>();
        Vector3 v;
        List<IGLUGameUnit> sl = new List<IGLUGameUnit>();
        foreach (GLURTSUnit u in units)
        {
            v = Camera.main.WorldToScreenPoint(u.transform.position);
            v.y = GLU.screen.height - v.y;
            u.selected = rect.Contains(v);
            if (u.selected)
                sl.Add(u);
        }
        return sl;
    }

    public void Select(GLURTSUnit unit)
    {
        // List<GLURTSUnit> sl = new List<GLURTSUnit>();
        foreach (GLURTSUnit u in units)
            u.selected = u == unit;
    }
}
