using System;
using UnityEngine;
using System.Text;
[GLUXmlLink("GLU/Forms/TerminalMessageForm.gluform", false)]
public class TerminalMessageForm : GLUForm
{
    private static TerminalMessageForm _instance = null;
    public static TerminalMessageForm instance
    {
        get
        {
            if (_instance == null)
                _instance = new TerminalMessageForm();
            return _instance;
        }
    }
    ///Here are visual controls. Please, do not remove this region
    #region Controls
    [GLUXMLControlLink("963d8aa1-40a5-40ca-9653-49d9c636dc49", "Button0")]
    private GLUButton Button0;
    [GLUXMLControlLink("392a886c-b656-42ca-afbf-3ad952992d19", "Label0")]
    private GLULabel Label0;
    #endregion


    public TerminalMessageForm ()
        : base()
    {
    }

    [GLUXMLDelegateLink("963d8aa1-40a5-40ca-9653-49d9c636dc49", "Button0", "OnPress")]
    private void Button0OnPress(GLUControl sender)
    {
        Close();
    }

}
