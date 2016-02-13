using System;
using UnityEngine;
using System.Text;
[GLUXmlLink("GLU/Forms/PressActionExampleForm.gluform", false)]
public class PressActionExampleForm : GLUForm
{

    ///Here are visual controls. Please, do not remove this region
    #region Controls
    [GLUXMLControlLink("c4ec4f53-afb0-4bd6-83af-ea85221b74f9", "TextButton0")]
    private GLUButton TextButton0;
    #endregion


    public PressActionExampleForm()
        : base()
    {
    }

    [GLUXMLDelegateLink("c4ec4f53-afb0-4bd6-83af-ea85221b74f9", "TextButton0", "OnPress")]
    private void TextButton0OnPress(GLUControl sender)
    {
        GLUMessageDialog.ShowOkModal("Message", "You pressed me!", "Ok", null, 320);
    }

}
