using System;
using System.Collections.Generic;

namespace Jdoi.Functional
{
    static public class List
    {
        public static IEnumerable<A> Cons<A>(this A head, IEnumerable<A> tail)
        {
            yield return head;

            foreach (var item in tail)
            {
                yield return item;
            }
        }
    }
}
