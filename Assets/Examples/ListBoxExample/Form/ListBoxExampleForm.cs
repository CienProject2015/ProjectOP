using System;
using UnityEngine;
using System.Text;
[GLUXmlLink("GLU/Forms/ListBoxExampleForm.gluform", false)]
public class ListBoxExampleForm : GLUForm
{

    ///Here are visual controls. Please, do not remove this region
    #region Controls
    [GLUXMLControlLink("ba8decfc-6c66-42e5-be28-e1d54883416d", "CustomListBox0")]
    private GLUListBox CustomListBox0;
    #endregion


    public ListBoxExampleForm ()
        : base()
    {
    }

    [GLUXMLDelegateLink("ba8decfc-6c66-42e5-be28-e1d54883416d", "CustomListBox0", "OnSelectionChanged")]
    private void CustomListBox0OnSelectionChanged(GLUControl sender)
    {
        GLUMessageDialog.ShowOkModal("Message", "ListBox selection changed", "OK", null, 320);
    }

}
