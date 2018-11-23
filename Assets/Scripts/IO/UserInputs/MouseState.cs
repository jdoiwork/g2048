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
                var p = Input.mousePosition;
                var d = state.LastMousePosition - p;

                return new MouseState(UpdateInPressed)
                {
                    LastMousePosition = p,
                    FlickLeft = d.x > 0,
                };
            }
        }

        private static MouseState UpdateInReleased(MouseState state)
        {
            if (Input.GetMouseButtonDown(mouseButtonNo))
            {
                //Debug.Log("mouse down");
                return new MouseState(UpdateInPressed);
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
    }
}
