using System;
using G2048.IO;

namespace G2048.Models
{
    public class UserAction
    {
        public UserAction(UserInput userInput, Func<NumberBox[], NumberBox[]> merge)
        {
            this.Input = userInput;
            this.Merge = merge;
        }

        public UserInput Input
        {
            get;
            private set;
        }

        public Func<NumberBox[], NumberBox[]> Merge
        {
            get;
            private set;
        }
    }
}
