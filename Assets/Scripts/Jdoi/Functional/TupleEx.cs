using System;
using System.Collections.Generic;

namespace Jdoi.Functional
{
    static public class TupleEx
    {
        public static void Each<A, B, C>(this IEnumerable<Tuple<A, B, C>> ts, Action<A, B, C> f)
        {
            foreach (var item in ts)
            {
                f(item.Item1, item.Item2, item.Item3);
            }
        }

        public static void Each<A, B, C, D>(this IEnumerable<Tuple<A, B, C, D>> ts, Action<A, B, C, D> f)
        {
            foreach (var item in ts)
            {
                f(item.Item1, item.Item2, item.Item3, item.Item4);
            }
        }
    }
}
