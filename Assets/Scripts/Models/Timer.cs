using System;

namespace G2048.Models
{
    public class Timer
    {
        public float Remain { get; private set; }
        public float Max { get; private set; }

        public Timer(float remain = 0, float max = 1)
        {
            this.Remain = remain;
            this.Max = max;
        }

        public Timer Modify(float remain, float max)
        {
            if (IsSame(remain, max))
            {
                return this;
            }
            else
            {
                return new Timer(remain: remain, max: max);
            }
        }

        private bool IsSame(float remain, float max)
        {
            return this.Remain == remain &&
                this.Max == max;
        }

        public Timer ModifyRemain(float remain)
        {
            return Modify(remain: remain, max: this.Max);
        }

        public Timer ModifyMax(float max)
        {
            return Modify(remain: this.Remain, max: max);
        }

    }
}
