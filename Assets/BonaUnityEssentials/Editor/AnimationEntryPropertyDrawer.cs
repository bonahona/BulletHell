using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(AnimationEntry))]
public class AnimationEntryPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var gameObject = property.serializedObject.targetObject.ToOrDefault<MonoBehaviour>();

        if(gameObject == null) {
            EditorGUI.LabelField(position, label, new GUIContent("No animations"));
            return;
        }

        var animator = gameObject.GetComponent<Animator>();
        if(animator == null) {
            EditorGUI.LabelField(position, label, new GUIContent("No animations"));
            return;
        }

        var animationClipNames = GetAnimationClipNames(animator);
        var selectedIndex = EditorGUI.Popup(position, label, 0, animationClipNames);
        //var test = EditorGUI.TextField(position, label, property.stringValue);
    }

    private GUIContent[] GetAnimationClipNames(Animator animator)
    {
        var result = new List<GUIContent>();

        if (animator.runtimeAnimatorController == null) {
            return result.ToArray();
        }


        foreach(var clip in animator.runtimeAnimatorController.animationClips) {
            result.Add(new GUIContent(clip.name));
        }

        return result.ToArray();
    }

}
