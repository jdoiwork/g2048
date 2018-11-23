using System;
using G2048.Models;

namespace G2048.IO
{
    using Merger = Func<NumberBox[], NumberBox[]>;

    public static class UserActionFactory
    {
        public static UserAction Left(Merger merger)
        {
            return new UserAction(UserInputFactory.Left, merger);
        }

        public static UserAction Right(Merger merger)
        {
            return new UserAction(UserInputFactory.Right, merger);
        }

        public static UserAction Up(Merger merger)
        {
            return new UserAction(UserInputFactory.Up, merger);
        }

        public static UserAction Down(Merger merger)
        {
            return new UserAction(UserInputFactory.Down, merger);
        }
    }
}
