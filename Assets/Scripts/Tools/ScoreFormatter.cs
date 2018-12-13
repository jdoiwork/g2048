
using System;

namespace G2048.Tools
{
    public class ScoreFormatter
    {
        public static string Format(ulong score)
        {
            return string.Format("{0:N0}", score);
        }

        public static string CostFormat(ulong score)
        {
            return string.Format("Cost -{0}", Format(score));
        }
    }
}
