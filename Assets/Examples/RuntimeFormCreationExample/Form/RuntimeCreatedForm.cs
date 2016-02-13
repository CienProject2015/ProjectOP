using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UnityEngine;


public class RuntimeCreatedForm : GLUForm
{
    GLUTextEdit messageBoxEdit;
    public RuntimeCreatedForm()
        : base("testForm", new GLUNumber((GLU.terminal.width - 460) / 2), new GLUNumber(10), new GLUNumber(460), new GLUNumber(GLU.terminal.height - 20), false, "Test form")
    {
        CreateControls();
    }

    private void ItemSelected(GLUControl sender)
    {
        GLUMenuItem mi = (sender.tag as GLUMenuItem);
        mi.isChecked = !mi.isChecked;
        GLUDebug.Log("ItemSelected " + mi);
    }

    public override void CreateControls()
    {
        GLUPopupMenu popup = AddChild(new GLUPopupMenu(this, "Popup", new GLUNumber(0), new GLUNumber(0), null, 
            new GLUMenuItem("Item 1", 0, ItemSelected),
            new GLUMenuItem("Item 2", 1, ItemSelected, false, new GLUMenuItem("Subitem 1", 0, ItemSelected), new GLUMenuItem("Subitem 2", 1, ItemSelected), new GLUMenuItem("Subitem 3", 2, null)),
            new GLUMenuItem("Item 3", 2, ItemSelected), 
            new GLUMenuItem("-", -1, null),
            new GLUMenuItem("Item 4", 3, ItemSelected), 
            new GLUMenuItem("Item 5", 4, ItemSelected)), false) as GLUPopupMenu;

        GLUScrollView sv = AddChild(new GLUScrollView(this, "scrollView", new GLUNumber(0), new GLUNumber(0), new GLUNumber(clientWidth), new GLUNumber(clientHeight - 40), true, null)) as GLUScrollView;
        sv.layers.Clear();
        int w = sv.viewport.width - padding.left - 16;
        GLUTextStyle ts = new GLUTextStyle("arial", 12, FontStyle.Normal, new GLUColor(0.8f, 0.3f, 0.1f, 1), false);
        GLUTextStyle ts0 = new GLUTextStyle("arial", 12, FontStyle.Normal, new GLUColor(0, 0, 0, 1), false);
        GLULabel l = sv.AddScrollChild(new GLULabel(this, "l1", new GLUNumber(10), new GLUNumber(10), new GLUNumber(150), new GLUNumber(22), true, "Standard text edit:"), false) as GLULabel;
        l.textStyle = ts;
        sv.AddScrollChild(new GLUTextEdit(this, "textEdit0", new GLUNumber(l.x + l.width + 10), new GLUNumber(l.y), new GLUNumber(w - l.width - l.x - 20), l.height, true, "Test text", false, false), false);
        l = sv.AddScrollChild(new GLULabel(this, "l2", new GLUNumber(l.x), new GLUNumber(l.y + l.height + 4), new GLUNumber(150), new GLUNumber(22), true, "Custom text edit:"), false) as GLULabel;
        l.textStyle = ts;
        GLUTextEdit te = sv.AddScrollChild(new GLUTextEdit(this, "textEdit", new GLUNumber(l.x + l.width + 10), l.y, new GLUNumber(w - l.width - l.x - 20), l.height, true, "Custom text", false, false), false) as GLUTextEdit;
        te.textStyle = new GLUTextStyle("arial", 14, FontStyle.Bold, new GLUColor(0, 0.4f, 0, 1), false);
        te.textAlignment = GLUHorizontalAlignment.center;

        l = sv.AddScrollChild(new GLULabel(this, "l3", new GLUNumber(l.x), new GLUNumber(l.y + l.height + 4), new GLUNumber(200), new GLUNumber(72), true, "Custom multiline text edit:"), false) as GLULabel;
        l.textStyle = ts;
        te = sv.AddScrollChild(new GLUTextEdit(this, "textEdit", new GLUNumber(l.x + l.width + 10), new GLUNumber(l.y), new GLUNumber(w - l.width - l.x - 20), new GLUNumber(l.height), true, "Custom\nmultiline\ntext", true), false) as GLUTextEdit;
        te.textAlignment = GLUHorizontalAlignment.right;

        l = sv.AddScrollChild(new GLULabel(this, "l4", new GLUNumber(l.x), new GLUNumber(l.y + l.height + 20), new GLUNumber(150), new GLUNumber(22), true, "Standard combo box:"), false) as GLULabel;
        l.textStyle = ts;
        // sv.AddScrollChild(new GLUComboBox(this, "standardCombo", l.left + l.width + 10, l.top, w - l.width - l.left - 20, l.height, true, "Standard combo", "textEdit", true, GLUHorizontalAlignment.left, new GLUListItem("Item0", -1, null), new GLUListItem("Item1", 0, null), new GLUListItem("Item2", 1, null), new GLUListItem("Item3", 2, null), new GLUListItem("Item4", 3, null), new GLUListItem("Item5", 4, null)), false);
        GLUComboBox scb = sv.AddScrollChild(new GLUComboBox(this, "standardCombo", new GLUNumber(l.x + l.width + 10), new GLUNumber(l.y), new GLUNumber(w - l.width - l.x - 20), new GLUNumber(l.height), true, "Standard combo", "comboBox"), false) as GLUComboBox;
        scb.items = new GLUList<GLUListItem>() { new GLUListItem("Item0", -1, null), new GLUListItem("Item1", 0, null), new GLUListItem("Item2", 1, null), new GLUListItem("Item3", 2, null), new GLUListItem("Item4", 3, null), new GLUListItem("Item5", 4, null)};

        l = sv.AddScrollChild(new GLULabel(this, "l5", new GLUNumber(l.x), new GLUNumber(l.y + l.height + 4), new GLUNumber(150), new GLUNumber(22), true, "Custom combo box:"), false) as GLULabel;
        l.textStyle = ts;

        GLUComboBoxStyle cbs = GLUComboBoxStyle.CreateDefault();
        cbs.textEditStyle = GLUTextEditStyle.CreateDefault();
        (cbs.textEditStyle.style as GLUTextEditStyle).internalTextStyle = GLUEditableTextStyle.CreateDefault();
        ((cbs.textEditStyle.style as GLUTextEditStyle).internalTextStyle.style as GLUEditableTextStyle).textAlignment = GLUHorizontalAlignment.center;
        ((cbs.textEditStyle.style as GLUTextEditStyle).internalTextStyle.style as GLUEditableTextStyle).textStyle = new GLUTextStyle("arial", 10, FontStyle.Bold, new GLUColor(0.6f, 0, 0, 1), false);
        (cbs.comboButtonStyle.style as GLUButtonStyle).height = new GLUNumber(0);
        //cbs.textEditStyle.internalTextStyle.
        scb = sv.AddScrollChild(new GLUComboBox(this, "customCombo", new GLUNumber(l.x + l.width + 10), new GLUNumber(l.y), new GLUNumber(w - l.width - l.x - 20), new GLUNumber(18), true, "Custom combo", cbs), false) as GLUComboBox;
        scb.items = new GLUList<GLUListItem>() { new GLUListItem("Item0", -1, "GLU/Controls/Textures/FileBrowser/drive"), new GLUListItem("Item1", -1, "GLU/Controls/Textures/FileBrowser/file"), new GLUListItem("Item2", 1, "GLU/Controls/Textures/FileBrowser/folder"), new GLUListItem("Item3", 2, null), new GLUListItem("Item4", 3, "GLU/Controls/Textures/FileBrowser/drive"), new GLUListItem("Item5", 4, null) };

        l = sv.AddScrollChild(new GLULabel(this, "l6", new GLUNumber(l.x), new GLUNumber(l.y + l.height + 20), new GLUNumber(150), new GLUNumber(72), true, "Standard list box:"), false) as GLULabel;
        l.textStyle = ts;
        GLUListBox lb = sv.AddScrollChild(new GLUListBox(this, "standardList", new GLUNumber(l.x + l.width + 10), new GLUNumber(l.y), new GLUNumber(w - l.width - l.x - 20), new GLUNumber(l.height), true, true, false, null), false) as GLUListBox; 
        lb.items = new GLUList<GLUListItem>(){new GLUListItem("Item0", -1, null), new GLUListItem("Item1", 0, null), new GLUListItem("Item2", 1, null), new GLUListItem("Item3", 2, null), new GLUListItem("Item4", 3, null), new GLUListItem("Item5", 4, null)};

        l = sv.AddScrollChild(new GLULabel(this, "l7", new GLUNumber(l.x), new GLUNumber(l.y + l.height + 20), new GLUNumber(150), new GLUNumber(22), true, "Standard modal form:"), false) as GLULabel;
        l.textStyle = ts;
        GLUButton b = sv.AddScrollChild(new GLUButton(this, "about", new GLUNumber(l.x + l.width + 10), new GLUNumber(l.y), new GLUNumber(w - l.width - l.x - 20), new GLUNumber(l.height), true, "Press to open modal form"), false) as GLUButton;
        b.OnPress = ShowModalForm;

        l = sv.AddScrollChild(new GLULabel(this, "l8", new GLUNumber(l.x), new GLUNumber(l.y + l.height + 20), new GLUNumber(150), new GLUNumber(22), true, "Standard date picker:"), false) as GLULabel;
        l.textStyle = ts;
        sv.AddScrollChild(new GLUCalendarCombo(this, "calendar", new GLUNumber(l.x + l.width + 10), new GLUNumber(l.y), new GLUNumber(w - l.width - l.x - 20), new GLUNumber(l.height), true, DateTime.Now), false);

        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.LinuxPlayer)
        {
            l = sv.AddScrollChild(new GLULabel(this, "l11", new GLUNumber(l.x), new GLUNumber(l.y + l.height + 20), new GLUNumber(150), new GLUNumber(22), true, "File load dialog:"), false) as GLULabel;
            l.textStyle = ts;
            b = sv.AddScrollChild(new GLUButton(this, "fileLoadDialog", new GLUNumber(l.x + l.width + 10), new GLUNumber(l.y), new GLUNumber(w - l.width - l.x - 20), new GLUNumber(l.height), true, "Press to open load dialog box"), false) as GLUButton;
            // b.colorMultiplier = new GLUColor(0.5f, 0.5f, 1f, 1);
            b.OnPress = LoadFilePressed;
            l = sv.AddScrollChild(new GLULabel(this, "l14", new GLUNumber(l.x), new GLUNumber(l.y + l.height + 4), new GLUNumber(150), new GLUNumber(22), true, "File save dialog:"), false) as GLULabel;
            l.textStyle = ts;
            b = sv.AddScrollChild(new GLUButton(this, "filesaveDialog", new GLUNumber(l.x + l.width + 10), new GLUNumber(l.y), new GLUNumber(w - l.width - l.x - 20), new GLUNumber(l.height), true, "Press to open save dialog box"), false) as GLUButton;
            // b.colorMultiplier = new GLUColor(0.5f, 1f, 0.5f, 1);
            b.OnPress = SaveFilePressed;
        }

