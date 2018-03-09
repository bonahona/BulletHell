using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomPropertyDrawer(typeof(InputAxisAttribute))]
public class AxisCustomDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var axisNames = GetAxisNames();
        if (axisNames.Count > 0) {
            int selectedSceneIndex = EditorGUI.Popup(position, label, GetIndex(axisNames, property.stringValue), GetGuiContent(axisNames));
            property.stringValue = axisNames[selectedSceneIndex];
        }else {
            EditorGUI.LabelField(position, label, new GUIContent("No axis found"));
        }
    }

    private List<string> GetAxisNames()
    {
        var result = new List<string>();

        var inputManager = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/InputManager.asset")[0];
        var obj = new SerializedObject(inputManager);
        var axisArray = obj.FindProperty("m_Axes");

        // None found
        if(axisArray.arraySize == 0) {
            return result;
        }

        for(int i = 0; i < axisArray.arraySize; i++) {
            var axis = axisArray.GetArrayElementAtIndex(i);

            var name = axis.FindPropertyRelative("m_Name").stringValue;
            result.Add(name);
        }

        return result;
    }

    private int GetIndex(List<string> names, string current)
    {
        if(current == string.Empty) {
            return 0;
        }

        for(int i = 0; i < names.Count; i++) {
            if(names[i] == current) {
                return i;
            }
        }

        // No result found (Should never happen)
        return 0;
    }

    private GUIContent[] GetGuiContent(List<string> stringArray)
    {
        List<GUIContent> result = new List<GUIContent>();
        foreach (var item in stringArray) {
            result.Add(new GUIContent(item));
        }

        return result.ToArray();
    }
}
