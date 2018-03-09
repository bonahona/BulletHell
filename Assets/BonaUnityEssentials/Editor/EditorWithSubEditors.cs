using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public abstract class EditorWithSubEditors<TEditor, TTarget> : Editor
    where TEditor: Editor
    where TTarget: Object
{

    protected TEditor[] SubEditors;

    protected void CheckAndCreateSubEditors(TTarget[] subEditorTargets)
    {
        if(SubEditors != null && SubEditors.Length == subEditorTargets.Length) {
            return;
        }

        CleanUpEditors();

        SubEditors = new TEditor[subEditorTargets.Length];
        for(var i = 0; i < SubEditors.Length; i++) {
            SubEditors[i] = CreateEditor(subEditorTargets[i]) as TEditor;
            SubEditorSetup(SubEditors[i]);
        }
    }

    protected void CleanUpEditors()
    {
        if(SubEditors == null) {
            return;
        }

        for (var i = 0; i < SubEditors.Length; i++) {
            DestroyImmediate(SubEditors[i]);
        }

        SubEditors = null;
    }

    protected abstract void SubEditorSetup(TEditor editor);
}
