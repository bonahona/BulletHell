using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeSortOrderAttribute : System.Attribute
{
    public int SortOrder = int.MaxValue;

    public TypeSortOrderAttribute(int sortOrder)
    {
        SortOrder = sortOrder;
    }
}
