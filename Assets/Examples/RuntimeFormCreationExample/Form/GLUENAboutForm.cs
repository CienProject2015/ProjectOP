using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

/// <summary>
/// Presentation about window
/// </summary>
[Serializable]
public class GLUENAboutForm : GLUForm
{
    private static Dictionary<GLUBaseTerminal, GLUENAboutForm> _instances = new Dictionary<GLUBaseTerminal, GLUENAboutForm>();
    public static GLUENAboutForm instance
    {
        get
        {
            if (GLU.terminal != null)
            {
                if (!_instances.ContainsKey(GLU.terminal))
                    _instances.Add(GLU.terminal, new GLUENAboutForm());
                return _instances[GLU.terminal];
            }
            else
            {
                GLUDebug.LogError("GLUFileBrowserDialog.instance: Current terminal (GLU.terminal) is null!");
                return null;
            }
        }
    }


    public GLUENAboutForm()
        : base("GLUAboutForm", new GLUNumber((GLU.terminal.width - 512 + 8) / 2), new GLUNumber((GLU.terminal.height - 256 - 8 - 24) / 2), new GLUNumber(512 + 8), new GLUNumber(256 + 32), false, "About")
    {
        CreateControls();
        OnChangeResolution = OrientationChanged;
    }

    [XmlIgnore]
    public GLUFont fnt;
    public int fntSize = 14;
    public int smallFntSize = 12;

    public void OrientationChanged(GLUBaseTerminal sender)
    {
        x = new GLUNumber((GLU.terminal.width - width + 8) / 2);
        y = new GLUNumber((GLU.terminal.height - height - 8 - 24) / 2);
    }


    public override void CreateControls()
    {
        fnt = "arial";
        // AddChild(new GLULabel(this, "logo", 0, 0, clientWidth, clientHeight - 26, new GLUPadding(10, 10, 10, 10), true, "Version 1.2.0, 29.10.2012.", new GLUTextStyle(fnt, 14, FontStyle.Normal, new GLUColor(1, 1, 1, 1), false), GLUTexture.GetTexture("GLU/logo", true), new GLUPadding(0, 0, 0, 0), GLURotation.ccw0, GLUHorizontalAlignment.left, GLUVerticalAlignment.bottom));
        GLULabel l = AddChild(new GLULabel(this, "logo", new GLUNumber(0), new GLUNumber(0), new GLUNumber(clientWidth), new GLUNumber(clientHeight - 26), new GLUPadding(0), true, "Version 1.2.2", new GLUInternalImage("bg", "GLU/logo", new GLUBorders(0, 0, 0, 0), null), new GLUInternalText("text", new GLUTextStyle(fnt, 12, FontStyle.Normal, new GLUColor(1, 1, 1, 1), false), ""))) as GLULabel; 
        // AddControl(new GLULabel(this, "Info", "", fnt, 0, FontStyle.Normal, false, new GLUColor(0, 0, 0, 1), 10, 10, 512, 256, new GLUPadding(0, 0, 0, 0), GLUTexture.GetTexture("GLU/logo", true), new GLUPadding(0, 0, 0, 0), GLURotation.ccw0, true, GLUControlAlign.Left));
        GLUButton b = new GLUButton(this, "b", new GLUNumber(clientWidth - 104), new GLUNumber(clientHeight - 22), new GLUNumber(100), new GLUNumber(20), true, "OK");
        AddChild(b);

        l.layers[0].drawBorder = true;
        l.layers[1].alignment = GLUHorizontalAlignment.left;
        l.layers[1].verticalAlignment = GLUVerticalAlignment.bottom;
        // Debug.Log(" Label: align = " + l.alignment + ", valign = " + l.verticalAlignment);

        b.OnPress += OkButtonPress;
    }

    public void OkButtonPress(GLUControl sender)
    {
        Hide();
    }

}

