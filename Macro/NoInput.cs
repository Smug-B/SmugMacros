using SmugBase.Saving;
using SmugMacros.Windows;

namespace SmugMacros.Input
{
    public class NoInput : MacroInput
    {
        public int DurationMS { get; internal set; }

        public NoInput() : base(uint.MaxValue) { }

        public NoInput(int durationMS) : base(uint.MaxValue) => DurationMS = durationMS;

        public override InputUnion ToInputUnion() => default;

        public override string ToReadableInputName() => "Wait";

        public override string ToReadableInputInformation() => DurationMS + " ms";

        public override void SaveAsIODictionary(IODictionary ioDictionary) => ioDictionary.Add("DurationMS", DurationMS);

        public override MacroInput? LoadFromIODictionary(IODictionary ioDictionary)
        {
            ioDictionary.TryGet("DurationMS", out int durationMS);
            return new NoInput(durationMS);
        }
    }
}
