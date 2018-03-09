using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class SerializedPropertyExtension
{
    public static void AddToObjectArray<T>(this SerializedProperty arrayProperty, T item) where T : Object
    {
        if (!arrayProperty.isArray) {
            throw new UnityException(string.Format("Serialized Property {0} is not an array", arrayProperty.name));
        }

        arrayProperty.serializedObject.Update();
        arrayProperty.InsertArrayElementAtIndex(arrayProperty.arraySize);
        arrayProperty.GetArrayElementAtIndex(arrayProperty.arraySize - 1).objectReferenceValue = item;
        arrayProperty.serializedObject.ApplyModifiedProperties();
    }

    public static void RemoveFromObjectArrayAt(this SerializedProperty arrayProperty, int index)
    {
        if(index < 0) {
            throw new UnityException("Removing negative index not supported");
        }

        if (!arrayProperty.isArray) {
            throw new UnityException(string.Format("Serialized Property {0} is not an array", arrayProperty.name));
        }

        if(index > arrayProperty.arraySize - 1) {
            throw new UnityException(string.Format("Index is out of bounds", arrayProperty.name));
        }

        arrayProperty.serializedObject.Update();
        if (arrayProperty.GetArrayElementAtIndex(index).objectReferenceValue) {
            arrayProperty.DeleteArrayElementAtIndex(index);
        }
        arrayProperty.DeleteArrayElementAtIndex(index);
        arrayProperty.serializedObject.ApplyModifiedProperties();
    }

    public static void RemoveFromObjectArray<T>(this SerializedProperty arrayProperty, T elementToRemove) where T: Object
    {
        if (!arrayProperty.isArray) {
            throw new UnityException(string.Format("Serialized Property {0} is not an array", arrayProperty.name));
        }

        if (!elementToRemove) {
            throw new UnityException("Removing null element is not supported");
        }

        arrayProperty.serializedObject.Update();
        for(var i = 0; i < arrayProperty.arraySize; i++) {
            var elementProperty = arrayProperty.GetArrayElementAtIndex(i);
            if(elementProperty.objectReferenceValue == elementToRemove) {
                arrayProperty.RemoveFromObjectArrayAt(i);
                return;
            }
        }

        throw new UnityException(string.Format("Element {0} not found in property {1}", elementToRemove.name, arrayProperty.name));
    }
}