        l = sv.AddScrollChild(new GLULabel(this, "l13", new GLUNumber(l.x), new GLUNumber(l.y + l.height + 20), new GLUNumber(150), new GLUNumber(22), true, "Message box with formatted text:"), false) as GLULabel;
        l.textStyle = ts;
        messageBoxEdit = sv.AddScrollChild(new GLUTextEdit(this, "messageBoxEdit", new GLUNumber(l.x), new GLUNumber(l.y + l.height), new GLUNumber(w - 10 - l.x), new GLUNumber(72), true, "<arial, 16, Bold, #bbbbbbff, False>Text for message box demonstration. \n<arial, 14, Normal, #bb7733ff, False>You may use text styles like this: \n" +
        "<arial, 12, Normal, #bbbbbbff, False>/<Font name,\n font size (10, 12, 14, 16), font style (Normal, Bold, Italic), text color (#RRGGBBAA), underline flag (True, False)><arial, 10, Normal, #44bb44ff, False>Small green font", true, false), false) as GLUTextEdit;

        /* l = sv.AddScrollChild(new GLULabel(this, "l13", l.left, l.top + l.height + 20, 150, 22, new GLUPadding(0), true, "Message box with formatted text:", ts, null, new GLUPadding(0), GLURotation.ccw0), false) as GLULabel;
        messageBoxEdit = sv.AddScrollChild(new GLUTextEdit(this, "messageBoxEdit", l.left, l.top + l.height, w - 10 - l.left, 72, true, "<typeWritten, 16, Bold, #bbbbbbff, False>Text for message box demonstration. \n<typeWritten, 14, Normal, #bb7733ff, False>You may use text styles like this: \n" +
        "<handWritten, 12, Normal, #bbbbbbff, False>/<Font name(allowed values - typeWritten, handWritten),\n font size (10, 12, 14, 16), font style (Normal, Bold, Italic), text color (#RRGGBBAA), underline flag (True, False)>", true, false), false) as GLUTextEdit;*/

