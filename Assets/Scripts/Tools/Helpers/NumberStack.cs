using System;
using System.Collections.Generic;
using System.Linq;
using G2048.Models;

namespace G2048.Tools.Helpers
{
    public class NumberStack
    {
        public NumberBox Box { get; private set; }
        public ulong[] PlusScores { get; private set; }

        public NumberStack(NumberBox box)
        {
            this.Box = box;
            this.PlusScores = new ulong[0];
        }

        public NumberStack Double()
        {
            var doubledBox = Box.Double();
            var newScores = PlusScores.Append(doubledBox.N).ToArray();
            return new NumberStack (doubledBox) {
                PlusScores = newScores
            };
        }

        public NumberStack ModifyBox(NumberBox box)
        {
            return new NumberStack(box)
            {
                PlusScores = this.PlusScores
            };
        }

        public static IEnumerable<NumberBox> MapBoxWithAction(IEnumerable<NumberStack> nss, Action<NumberStack> action)
        {
            foreach (var ns in nss)
            {
                if (ns.PlusScores.Any())
                {
                    action(ns);
                }

                yield return ns.Box;
            }
        }
    }
}
