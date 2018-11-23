using System;
using G2048.IO;
using UnityEngine;

namespace G2048.IO.UserInputs
{
    public class DownUserInput : UserInput
    {
        public bool HasOccured()
        {
            return Input.GetKeyDown(KeyCode.DownArrow) ||
                        MouseState.Current.FlickDown;
        }
    }
}
