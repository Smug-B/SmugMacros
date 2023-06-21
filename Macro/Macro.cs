using SmugBase.Saving;
using SmugMacros.Windows;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

namespace SmugMacros.Input
{
    // A 'Macro' is a container for all the inputs
    public class Macro
    {
        public string Name { get; internal set; }

        public bool Active { get; internal set; }

        public VirtualKeys ActivationKey { get; internal set; }

        public IList<MacroInput> Inputs { get; internal set; }

        public Macro() { }

        public Macro(string name, VirtualKeys activationKey)
        {
            Name = name;
            Active = false;
            ActivationKey = activationKey;
            Inputs = new List<MacroInput>();
        }

        public void Execute()
        {
            Stopwatch executionStopwatch = new Stopwatch();

            for (int i = 0; i < Inputs.Count; i++)
            {
                MacroInput macroInput = Inputs[i];
                if (macroInput == null)
                {
                    continue;
                }

                if (macroInput.Type == uint.MaxValue)
                {
                    if (macroInput is not NoInput noInput)
                    {
                        continue;
                    }

                    executionStopwatch.Restart();
                    while (executionStopwatch.ElapsedMilliseconds < noInput.DurationMS)
                    {
                        // Lu lu lu I got some apples
                    }

                    continue;
                }

                Windows.Input[] input = new Windows.Input[] { macroInput.Input };
                Library.SendInput((uint)input.Length, input, Marshal.SizeOf(typeof(Windows.Input)));
            }
        }

        public string ToJSON() => JsonSerializer.Serialize(this, typeof(Macro));

        public IODictionary ToIODictionary()
        {
            IODictionary outPut = new IODictionary();
            outPut.Add(nameof(Name), Name);
            outPut.Add(nameof(ActivationKey), (int)ActivationKey);
            outPut.Add("Input Counts", Inputs.Count);
            for (int i = 0; i < Inputs.Count; i++)
            {
                outPut.Add("Input " + i, Inputs[i].ToIODictionary());
            }
            return outPut;
        }

        public void SaveTo(string path)
        {
            using FileStream jsonStream = new FileStream(path + "/" + Name + ".json", FileMode.Create);
            jsonStream.Write(Encoding.ASCII.GetBytes(ToJSON()));
        }

        public static Macro? FromJSON(string json)
        {
            if (JsonSerializer.Deserialize(json, typeof(Macro)) is not Macro macro)
            {
                return null;
            }

            return macro;
        }

        public static Macro? FromIODictionary(IODictionary ioDictionary)
        {
            ioDictionary.TryGet("Name", out string name);
            ioDictionary.TryGet("ActivationKey", out int activationKey);
            ioDictionary.TryGet("Input Counts", out int inputCount);
            List<MacroInput> inputs = new List<MacroInput>();
            for (int i = 0; i < inputCount; i++)
            {
                ioDictionary.TryGet("Input " + i, out IODictionary input);
                inputs.Add(MacroInput.FromIODictionary(input));
            }

            Macro macro = new Macro(name, (VirtualKeys)activationKey);
            macro.Inputs = inputs;
            return macro;
        }

        public static Macro? LoadFrom(string path) => FromJSON(File.ReadAllText(path));
    }
}
