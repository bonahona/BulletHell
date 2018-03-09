using UnityEngine;
using System.Collections;

public static class RandomFloat
{
    private static System.Random s_randomGenerator;

    static RandomFloat()
    {
        s_randomGenerator = new System.Random(System.DateTime.Now.Millisecond);
    }

    public static float Range(float lowerBounds, float upperBounds)
    {
        var result = (float)s_randomGenerator.NextDouble() * (upperBounds - lowerBounds);
        return result + lowerBounds;
    }
}
