using UnityEngine;

namespace RainbowCube
{
    public static class MyUtils
    {
        public static float Map(float x, float inMin, float inMax, float outMin, float outMax)
        {
            var result = (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
            result = Mathf.Max(outMin, Mathf.Min(result, outMax));
            return result;
        }
    }
}