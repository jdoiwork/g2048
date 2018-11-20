using System;
namespace G2048.Models
{
    public class NumberBox
    {
        public NumberBox() : this(0, 0)
        {

        }

        public NumberBox(int x, int y) : this(x, y, 2)
        {
        }

        public NumberBox(int x, int y, ulong n)
        {
            this.X = x;
            this.Y = y;
            this.N = n;
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

        public ulong N
        {
            get;
            private set;
        }

        public NumberBox MoveX(int x)
        {
            return new NumberBox(x, this.Y, this.N);
        }

        public NumberBox MoveY(int y)
        {
            return new NumberBox(this.X, y, this.N);
        }

        public NumberBox Double()
        {
            return new NumberBox(this.X, this.Y, this.N * 2);
        }
    }
}
