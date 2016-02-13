using System;
using UnityEngine;
using System.Collections.Generic;
using System.Text;
[GLUXmlLink("GLU/Forms/CustomButtonExampleForm.gluform", false)]
public class CustomButtonExampleForm : GLUForm
{
    private static CustomButtonExampleForm _instance = null;
    public static CustomButtonExampleForm instance
    {
        get
        {
            if (_instance == null)
                _instance = new CustomButtonExampleForm();
            return _instance;
        }
    }

    ///Here are visual controls. Please, do not remove this region
    #region Controls
    private GLUButton testButton0;
    private GLUButton testButton1;
    private GLUButton testButton2;
    private GLUButton testButton3;
    #endregion


    public override void CreateControls()
    {
        GLULocalScaleSequence lss;
        GLULocalRotationSequence lrs = new GLULocalRotationSequence(WrapMode.Loop, WrapMode.Loop, 180, new GLUKey<Vector3>(0, Vector3.zero), new GLUKey<Vector3>(4f, new Vector3(0, 0, 360)));
        GLUMaterialColorSequence mcs = new GLUMaterialColorSequence(WrapMode.ClampForever, WrapMode.ClampForever, 3, new GLUKey<Vector4>(0, new Vector4(1, 1, 1, 1)));

        GLUAnimationSet glueHUDSet = new GLUAnimationSet();

        glueHUDSet.AddAnimation(new GLUAnimation(GLUAnimationSet.CreateIndex(GLUControlState.hovered, GLUControlState.hovered | GLUControlState.start), true, 0, GLUAnimationConflictDecisionType.replace, lrs, mcs));

        lrs = new GLULocalRotationSequence(WrapMode.ClampForever, WrapMode.ClampForever, 180, new GLUKey<Vector3>(0, Vector3.zero));
        mcs = new GLUMaterialColorSequence(WrapMode.ClampForever, WrapMode.ClampForever, 3, new GLUKey<Vector4>(0, new Vector4(1, 1, 1, 0.5f)));

        glueHUDSet.AddAnimation(new GLUAnimation(GLUAnimationSet.CreateIndex(GLUControlState.hovered, GLUControlState.start), false, 0, GLUAnimationConflictDecisionType.replace, mcs, lrs));
        GLUAnimationSet compassSet = new GLUAnimationSet();

        mcs = new GLUMaterialColorSequence(WrapMode.ClampForever, WrapMode.ClampForever, 3, new GLUKey<Vector4>(0, Vector4.one));
        lrs = new GLULocalRotationSequence(WrapMode.Loop, WrapMode.Loop, 180, new GLUKey<Vector3>(0, Vector3.zero), new GLUKey<Vector3>(4, new Vector3(0, 0, -360)));
        compassSet.AddAnimation(new GLUAnimation(GLUAnimationSet.CreateIndex(GLUControlState.hovered, GLUControlState.hovered | GLUControlState.start), true, 0, GLUAnimationConflictDecisionType.replace, lrs, mcs));

        mcs = new GLUMaterialColorSequence(WrapMode.ClampForever, WrapMode.ClampForever, 3, new GLUKey<Vector4>(0, new Vector4(1, 1, 1, 0.75f)));
        lrs = new GLULocalRotationSequence(WrapMode.ClampForever, WrapMode.ClampForever, 180, new GLUKey<Vector3>(0, Vector3.zero));

        compassSet.AddAnimation(new GLUAnimation(GLUAnimationSet.CreateIndex(GLUControlState.hovered, GLUControlState.start), false, 0, GLUAnimationConflictDecisionType.replace, mcs, lrs));

        GLUAnimationSet satellitesSet = new GLUAnimationSet();

        mcs = new GLUMaterialColorSequence(WrapMode.Clamp, WrapMode.Clamp, 3, new GLUKey<Vector4>(0, new Vector4(1, 1, 1, 0.75f)));
        lrs = new GLULocalRotationSequence(WrapMode.Clamp, WrapMode.Clamp, 180, new GLUKey<Vector3>(0, Vector3.zero));
        lss = new GLULocalScaleSequence(WrapMode.Clamp, WrapMode.Clamp, 1, new GLUKey<Vector3>(0, new Vector3(1.4f, 1.4f, 1.4f)));

        satellitesSet.AddAnimation(new GLUAnimation(GLUAnimationSet.CreateIndex(GLUControlState.hovered, GLUControlState.hovered | GLUControlState.start), false, 1, GLUAnimationConflictDecisionType.replace, mcs, lrs, lss));

        mcs = new GLUMaterialColorSequence(WrapMode.Loop, WrapMode.Loop, 0, new GLUKey<Vector4>(0, new Vector4(1, 1, 1, 0.75f)), new GLUKey<Vector4>(0.5f, new Vector4(1, 1, 1, 0.75f)), new GLUKey<Vector4>(0.55f, new Vector4(1, 0.5f, 0.5f, 1)));
        mcs.AddKey(0.6f, new Vector4(1, 1, 1, 0.75f));
        lrs = new GLULocalRotationSequence(WrapMode.Loop, WrapMode.Loop, 0, new GLUKey<Vector3>(0, Vector3.zero), new GLUKey<Vector3>(9f, new Vector3(0, 0, 360)));

        satellitesSet.AddAnimation(new GLUAnimation(GLUAnimationSet.CreateIndex(GLUControlState.hovered, GLUControlState.hovered), true, 0, GLUAnimationConflictDecisionType.replace, mcs, lrs));

        mcs = new GLUMaterialColorSequence(WrapMode.Clamp, WrapMode.Clamp, 3, new GLUKey<Vector4>(0, new Vector4(1, 1, 1, 0.5f)));
        lrs = new GLULocalRotationSequence(WrapMode.Clamp, WrapMode.Clamp, 180, new GLUKey<Vector3>(0, Vector3.zero));

        satellitesSet.AddAnimation(new GLUAnimation(GLUAnimationSet.CreateIndex(GLUControlState.hovered, GLUControlState.start), false, 1, GLUAnimationConflictDecisionType.replace, mcs, lrs));

        lss = new GLULocalScaleSequence(WrapMode.Clamp, WrapMode.Clamp, 1, new GLUKey<Vector3>(0, new Vector3(1f, 1f, 1f)));
        satellitesSet.AddAnimation(new GLUAnimation(GLUAnimationSet.CreateIndex(GLUControlState.hovered, 0), false, 0, GLUAnimationConflictDecisionType.replace, lss));
        // satellitesSet.AddAnimation(new GLUAnimation((int)GLUInternalButtonEvent.pressedLeave, false, mcs, lrs, lss));


        GLUAnimationSet pressSet = new GLUAnimationSet();

        mcs = new GLUMaterialColorSequence(WrapMode.Clamp, WrapMode.Clamp, 0, new GLUKey<Vector4>(0.0f, new Vector4(1, 1, 1, 0.0f)));
        lss = new GLULocalScaleSequence(WrapMode.Clamp, WrapMode.Clamp, 0, new GLUKey<Vector3>(0, new Vector3(0.25f, 0.25f, 0.25f)));

        pressSet.AddAnimation(new GLUAnimation(0, false, 255, GLUAnimationConflictDecisionType.replace, mcs, lss));

        mcs = new GLUMaterialColorSequence(WrapMode.Clamp, WrapMode.Clamp, 10, new GLUKey<Vector4>(0, new Vector4(0.75f, 0.85f, 1, 1)), new GLUKey<Vector4>(0.15f, new Vector4(0.75f, 0.85f, 1, 0)));
        lss = new GLULocalScaleSequence(WrapMode.Clamp, WrapMode.Clamp, 0, new GLUKey<Vector3>(0, new Vector3(0.25f, 0.25f, 0.25f)), new GLUKey<Vector3>(0.25f, new Vector3(1.4f, 1.4f, 1.4f)));

        pressSet.AddAnimation(new GLUAnimation(GLUAnimationSet.CreateIndex(GLUControlState.leftInputButtonPressed, GLUControlState.leftInputButtonPressed | GLUControlState.start), false, 1, GLUAnimationConflictDecisionType.replace, mcs, lss));

        GLUAnimationSet sectorsSet = new GLUAnimationSet();

        mcs = new GLUMaterialColorSequence(WrapMode.Clamp, WrapMode.Clamp, 0f, new GLUKey<Vector4>(0, new Vector4(1f, 1f, 1f, 0.75f)));
        sectorsSet.AddAnimation(new GLUAnimation(0, false, 255, GLUAnimationConflictDecisionType.replace, mcs));

        mcs = new GLUMaterialColorSequence(WrapMode.Loop, WrapMode.Loop, 0);
        mcs.AddKey(0f, new Vector4(0.5f, 0.75f, 1f, 0.75f));
        mcs.AddKey(0.5f, new Vector4(1, 1, 1, 0.75f));
        mcs.AddKey(0.55f, new Vector4(1, 1, 1, 1));
        mcs.AddKey(0.6f, new Vector4(1, 1, 1, 0.75f));

        sectorsSet.AddAnimation(new GLUAnimation(GLUAnimationSet.CreateIndex(GLUControlState.hovered, GLUControlState.hovered | GLUControlState.start), true, 0, GLUAnimationConflictDecisionType.replace, mcs));
        // sectorsSet.debug = true;

        mcs = new GLUMaterialColorSequence(WrapMode.Clamp, WrapMode.Clamp, 0f, new GLUKey<Vector4>(0, new Vector4(1f, 1f, 1f, 0.75f)));
        // mcs.debug = true;
        sectorsSet.AddAnimation(new GLUAnimation(GLUAnimationSet.CreateIndex(GLUControlState.hovered, GLUControlState.start), false, 0, GLUAnimationConflictDecisionType.replace, mcs));


        /* foreach (KeyValuePair<int, GLUAnimation> p in sectorsSet)
        {
            // // GLUDebug.Log("Listing " + p.Value + ", debug = " + p.Value.debug);
            foreach (GLUKeySequence ks in p.Value)
            {
                // // GLUDebug.Log(ks + ",  debug = " + ks.debug);
            }
        }*/

        testButton0 = AddChild(new GLUButton(this, "AButton0", new GLUNumber(64), new GLUNumber(64), new GLUNumber(128), new GLUNumber(128), new GLUPadding(0), false, "", false, new GLUInternalImage[7]{
            new GLUInternalImage("pressLayer", "GLU/Controls/Textures/AButton/press", new GLUBorders(0), pressSet),
            new GLUInternalImage("sectorsLayer", "GLU/Controls/Textures/AButton/sectorBg", new GLUBorders(0), sectorsSet),
            new GLUInternalImage("starcLayer", "GLU/Controls/Textures/AButton/starc", new GLUBorders(0), null),
            new GLUInternalImage("satellitesLayer", "GLU/Controls/Textures/AButton/satellites", new GLUBorders(0), satellitesSet),
            new GLUInternalImage("hudLayer", new GLUNumber(0), new GLUNumber(0), new GLUNumber(96), new GLUNumber(96), "GLU/Controls/Textures/AButton/glueHUD", new GLUBorders(0), GLUHorizontalAlignment.center, GLUVerticalAlignment.middle, glueHUDSet),
            new GLUInternalImage("compassLayer", new GLUNumber(0), new GLUNumber(0), new GLUNumber(76), new GLUNumber(76), "GLU/Controls/Textures/AButton/compass", new GLUBorders(0), GLUHorizontalAlignment.center, GLUVerticalAlignment.middle, compassSet),
            new GLUInternalImage("dialLayer", new GLUNumber(0), new GLUNumber(0), new GLUNumber(56), new GLUNumber(56), "GLU/Controls/Textures/AButton/dial", new GLUBorders(0), GLUHorizontalAlignment.center, GLUVerticalAlignment.middle, null)})) as GLUButton;

        testButton1 = AddChild(new GLUButton(this, "AButton1", new GLUNumber(clientWidth - 192), new GLUNumber(64), new GLUNumber(128), new GLUNumber(128), new GLUPadding(0), false, "", false, new GLUInternalImage[7]{
            new GLUInternalImage("pressLayer", "GLU/Controls/Textures/AButton/press", new GLUBorders(0), pressSet),
            new GLUInternalImage("sectorsLayer", "GLU/Controls/Textures/AButton/sectorBg", new GLUBorders(0), sectorsSet),
            new GLUInternalImage("starcLayer", "GLU/Controls/Textures/AButton/starc", new GLUBorders(0), null),
            new GLUInternalImage("satellitesLayer", "GLU/Controls/Textures/AButton/satellites", new GLUBorders(0), satellitesSet),
            new GLUInternalImage("hudLayer", new GLUNumber(0), new GLUNumber(0), new GLUNumber(96), new GLUNumber(96), "GLU/Controls/Textures/AButton/glueHUD", new GLUBorders(0), GLUHorizontalAlignment.center, GLUVerticalAlignment.middle, glueHUDSet),
            new GLUInternalImage("compassLayer", new GLUNumber(0), new GLUNumber(0), new GLUNumber(76), new GLUNumber(76), "GLU/Controls/Textures/AButton/compass", new GLUBorders(0), GLUHorizontalAlignment.center, GLUVerticalAlignment.middle, compassSet),
            new GLUInternalImage("dialLayer", new GLUNumber(0), new GLUNumber(0), new GLUNumber(56), new GLUNumber(56), "GLU/Controls/Textures/AButton/dial", new GLUBorders(0), GLUHorizontalAlignment.center, GLUVerticalAlignment.middle, null)})) as GLUButton;

        testButton2 = AddChild(new GLUButton(this, "AButton2", new GLUNumber(64), new GLUNumber(clientHeight - 192), new GLUNumber(128), new GLUNumber(128), new GLUPadding(0), false, "", false, new GLUInternalImage[7]{
            new GLUInternalImage("pressLayer", "GLU/Controls/Textures/AButton/press", new GLUBorders(0), pressSet),
            new GLUInternalImage("sectorsLayer", "GLU/Controls/Textures/AButton/sectorBg", new GLUBorders(0), sectorsSet),
            new GLUInternalImage("starcLayer", "GLU/Controls/Textures/AButton/starc", new GLUBorders(0), null),
            new GLUInternalImage("satellitesLayer", "GLU/Controls/Textures/AButton/satellites", new GLUBorders(0), satellitesSet),
            new GLUInternalImage("hudLayer", new GLUNumber(0), new GLUNumber(0), new GLUNumber(96), new GLUNumber(96), "GLU/Controls/Textures/AButton/glueHUD", new GLUBorders(0), GLUHorizontalAlignment.center, GLUVerticalAlignment.middle, glueHUDSet),
            new GLUInternalImage("compassLayer", new GLUNumber(0), new GLUNumber(0), new GLUNumber(76), new GLUNumber(76), "GLU/Controls/Textures/AButton/compass", new GLUBorders(0), GLUHorizontalAlignment.center, GLUVerticalAlignment.middle, compassSet),
            new GLUInternalImage("dialLayer", new GLUNumber(0), new GLUNumber(0), new GLUNumber(56), new GLUNumber(56), "GLU/Controls/Textures/AButton/dial", new GLUBorders(0), GLUHorizontalAlignment.center, GLUVerticalAlignment.middle, null)})) as GLUButton;

        testButton3 = AddChild(new GLUButton(this, "AButton3", new GLUNumber(clientWidth - 192), new GLUNumber(clientHeight - 192), new GLUNumber(128), new GLUNumber(128), new GLUPadding(0), false, "", false, new GLUInternalImage[7]{
            new GLUInternalImage("pressLayer", "GLU/Controls/Textures/AButton/press", new GLUBorders(0), pressSet),
            new GLUInternalImage("sectorsLayer", "GLU/Controls/Textures/AButton/sectorBg", new GLUBorders(0), sectorsSet),
            new GLUInternalImage("starcLayer", "GLU/Controls/Textures/AButton/starc", new GLUBorders(0), null),
            new GLUInternalImage("satellitesLayer", "GLU/Controls/Textures/AButton/satellites", new GLUBorders(0), satellitesSet),
            new GLUInternalImage("hudLayer", new GLUNumber(0), new GLUNumber(0), new GLUNumber(96), new GLUNumber(96), "GLU/Controls/Textures/AButton/glueHUD", new GLUBorders(0), GLUHorizontalAlignment.center, GLUVerticalAlignment.middle, glueHUDSet),
            new GLUInternalImage("compassLayer", new GLUNumber(0), new GLUNumber(0), new GLUNumber(76), new GLUNumber(76), "GLU/Controls/Textures/AButton/compass", new GLUBorders(0), GLUHorizontalAlignment.center, GLUVerticalAlignment.middle, compassSet),
            new GLUInternalImage("dialLayer", new GLUNumber(0), new GLUNumber(0), new GLUNumber(56), new GLUNumber(56), "GLU/Controls/Textures/AButton/dial", new GLUBorders(0), GLUHorizontalAlignment.center, GLUVerticalAlignment.middle, null)})) as GLUButton;
        Debug.Log(" clientWidth = " + width + ", clientHeight = " + height);
    }


    public CustomButtonExampleForm()
        : base()
    {
        // CreateControls(); 
    }


}


