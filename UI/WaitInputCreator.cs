using SmugBase.Logging;
using SmugMacros.Input;

namespace SmugMacros.UI
{
    public partial class WaitInputCreator : Form
    {
        public MacroCreator ParentUI { get; }

        public NoInput Output { get; private set; }

        public int OriginalIndex { get; internal set; }

        public WaitInputCreator(MacroCreator parentUI)
        {
            ParentUI = parentUI;
            Output = new NoInput();
            OriginalIndex = -1;
            InitializeComponent();
        }

        public void UpdateForInput(NoInput? noInput)
        {
            try
            {
                if (noInput == null)
                {
                    Output = new NoInput();
                    OriginalIndex = -1;
                    DurationInput.Text = string.Empty;
                    return;
                }

                Output = noInput;
                DurationInput.Value = Output.DurationMS;
            }
            catch (Exception exception)
            {
                Program.Logger.Log("An error occured while parsing a No Input to the Wait Input Creator: " + exception.Message, LogType.Error);
            }
        }

        public void SaveOutput() => Output.DurationMS = (int)DurationInput.Value;

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                SaveOutput();
                if (OriginalIndex == -1)
                {
                    ParentUI.MacroInputs.Add(Output);
                }
                else
                {
                    ParentUI.MacroInputs[OriginalIndex] = Output;
                }
            }
            catch (Exception exception)
            {
                Program.Logger.Log("An error occured while trying to save a Wait Input: " + exception, LogType.Error);
            }
            finally
            {
                Hide();
                ParentUI.RefreshInputDisplay();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e) => Hide();
    }
}
