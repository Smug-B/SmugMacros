using SmugBase.Saving;
using SmugMacros.Windows;
using System.Text;

namespace SmugMacros.Input
{
    public class KeyboardInput : MacroInput
    {
        public Scancodes Key { get; internal set; }

        public KeyEvents KeyEvents { get; internal set; }

        public KeyboardInput() : base((uint)InputType.Keyboard) { }

        public KeyboardInput(Scancodes key, KeyEvents keyEvents) : base((uint)InputType.Keyboard)
        {
            Key = key;
            KeyEvents = keyEvents;

            if (KeyEvents.HasFlag(KeyEvents.Scancode))
            {
                KeyEvents &= ~KeyEvents.Scancode;
            }

            if (KeyEvents.HasFlag(KeyEvents.Unicode))
            {
                KeyEvents &= ~KeyEvents.Unicode;
            }

            Input = ToInput();
        }

        public override InputUnion ToInputUnion()
        {
            return new InputUnion()
            {
                ki = new Windows.KeyboardInput()
                {
                    wVk = 0,
                    wScan = (ushort)Key,
                    dwFlags = (uint)(KeyEvents | KeyEvents.Scancode),
                    dwExtraInfo = Library.GetMessageExtraInfo()
                }
            };
        }

        public override string ToReadableInputName() => "Keyboard";

        public override string ToReadableInputInformation()
        {
            StringBuilder output = new StringBuilder(Key.ToString());
            output.Append(" key");

            if (KeyEvents == KeyEvents.KeyUp)
            {
                output.Append(" Up");
            }

            if (KeyEvents == KeyEvents.KeyDown)
            {
                output.Append(" Down");
            }
            return output.ToString();
        }

        public override void SaveAsIODictionary(IODictionary ioDictionary)
        {
            ioDictionary.Add("Key", (int)Key);
            ioDictionary.Add("KeyEvents", (int)KeyEvents);
        }

        public override MacroInput? LoadFromIODictionary(IODictionary ioDictionary)
        {
            ioDictionary.TryGet("Key", out int key);
            ioDictionary.TryGet("KeyEvents", out int keyEvents);
            return new KeyboardInput((Scancodes)key, (KeyEvents)keyEvents);
        }
    }
}
