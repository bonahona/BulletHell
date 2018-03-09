using UnityEngine;
using System.Collections;

public static class IntExtensions
{
    public static bool Contains(this int i, int lowerBounds, int upperBounds, ContainsFlags containsFlag = ContainsFlags.Inclusive)
    {
        if (containsFlag == ContainsFlags.Inclusive) {
            return (i >= lowerBounds && i <= upperBounds);
        } else if (containsFlag == ContainsFlags.Exlusive) {
            return (i > lowerBounds && i < upperBounds);
        } else if (containsFlag == ContainsFlags.LowerInclusive) {
            return (i >= lowerBounds && i < upperBounds);
        } else if (containsFlag == ContainsFlags.UpperInclusive) {
            return (i > lowerBounds && i <= upperBounds);
        } else {
            return false;
        }
    }
}
