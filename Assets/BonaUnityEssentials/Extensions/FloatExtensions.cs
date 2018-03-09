using UnityEngine;
using System.Collections;

public static class FloatExtensioons
{
    public static bool Contains(this float f, float lowerBounds, float upperBounds, ContainsFlags containsFlag = ContainsFlags.Inclusive)
    {
        if (containsFlag == ContainsFlags.Inclusive) {
            return (f >= lowerBounds && f <= upperBounds);
        } else if (containsFlag == ContainsFlags.Exlusive) {
            return (f > lowerBounds && f < upperBounds);
        } else if (containsFlag == ContainsFlags.LowerInclusive) {
            return (f >= lowerBounds && f < upperBounds);
        } else if (containsFlag == ContainsFlags.UpperInclusive) {
            return (f > lowerBounds && f <= upperBounds);
        } else {
            return false;
        }
    }
}
