using System;
using UnityEngine;
using System.Text;
[GLUXmlLink("GLU/Forms/GLURTSMenuForm.gluform", false)]
public class GLURTSMenuForm : GLUForm
{

    private static GLURTSMenuForm _instance = null;
    public static GLURTSMenuForm instance
    {
        get
        {
            if (_instance == null)
                _instance = new GLURTSMenuForm();
            return _instance;
        }
    }

    ///Here are visual controls. Please, do not remove this region
    #region Controls
    [GLUXMLControlLink("05d39080-7986-4cab-b15d-7c154ec773d3", "Button0")]
    private GLUButton Button0;
    [GLUXMLControlLink("9fcd7c49-9cd2-4d54-bdbb-ad43e3bc34e0", "Button1")]
    private GLUButton Button1;
    [GLUXMLControlLink("15f930eb-45f4-4590-ba60-fc06cc617789", "Button2")]
    private GLUButton Button2;
    [GLUXMLControlLink("3a4265a4-f9f8-4d94-bd30-0a3e6be86e8d", "Button3")]
    private GLUButton Button3;
    [GLUXMLControlLink("345dbb7c-0f5b-4541-8347-0629c34cc474", "Button4")]
    private GLUButton Button4;
    #endregion


    public GLURTSMenuForm ()
        : base()
    {
    }

    [GLUXMLDelegateLink("05d39080-7986-4cab-b15d-7c154ec773d3", "Button0", "OnPress")]
    private void Button0OnPress(GLUControl sender)
    {
        foreach (GLURTSUnit u in GLURTSUnitsController.instance.units)
        {
            u.health = 100;
            u.deadFire.gameObject.active = false;
            u.deadSmoke.gameObject.active = false;
        }
        Close();
    }


    [GLUXMLDelegateLink("3a4265a4-f9f8-4d94-bd30-0a3e6be86e8d", "Button3", "OnPress")]
    private void Button3OnPress(GLUControl sender)
    {
        Close();
    }


    [GLUXMLDelegateLink("9fcd7c49-9cd2-4d54-bdbb-ad43e3bc34e0", "Button1", "OnPress")]
    private void Button1OnPress(GLUControl sender)
    {
        // Close();

        GLUMessageDialog.ShowOkModal("Message", "Not realized", "OK", null, 256); 
    }


    [GLUXMLDelegateLink("15f930eb-45f4-4590-ba60-fc06cc617789", "Button2", "OnPress")]
    private void Button2OnPress(GLUControl sender)
    {
        GLUMessageDialog.ShowOkModal("Message", "Not realized", "OK", null, 256); 

    }


    [GLUXMLDelegateLink("345dbb7c-0f5b-4541-8347-0629c34cc474", "Button4", "OnPress")]
    private void Button4OnPress(GLUControl sender)
    {
        Application.Quit();
    }

}
