using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
[GLUXmlLink("GLU/Forms/GLURTSGUIForm.gluform", false)]
public class GLURTSGUIForm : GLUForm
{
    /* private static RallyPoint _rallyPoint = null;
    public static RallyPoint rallyPoint
    {
        get
        {
            if (_rallyPoint = null)
                _rallyPoint = GameObject.FindObjectOfType(typeof(RallyPoint)) as RallyPoint;
            return _rallyPoint;
        }
    } */
    public Plane zeroPlane = new Plane(Vector3.up, 0);
    ///Here are visual controls. Please, do not remove this region
    #region Controls
    [GLUXMLControlLink("309dcb02-3e4b-4dd8-9851-557d882d6347", "SceneSelector0")]
    private GLUSceneSelector SceneSelector0;

    [GLUXMLControlLink("b1280ce6-1320-4bc7-bdcf-3818c9daebb6", "ButtonsView0")]
    private GLUButtonsView ButtonsView0;
    [GLUXMLControlLink("dc8ee998-f0b5-4cf4-8d53-a4c7ff350b1f", "Button0")]
    private GLUButton Button0;
    #endregion

    public int clickSelectionSize = 10;

    public GLURTSGUIForm()
        : base()
    {
        if (Application.isPlaying)
            ButtonsView0.ClearItems();
    }

    int i = 0;

    [GLUXMLDelegateLink("309dcb02-3e4b-4dd8-9851-557d882d6347", "SceneSelector0", "OnChar")]
    private void SceneSelector0OnChar(GLUControl sender, Char key)
    {
        i++;
        i = i % 5;
        if (i == 0)
            i++;
        SceneSelector0.selectorRotation = (GLURotation)i;
        Debug.Log(" SceneView0.selectorRotation = " + SceneSelector0.selectorRotation);
    }

    private Vector3 GetZeroPlanePoint(Vector3 screenPoint)
    {
        Ray r = Camera.main.ScreenPointToRay(screenPoint);
        float e;
        if (zeroPlane.Raycast(r, out e))
        {
            Vector3 v = r.GetPoint(e);
            return new Vector3(v.x, v.z);
        }
        else
            return Vector3.zero;
    }

    private Vector3 GetZeroPlanePoint0(Vector3 screenPoint)
    {
        Ray r = Camera.main.ScreenPointToRay(screenPoint);
        float e;
        if (zeroPlane.Raycast(r, out e))
        {
            Vector3 v = r.GetPoint(e);
            return v;
        }
        else
            return Vector3.zero;
    }

    private bool selectionChanged = false;

    [GLUXMLDelegateLink("309dcb02-3e4b-4dd8-9851-557d882d6347", "SceneSelector0", "OnDrag")]
    private void SceneSelector0OnDrag(GLUControl sender, Vector3 mp)
    {
        if (!GLU.terminal.input.leftButtonDown)
            return;
        selectionChanged = true;
        /* Vector3 tl = GetZeroPlanePoint(new Vector3(SceneSelector0.selectionStart.x, GLU.terminal.height - SceneSelector0.selectionStart.y));
        Vector3 tr = GetZeroPlanePoint(new Vector3(SceneSelector0.selectionEnd.x, GLU.terminal.height - SceneSelector0.selectionStart.y));
        Vector3 br = GetZeroPlanePoint(new Vector3(SceneSelector0.selectionEnd.x, GLU.terminal.height - SceneSelector0.selectionEnd.y));
        Vector3 bl = GetZeroPlanePoint(new Vector3(SceneSelector0.selectionStart.x, GLU.terminal.height - SceneSelector0.selectionEnd.y)); 
        // Debug.Log(" SceneSelector0OnEndDrag: " + tl + ", " + tr + ", " + br + ", " + bl);
        SceneSelector0.selection = GLURTSUnitsController.instance.Select(tl, tr, br, bl); */
        SceneSelector0.selection = GLURTSUnitsController.instance.Select(new GLURect(
            (int)Mathf.Min(SceneSelector0.selectionStart.x, SceneSelector0.selectionEnd.x),
            (int)Mathf.Min(SceneSelector0.selectionStart.y, SceneSelector0.selectionEnd.y),
            (int)Mathf.Max(SceneSelector0.selectionStart.x, SceneSelector0.selectionEnd.x),
            (int)Mathf.Max(SceneSelector0.selectionStart.y, SceneSelector0.selectionEnd.y)));
    }

    [GLUXMLDelegateLink("309dcb02-3e4b-4dd8-9851-557d882d6347", "SceneSelector0", "OnEndDrag")]
    private void SceneSelector0OnEndDrag(GLUControl sender, GLUControl target)
    {
        if (!GLU.terminal.input.leftButtonReleased)
            return;
        // ButtonsView0.ClearItems();

        GLUList<GLUListItem> il = new GLUList<GLUListItem>();
        if (!selectionChanged)
        {
            Vector3 mp = GLU.terminal.input.cursorPosition;
            SceneSelector0.selection = GLURTSUnitsController.instance.Select(new GLURect(
                (int)mp.x - clickSelectionSize,
                (int)mp.y - clickSelectionSize,
                (int)mp.x + clickSelectionSize,
                (int)mp.y + clickSelectionSize));
        }
        selectionChanged = false;

        foreach (GLURTSUnit u in GLURTSUnitsController.instance.units)
        {
            if (u.selected)
            {
                il.Add(new GLUListItem(u.name, u, "GLU/Controls/Textures/SceneView/unitIcon"));
            }
        }
        ButtonsView0.items = il;

    }

    [GLUXMLDelegateLink("b1280ce6-1320-4bc7-bdcf-3818c9daebb6", "ButtonsView0", "OnItemInputPressed")]
    private void ButtonsView0OnItemInputPressed(GLUControl sender, Vector3 mp)
    {
        GLUListItem li = (sender as GLUControl).tag as GLUListItem;
        GLUList<GLUListItem> il = new GLUList<GLUListItem>() { li };
        ButtonsView0.items = il;
        GLURTSUnitsController.instance.Select(li.obj as GLURTSUnit);
        SceneSelector0.selection.Clear();
        SceneSelector0.selection.Add(li.obj as GLURTSUnit);
    }

    [GLUXMLDelegateLink("", "", "OnInputPressed")]
    private void RTSGUIFormOnInputPressed(GLUControl sender, Vector3 mp)
    {
        if (!GLU.terminal.input.rightButtonPressed)
            return;
        Vector3 v = GetZeroPlanePoint0(Input.mousePosition);
        v.y = -0.25f;
        RallyPoint.instance.ShowRallyPoint(v);
        v.y = 0;
        foreach (GLURTSUnit u in GLURTSUnitsController.instance.units)
        {
            if (u.selected)
            {
                u.SetRallyPoint(v);
            }
        }
    }


    [GLUXMLDelegateLink("dc8ee998-f0b5-4cf4-8d53-a4c7ff350b1f", "Button0", "OnPress")]
    private void Button0OnPress(GLUControl sender)
    {
        GLURTSMenuForm.instance.ShowModal();
    }


    [GLUXMLDelegateLink("309dcb02-3e4b-4dd8-9851-557d882d6347", "SceneSelector0", "OnClick")]
    private void SceneSelector0OnClick(GLUControl sender)
    {
    }

}
