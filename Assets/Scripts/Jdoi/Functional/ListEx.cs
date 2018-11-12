using System;
using System.Collections.Generic;
using System.Linq;

namespace Jdoi.Functional
{
    static public class List
    {
        public static IEnumerable<A> Cons<A>(this A head, IEnumerable<A> tail)
        {
            return tail.Prepend(head);
        }
    }
}
