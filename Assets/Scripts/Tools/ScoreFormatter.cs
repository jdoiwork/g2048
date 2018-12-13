
using System;

namespace G2048.Tools
{
    public class ScoreFormatter
    {
        public static string Format(int score)
        {
            return string.Format("{0:N0}", score);
        }
    }
}
