using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[CustomPropertyDrawer(typeof(SceneAttribute))]
public class SceneCustomDrawer : PropertyDrawer {

	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
    {
        var sceneAttribute = attribute as SceneAttribute;
        var sceneNames = GetSceneNames(sceneAttribute.AllowInactiveScenes);

        if (sceneNames.Count > 0) {
            int selectedSceneIndex = EditorGUI.Popup(position, label, GetIndex(sceneNames, property.stringValue), GetGuiContent(sceneNames));
            property.stringValue = sceneNames[selectedSceneIndex];
        }else {
            EditorGUI.LabelField(position, label, new GUIContent("No scenes found"));
        }
    }

    private List<string> GetSceneNames(bool allowInacticeScenes){
        var result = new List<string>();
        foreach (var scene in EditorBuildSettings.scenes) {
            if (scene.enabled || allowInacticeScenes) {
                result.Add(GetSceneName(scene.path));
            }
        }

        return result;
    }

    private string GetSceneName(string scenePath)
    {
        return scenePath.Split('/').Last().Replace(".unity", "");
    }

    private int GetIndex(List<string> names, string current)
    {
        if(current == ""){
            return 0;
        }

        for(int i = 0; i < names.Count; i ++){
            if(names[i] == current){
                return i;
            }
        }
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
