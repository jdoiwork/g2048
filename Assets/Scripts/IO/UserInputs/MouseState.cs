using System;
using UnityEngine;

namespace G2048.IO
{
    using StateUpdater = Func<MouseState, MouseState>;

    public class MouseState
    {
        private const int mouseButtonNo = 0;

        public Vector3 LastMousePosition
        {
            get;
            private set;
        }

        public StateUpdater UpdateBehavior
        {
            get;
            private set;
        }

        public static MouseState Create()
        {
            return new MouseState(UpdateInReleased);
        }

        private MouseState(StateUpdater updateBehavior)
        {
            this.UpdateBehavior = updateBehavior;
        }

        public MouseState Update()
        {
            return UpdateBehavior(this);
        }

        private static MouseState UpdateInPressed(MouseState state)
        {
            if (Input.GetMouseButtonUp(mouseButtonNo))
            {
                //Debug.Log("mouse up");
                return new MouseState(UpdateInReleased);
            }
            else
            {
                return UpdateInPressedOnMove(state);
            }
        }

        private static MouseState UpdateInPressedOnMove(MouseState state)
        {
            var p = Input.mousePosition;
            var d = state.LastMousePosition - p;
            var margin = 2500;

            if (d.sqrMagnitude < margin)
            {
                return state;
            }
            else
            {
                var h = Mathf.Abs(d.x) > Mathf.Abs(d.y);
                var v = !h;

                return new MouseState(UpdateInPressed)
                {
                    LastMousePosition = p,
                    FlickLeft  = h && d.x > 0,
                    FlickRight = h && d.x < 0,
                    FlickDown  = v && d.y > 0,
                    FlickUp    = v && d.y < 0,
                };
            }
        }

        private static MouseState UpdateInReleased(MouseState state)
        {
            if (Input.GetMouseButtonDown(mouseButtonNo))
            {
                //Debug.Log("mouse down");
                return new MouseState(UpdateInPressed) {
                    LastMousePosition = Input.mousePosition,
                };
            }
            else
            {
                return state;
            }
        }

        public static MouseState Current
        {
            get;
            private set;
        } = MouseState.Create();

        public static void UpdateCurrent()
        {
            Current = Current.Update();
        }

        public bool FlickLeft
        {
            get; private set;
        }

        public bool FlickRight
        {
            get; private set;
        }

        public bool FlickUp
        {
            get; private set;
        }

        public bool FlickDown
        {
            get; private set;
        }
    }
}