        l = sv.AddScrollChild(new GLULabel(this, "l11", new GLUNumber(messageBoxEdit.x), new GLUNumber(messageBoxEdit.y + messageBoxEdit.height + 4), new GLUNumber(150), new GLUNumber(22), true, "Show message box:"), false) as GLULabel;
        l.textStyle = ts;
        b = sv.AddScrollChild(new GLUButton(this, "messageBox", new GLUNumber(l.x + l.width + 10), new GLUNumber(l.y), new GLUNumber(w - l.width - l.x - 20), new GLUNumber(l.height), true, "Press to open message box"), false) as GLUButton;
        b.OnPress = MessageBoxPress;

        l = sv.AddScrollChild(new GLULabel(this, "l11", new GLUNumber(l.x), new GLUNumber(l.y + l.height + 20), new GLUNumber(300), new GLUNumber(22), true, "Press right mouse button or touch for 2 sec :"), false) as GLULabel;
        l.textStyle = ts;
        b = sv.AddScrollChild(new GLUButton(this, "PopUpButton", new GLUNumber(l.x + l.width + 10), new GLUNumber(l.y), new GLUNumber(w - l.width - l.x - 20), new GLUNumber(l.height), true, "Popup menu"), false) as GLUButton;
        b.toggle = true;
        b.popup = popup;
        // b.colorComposer = new GLUColor(0.25f, 0, 0.25f, 0);

