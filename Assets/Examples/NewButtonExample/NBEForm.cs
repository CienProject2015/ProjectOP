using System;
using UnityEngine;
using System.Text;
[GLUXmlLink("GLU/Forms/NBEForm.gluform", false)]
public class NBEForm : GLUForm
{

    ///Here are visual controls. Please, do not remove this region
    #region Controls
    [GLUXMLControlLink("865f7f9e-ce52-4470-9579-929eadfc563f", "Button0")]
    private GLUButton Button0;
    [GLUXMLControlLink("9b6faaa6-5515-45f4-8ce2-236c5f6da83c", "Button1")]
    private GLUButton Button1;
    [GLUXMLControlLink("de3ac441-421a-4684-a758-5558f884c659", "Button2")]
    private GLUButton Button2;
    [GLUXMLControlLink("848fc192-e0bd-4d9f-b019-a134b95f00c6", "Button3")]
    private GLUButton Button3;
    [GLUXMLControlLink("200e0616-29ff-4ff2-9f95-573c59528a8f", "Button4")]
    private GLUButton Button4;
    [GLUXMLControlLink("925b455b-32e2-4c7f-9aa7-1352f0c7bd11", "TextEdit0")]
    private GLUTextEdit TextEdit0;
    #endregion


    public NBEForm ()
        : base()
    {
    }

    [GLUXMLDelegateLink("925b455b-32e2-4c7f-9aa7-1352f0c7bd11", "TextEdit0", "OnEnter")]
    private void TextEdit0OnEnter(GLUControl sender, Vector3 mp)
    {

    }

}
