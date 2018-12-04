using System;

namespace G2048.Models
{
    public class Timer
    {
        public float Remain { get; private set; }
        public float Max { get; private set; }
        public bool Active { get; private set; }

        public Timer(float remain = 0, float max = 1, bool active = true)
        {
            this.Remain = remain;
            this.Max = max;
            this.Active = active;
        }

        public Timer Modify(float remain, float max, bool active)
        {
            if (IsSame(remain, max, active))
            {
                return this;
            }
            else
            {
                return new Timer(remain: remain, max: max, active: active);
            }
        }

        private bool IsSame(float remain, float max, bool active)
        {
            return this.Remain == remain &&
                this.Max == max &&
                this.Active == active;
        }

        public Timer ModifyRemain(float remain)
        {
            return Modify(remain: remain, max: this.Max, active: this.Active);
        }

        public Timer ModifyMax(float max)
        {
            return Modify(remain: this.Remain, max: max, active: this.Active);
        }

        public Timer ModifyActive(bool active)
        {
            return Modify(remain: this.Remain, max: this.Max, active: active);
        }

        public float Ratio()
        {
            return Max == 0f ? 1 : Remain / Max;
        }

    }
}
