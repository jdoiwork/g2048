using System;
using G2048.IO;
using UnityEngine;

namespace G2048.IO.UserInputs
{
    public class RightUserInput : UserInput
    {
        public bool HasOccured()
        {
            return Input.GetKeyDown(KeyCode.RightArrow) ||
                        MouseState.Current.FlickRight;
        }
    }
}
