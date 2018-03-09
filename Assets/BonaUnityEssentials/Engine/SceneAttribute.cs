using UnityEngine;
using System.Collections;

public class SceneAttribute : PropertyAttribute
{
    public bool AllowInactiveScenes;

    public SceneAttribute(bool allowInactiveScenes = false)
    {
        AllowInactiveScenes = allowInactiveScenes;
    }
}
