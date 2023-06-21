using SmugBase.Saving;
using SmugMacros.Windows;

namespace SmugMacros.Input
{
    public class MouseInput : MacroInput
    {
        public Point MousePosition { get; internal set; }

        public MouseEvents MouseEvents { get; internal set; }

        public uint MouseData { get; internal set; }

        public MouseInput() : base((uint)InputType.Mouse) { }

        public MouseInput(Point mousePosition, MouseEvents mouseEvents, uint mouseData) : base((uint)InputType.Mouse)
        {
            MousePosition = mousePosition;
            MouseEvents = mouseEvents;
            MouseData = mouseData;
            Input = ToInput();
        }

        public override InputUnion ToInputUnion()
        {
            int dx = MousePosition.X * 65535;
            int dy = MousePosition.Y * 65535;

            if (Screen.PrimaryScreen != null)
            {
                dx /= Screen.PrimaryScreen.Bounds.Width;
                dy /= Screen.PrimaryScreen.Bounds.Height;
            }

            InputUnion outPut = new InputUnion()
            {
                mi = new Windows.MouseInput()
                {
                    dx = dx,
                    dy = dy,
                    mouseData = MouseData,
                    dwFlags = (uint)MouseEvents,
                    dwExtraInfo = Library.GetMessageExtraInfo()
                }
            };

            if (MouseEvents == MouseEvents.Move)
            {
                outPut.mi.dwFlags = (uint)(MouseEvents.Move | MouseEvents.VirtualDesk | MouseEvents.Absolute);
            }

            return outPut;
        }

        public override string ToReadableInputName() => "Mouse";

        public override string ToReadableInputInformation()
        {
            string outPut = string.Empty;
            switch (MouseEvents)
            {
                case MouseEvents.LeftDown:
                    outPut += "Left Mouse Button Down";
                    break;

                case MouseEvents.LeftUp:
                    outPut += "Left Mouse Button Up";
                    break;

                case MouseEvents.RightDown:
                    outPut += "Right Mouse Button Down";
                    break;

                case MouseEvents.RightUp:
                    outPut += "Right Mouse Button Up";
                    break;

                case MouseEvents.MiddleDown:
                    outPut += "Middle Mouse Button Down";
                    break;

                case MouseEvents.MiddleUp:
                    outPut += "Middle Mouse Button Up";
                    break;

                case MouseEvents.XDown:
                    {
                        if (MouseData == 0x0001)
                        {
                            outPut += "Upper Side Button Down";
                        }
                        else if (MouseData == 0x0002)
                        {
                            outPut += "Lower Side Button Down";
                        }
                    }
                    break;

                case MouseEvents.XUp:
                    {
                        if (MouseData == 0x0001)
                        {
                            outPut += "Upper Side Button Up";
                        }
                        else if (MouseData == 0x0002)
                        {
                            outPut += "Lower Side Button Up";
                        }
                    }
                    break;

                case MouseEvents.Move:
                    {
                        outPut += "Moves mouse to {" + MousePosition.X + ", " + MousePosition.Y + "}";
                    }
                    break;
            }
            return outPut;
        }

        public override void SaveAsIODictionary(IODictionary ioDictionary)
        {
            ioDictionary.Add("MousePosition X", MousePosition.X);
            ioDictionary.Add("MousePosition Y", MousePosition.Y);
            ioDictionary.Add("MouseEvents", (int)MouseEvents);
            ioDictionary.Add("MouseData", MouseData);
        }

        public override MacroInput? LoadFromIODictionary(IODictionary ioDictionary)
        {
            ioDictionary.TryGet("MousePosition X", out int mousePosX);
            ioDictionary.TryGet("MousePosition Y", out int mousePosY);
            ioDictionary.TryGet("MouseEvents", out int mouseEvents);
            ioDictionary.TryGet("MouseData", out uint mouseData);
            return new MouseInput(new Point(mousePosX, mousePosY), (MouseEvents)mouseEvents, mouseData);
        }
    }
}
