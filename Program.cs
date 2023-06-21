using SmugBase.Loading;
using SmugBase.Logging;
using SmugBase.Saving;
using SmugBase.Utility;
using SmugMacros.Input;
using SmugMacros.UI;
using SmugMacros.Windows;

namespace SmugMacros
{
    public static class Program
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public static Logger Logger { get; private set; }

        public static IList<Macro> LoadedMacros { get; private set; }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public static string MacroPath { get; } = FileUtility.GetDirectory("SmugMacros", "Macros");

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logger = new Logger("Main.log", FileUtility.GetDirectory("SmugMacros", "Logs"));
            LoadingHandler.ImplementLoading(Logger);

            LoadedMacros = new List<Macro>();

            if (!Directory.Exists(MacroPath))
            {
                Logger.Log("Failed to find macros folder.");
                Directory.CreateDirectory(MacroPath);
            }
            else
            {
                string[] loadedMacros = Directory.GetFiles(MacroPath);
                Logger.Log("Found " + loadedMacros.Length + " possible macros to load.");
                foreach (string macroPath in loadedMacros)
                {
                    IODictionary macroIODictionary = IODictionary.DecompressFrom(macroPath);
                    Macro? macro = Macro.FromIODictionary(macroIODictionary);
                    if (macro == null)
                    {
                        Logger.Log("Failed to load: " + macroPath);
                        continue;
                    }

                    LoadedMacros.Add(macro);
                }
            }

            /*string active = FileUtility.GetDirectory("SmugMacros", "Active.json");
            if (File.Exists(active))
            {
                Logger.Log("Found log of active macros.");
                if (JsonSerializer.Deserialize(active, typeof(List<string>)) is not List<string> activeMacros)
                {
                    Logger.Log("Failed to deserialize log of active macros.");
                }
                else
                {
                    foreach (Macro macro in LoadedMacros)
                    {
                        if (activeMacros.Any(macroName => macro.Name == macroName))
                        {
                            Logger.Log("Recognized " + macro.Name + " as a previously active macro.");
                            ActiveMacros.Add(macro);
                        }
                    }
                }
            }*/

            Task.Run(MacroListeningLoop);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainUI());
        }

        public static void MacroListeningLoop()
        {
            VirtualKeys? lastKeyDown = null;
            while (true)
            {
                bool utilizedMacro = false;
                foreach (Macro macro in LoadedMacros.Where(macro => macro.Active))
                {
                    if (Library.GetAsyncKeyState((ushort)macro.ActivationKey) != 0 && lastKeyDown != macro.ActivationKey)
                    {
                        lastKeyDown = macro.ActivationKey;
                        macro.Execute();
                        utilizedMacro = true;
                    }
                }

                if (utilizedMacro == false)
                {
                    lastKeyDown = null;
                }

                Thread.CurrentThread.Join(10);
            }
        }
    }
}