using System;
namespace AssemblyCSharp.Assets.Scripts.Models
{
    public class NumberBox
    {
        public NumberBox()
        {

        }

        public NumberBox(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }
    }
}
