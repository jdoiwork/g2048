using System;
namespace G2048.Models
{
    public class Score
    {
        public Score()
        {
        }

        public ulong Point
        {
            get;
            set;
        }

        private static Score _current;
        public static Score Current {
            get {
                if (_current == null)
                {
                    Reset();
                }

                return _current;
            }
        }

        public static void Reset()
        {
            _current = new Score();
        }
    }
}
