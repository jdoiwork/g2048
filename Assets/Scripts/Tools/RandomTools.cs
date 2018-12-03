using System;

namespace G2048.Tools
{
    public static class RandomTools
    {

        public static int RandomBetweenZeroToLessThan(int n)
        {
            return UnityEngine.Random.Range(0, n);
        }

        public static int RandomIndex<T>(T[] xs)
        {
            return RandomBetweenZeroToLessThan(xs.Length);
        }

        public static T RandomElement<T>(T[] xs)
        {
            return xs[RandomIndex(xs)];
        }

    }
}
