using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTypeAttribute : PropertyAttribute
{
    public Type Type;

    public BehaviourTypeAttribute(Type type)
    {
        Type = type;
    }
}