        l = sv.AddScrollChild(new GLULabel(this, "l15", new GLUNumber(l.x), new GLUNumber(l.y + l.height + 20), new GLUNumber(150), new GLUNumber(22), true, "Standard check box:"), false) as GLULabel;
        l.textStyle = ts;
        // sv.AddScrollChild(new GLUCheckBox(this, "checkBox", new GLUNumber(l.x + l.width + 10), l.y, new GLUNumber(w - l.width - l.x - 20), l.height, true, "Standard check box"), false);
        sv.AddScrollChild(new GLUCheckBox(this, "checkBox", new GLUNumber(l.x + l.width + 10), l.y, new GLUNumber(150), l.height, true, "Standard check box"), false);

        // l = sv.AddScrollChild(new GLULabel(this, "l12", new GLUNumber(l.x), new GLUNumber(l.y + l.height + 20), new GLUNumber(300), new GLUNumber(22), true, "Paint box (click several times over box below):"), false) as GLULabel;
        // l.textStyle = ts;
        // sv.AddScrollChild(new GLUPaintBox(this, "paintBox", l.left, l.top + l.height, w - l.left - 10, 200, new GLUPadding(6), true), false);

        b = AddChild(new GLUButton(this, "clone", new GLUNumber(10), new GLUNumber(clientHeight - 32), new GLUNumber(90), new GLUNumber(22), true, "Duplicate")) as GLUButton;
        // b.colorMultiplier = new GLUColor(1, 0.5f, 0.5f, 1);
        b.OnPress = ClonePressed;
        b = AddChild(new GLUButton(this, "close", new GLUNumber(clientWidth - 10 - 90), new GLUNumber(clientHeight - 32), new GLUNumber(90), new GLUNumber(22), true, "Close")) as GLUButton;
        b.OnPress = ClosePressed;
        // sv.NeedRepaint();

        /* AddControl(new GLUButton(this, "Item1", 0, 0, 150, 24, GLU.terminal.skin.listBoxSkin.padding,
            true, "Item1", "button", null, GLU.terminal.skin.listBoxSkin.item.hover.url, GLU.terminal.skin.listBoxSkin.item.pressed.url,
            GLU.terminal.skin.listBoxSkin.item.hover.borders, GLU.terminal.skin.fileBrowserSkin.folder.url, 20, 0, new GLURect(), GLURotation.ccw0, true, GLUPictureAlignment.left, GLUHorizontalAlignment.Left));*/
    }


    public void MessageBoxPress(GLUControl sender)
    {
        GLUMessageDialog.ShowYesNoModal("Message box", messageBoxEdit.text, "Accept", "Decline", null);
    }

    private void ClonePressed(GLUControl sender)
    {
        (new RuntimeCreatedForm()).Show();
    }

    private void ClosePressed(GLUControl sender)
    {
        Close();
    }

    private void ShowModalForm(GLUControl sender)
    {
        GLUENAboutForm.instance.ShowModal();
    }

    private void LoadFilePressed(GLUControl sender)
    {
        GLUFileBrowserDialog.ShowLoadDialog("Load file", "Folder", "File", "Ok", "Cancel", "", null, "*.*", "*.xml");
    }

    private void SaveFilePressed(GLUControl sender)
    {
        GLUFileBrowserDialog.ShowSaveDialog("Save file", "Folder", "File", "Ok", "Cancel", "", null, "*.*", "*.xml");
    }

}
