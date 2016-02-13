using System;
using UnityEngine;
using System.Text;
[GLUXmlLink("GLU/Forms/TerminalForm.gluform", false)]
public class TerminalForm : GLUForm
{

    ///Here are visual controls. Please, do not remove this region
    #region Controls
    [GLUXMLControlLink("03842296-6441-4275-af90-f18e81292bc3", "Button0")]
    private GLUButton Button0;
    [GLUXMLControlLink("add36edd-3f36-41b1-9536-4768b37e7ce8", "Button1")]
    private GLUButton Button1;
    [GLUXMLControlLink("58286dcc-7121-4696-96b5-45fd9e421291", "Button2")]
    private GLUButton Button2;
    [GLUXMLControlLink("8251a8d3-744f-49af-ac5a-6d4e942587c2", "Label0")]
    private GLULabel Label0;
    [GLUXMLControlLink("79d47bc8-7d52-4d4d-abbb-a897f7d0259f", "Button3")]
    private GLUButton Button3;
    [GLUXMLControlLink("f8fcfb89-915f-4120-b8e0-4bc0355373ff", "Button4")]
    private GLUButton Button4;
    #endregion


    public TerminalForm ()
        : base()
    {
    }

    [GLUXMLDelegateLink("03842296-6441-4275-af90-f18e81292bc3", "Button0", "OnPress")]
    private void Button0OnPress(GLUControl sender)
    {
        TerminalMessageForm.instance.ShowModal();
    }


    [GLUXMLDelegateLink("add36edd-3f36-41b1-9536-4768b37e7ce8", "Button1", "OnPress")]
    private void Button1OnPress(GLUControl sender)
    {
        TerminalMessageForm.instance.ShowModal();
    }


    [GLUXMLDelegateLink("58286dcc-7121-4696-96b5-45fd9e421291", "Button2", "OnPress")]
    private void Button2OnPress(GLUControl sender)
    {
        TerminalMessageForm.instance.ShowModal();
    }

}
