using SmugBase.Logging;
using SmugMacros.Windows;
using KeyboardInput = SmugMacros.Input.KeyboardInput;

namespace SmugMacros.UI
{
    public partial class KeyboardInputCreator : Form
    {
        public MacroCreator ParentUI { get; }

        public KeyboardInput Output { get; private set; }

        public int OriginalIndex { get; internal set; }

        public KeyboardInputCreator(MacroCreator parentUI)
        {
            ParentUI = parentUI;
            Output = new KeyboardInput();
            OriginalIndex = -1;
            InitializeComponent();
            PopulateKeyBox();
            PopulateStateBox();
        }

        public void UpdateForInput(KeyboardInput? keyboardInput)
        {
            try
            {
                if (keyboardInput == null)
                {
                    Output = new KeyboardInput();
                    OriginalIndex = -1;
                    KeyBox.Text = string.Empty;
                    StateBox.Text = string.Empty;
                    return;
                }

                Output = keyboardInput;
                KeyBox.Text = Output.Key.ToString();
                StateBox.Text = Output.KeyEvents == KeyEvents.KeyDown ? "Key Down" : "Key Up";
            }
            catch (Exception exception)
            {
                Program.Logger.Log("An error occured while parsing a Keyboard Input to the Keyboard Input Creator: " + exception.Message, LogType.Error);
            }
        }

        private void SaveOutput()
        {
            Output.Key = (Scancodes)Enum.Parse(typeof(Scancodes), KeyBox.Text);
            Output.KeyEvents = StateBox.SelectedItem.ToString() == "Key Down" ? KeyEvents.KeyDown : KeyEvents.KeyUp;
            Output.Input = Output.ToInput();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (KeyBox.Text == string.Empty || StateBox.Text == string.Empty)
            {
                MessageBox.Show("Please make sure all fields are appropriately filled in!");
                return;
            }

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
                Program.Logger.Log("An error occured while trying to save a Keyboard Input: " + exception, LogType.Error);
            }
            finally
            {
                Hide();
                ParentUI.RefreshInputDisplay();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e) => Hide();

        public void PopulateKeyBox()
        {
            for (Scancodes i = Scancodes.Escape; i < Scancodes.NumPad_Slash; i++)
            {
                string virtualKeyName = i.ToString();
                if (int.TryParse(virtualKeyName, out int _))
                {
                    continue;
                }

                KeyBox.Items.Add(virtualKeyName);
            }
        }

        public void PopulateStateBox() => StateBox.Items.AddRange(new string[] { "Key Down", "Key Up" });
    }
}
