using System;
using G2048.IO.UserInputs;

namespace G2048.IO
{
    public static class UserInputFactory
    {
        public static UserInput Left  { get; } = new LeftUserInput();
        public static UserInput Right { get; } = new RightUserInput();
        public static UserInput Up    { get; } = new UpUserInput();
        public static UserInput Down  { get; } = new DownUserInput();
    }
}
