﻿using System;

namespace G2048.Models
{
    public class Pos
    {
        public Pos(int x, int y)
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
    }
}
