using SmugBase.Saving;
using SmugMacros.Windows;

namespace SmugMacros.Input
{
    public abstract class MacroInput
    {
        public uint Type;

        public Windows.Input Input { get; internal set; }

        public MacroInput(uint type)
        {
            Type = type;
        }

        public virtual Windows.Input ToInput()
        {
            return new Windows.Input()
            {
                type = Type,
                u = ToInputUnion()
            };
        }

        public abstract InputUnion ToInputUnion();

        public abstract string ToReadableInputName();

        public abstract string ToReadableInputInformation();

        public virtual void SaveAsIODictionary(IODictionary ioDictionary) { }

        public IODictionary ToIODictionary()
        {
            IODictionary ioDictionary = new IODictionary();
            ioDictionary.Add("Type", Type);
            SaveAsIODictionary(ioDictionary);
            return ioDictionary;
        }

        public virtual MacroInput? LoadFromIODictionary(IODictionary ioDictionary) => null;

        public static MacroInput? FromIODictionary(IODictionary ioDictionary)
        {
            MacroInput? outPut = null;
            ioDictionary.TryGet("Type", out uint type);
            switch (type)
            {
                case (uint)InputType.Mouse:
                    outPut = new MouseInput().LoadFromIODictionary(ioDictionary);
                    break;

                case (uint)InputType.Keyboard:
                    outPut = new KeyboardInput().LoadFromIODictionary(ioDictionary);
                    break;

                case uint.MaxValue:
                    outPut = new NoInput().LoadFromIODictionary(ioDictionary);
                    break;
            }
            return outPut;
        }
    }
}
