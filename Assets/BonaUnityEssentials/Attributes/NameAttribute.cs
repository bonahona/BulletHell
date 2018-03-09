using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameAttribute : System.Attribute
{
    public string Name;

    public NameAttribute(string name)
    {
        Name = name;
    }
}
