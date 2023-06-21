using SmugBase.Logging;
using SmugBase.Saving;
using SmugMacros.Input;
using SmugMacros.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyboardInput = SmugMacros.Input.KeyboardInput;

namespace SmugMacros.UI
{
    public partial class MacroCreator : Form
    {
        public MainUI MainUI { get; }

        public KeyboardInputCreator KeyboardInputCreator { get; }

        public MouseInputCreator MouseInputCreator { get; }

        public WaitInputCreator WaitInputCreator { get; }

        public Macro MacroOutput { get; private set; }

        public IList<MacroInput> MacroInputs { get; private set; }

        public int OriginalIndex { get; internal set; }

        public MacroCreator(MainUI mainUI)
        {
            MainUI = mainUI;
            KeyboardInputCreator = new KeyboardInputCreator(this);
            KeyboardInputCreator.Hide();
            MouseInputCreator = new MouseInputCreator(this);
            MouseInputCreator.Hide();
            WaitInputCreator = new WaitInputCreator(this);
            WaitInputCreator.Hide();
            MacroOutput = new Macro();
            MacroInputs = new List<MacroInput>();
            OriginalIndex = -1;
            InitializeComponent();
            PopulateKeybindBox();
            MacroListView.Sorting = SortOrder.None;
            MacroListView.CheckBoxes = false;
        }

        public void UpdateForMacro(Macro? macro)
        {
            try
            {
                if (macro == null)
                {
                    MacroOutput = new Macro();
                    MacroInputs.Clear();
                    OriginalIndex = -1;
                    NameTextbox.Text = string.Empty;
                    KeybindBox.Text = string.Empty;
                    MacroInputs.Clear();
                    return;
                }

                MacroOutput = macro;
                NameTextbox.Text = MacroOutput.Name;
                KeybindBox.Text = MacroOutput.ActivationKey.ToString();
                MacroInputs = MacroOutput.Inputs.ToList();
            }
            catch (Exception exception)
            {
                Program.Logger.Log("An error occured while parsing a Macro to the Macro Creator: " + exception.Message, LogType.Error);
            }
            finally
            {
                RefreshInputDisplay();
            }
        }

        public void RefreshInputDisplay()
        {
            MacroListView.Items.Clear();
            foreach (MacroInput macroInput in MacroInputs)
            {
                ListViewItem macroInputFormatted = new ListViewItem(new string[] { macroInput.ToReadableInputName(), macroInput.ToReadableInputInformation() }, -1);
                MacroListView.Items.Add(macroInputFormatted);
            }

            MacroListView.Refresh();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (NameTextbox.Text == string.Empty || KeybindBox.Text == string.Empty)
            {
                MessageBox.Show("Please make sure all fields are appropriately filled in!");
                return;
            }

            try
            {
                string oldSavePath = Program.MacroPath + Path.DirectorySeparatorChar + MacroOutput.Name + ".smmc";
                MacroOutput.Name = NameTextbox.Text;
                MacroOutput.ActivationKey = (VirtualKeys)Enum.Parse(typeof(VirtualKeys), KeybindBox.Text);
                MacroOutput.Inputs = MacroInputs;

                if (OriginalIndex == -1)
                {
                    MainUI.Macros.Add(MacroOutput);
                }
                else
                {
                    MainUI.Macros[OriginalIndex] = MacroOutput;
                }

                if (File.Exists(oldSavePath))
                {
                    File.Delete(oldSavePath);
                }
                MacroOutput.ToIODictionary().CompressTo(Program.MacroPath, MacroOutput.Name + ".smmc", CompressionLevel.Optimal);
            }
            catch (Exception exception)
            {
                Program.Logger.Log("An error occured while trying to save a Macro: " + exception, LogType.Error);
            }
            finally
            {
                Hide();
                MainUI.RefreshMacroList();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e) => Hide();

        private void AddKeyboardButton_Click(object sender, EventArgs e)
        {
            KeyboardInputCreator.UpdateForInput(null);
            KeyboardInputCreator.ShowDialog();
        }

        private void AddMouseInputButton_Click(object sender, EventArgs e)
        {
            MouseInputCreator.UpdateForInput(null);
            MouseInputCreator.ShowDialog();
        }

        private void AddWaitButton_Click(object sender, EventArgs e)
        {
            WaitInputCreator.UpdateForInput(null);
            WaitInputCreator.ShowDialog();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MacroListView.SelectedItems.Count == 0)
                {
                    return;
                }

                if (MacroListView.SelectedItems.Count > 1)
                {
                    MessageBox.Show("You can only edit one macro input at a time!");
                    return;
                }

                ListViewItem selectedItem = MacroListView.SelectedItems[0];
                int index = MacroListView.Items.IndexOf(selectedItem);
                MacroInput macroInput = MacroInputs[index];
                switch (macroInput.Type)
                {
                    case (uint)Windows.InputType.Mouse:
                        MouseInputCreator.UpdateForInput(macroInput as Input.MouseInput);
                        MouseInputCreator.OriginalIndex = index;
                        MouseInputCreator.ShowDialog();
                        break;

                    case (uint)Windows.InputType.Keyboard:
                        KeyboardInputCreator.UpdateForInput(macroInput as Input.KeyboardInput);
                        KeyboardInputCreator.OriginalIndex = index;
                        KeyboardInputCreator.ShowDialog();
                        break;

                    case uint.MaxValue:
                        WaitInputCreator.UpdateForInput(macroInput as Input.NoInput);
                        WaitInputCreator.OriginalIndex = index;
                        WaitInputCreator.ShowDialog();
                        break;
                }
            }
            catch (Exception exception)
            {
                Program.Logger.Log("An exception occured while trying to edit a macro input: " + exception.Message, LogType.Error);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MacroListView.SelectedItems.Count == 0)
                {
                    return;
                }

                if (MacroListView.SelectedItems.Count > 1)
                {
                    MessageBox.Show("You can only delete one macro input at a time!");
                    return;
                }

                ListViewItem selectedItem = MacroListView.SelectedItems[0];
                int index = MacroListView.Items.IndexOf(selectedItem);
                MacroInputs.RemoveAt(index);
                RefreshInputDisplay();
            }
            catch (Exception exception)
            {
                Program.Logger.Log("An exception occured while trying to delete a macro input: " + exception.Message, LogType.Error);
            }
        }

        public void PopulateKeybindBox()
        {
            for (VirtualKeys i = VirtualKeys.LeftMouse; i < VirtualKeys.ComparisonSigns; i++)
            {
                string virtualKeyName = i.ToString();
                if (int.TryParse(virtualKeyName, out int _))
                {
                    continue;
                }

                KeybindBox.Items.Add(virtualKeyName);
            }
        }
    }
}
