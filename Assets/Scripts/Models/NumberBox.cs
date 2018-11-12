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
            private set;
        }

        public int Y
        {
            get;
            private set;
        }

        public NumberBox MoveX(int x)
        {
            return new NumberBox(x, this.Y);
        }

        public NumberBox MoveY(int y)
        {
            return new NumberBox(this.X, y);
        }
    }
}
