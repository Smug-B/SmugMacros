using SmugBase.Logging;
using SmugMacros.Input;

namespace SmugMacros.UI
{
    public partial class MainUI : Form
    {
        public MacroCreator MacroCreator { get; }

        public IList<Macro> Macros => Program.LoadedMacros;

        public bool Initialized { get; }

        public MainUI()
        {
            Initialized = false;
            MacroCreator = new MacroCreator(this);
            MacroCreator.Hide();
            InitializeComponent();
            RefreshMacroList(true);
            MacroListView.Sorting = SortOrder.None;
            MacroListView.ItemChecked += MacroListView_ItemChecked;
            Initialized = true;
        }

        protected override void OnClosed(EventArgs e) => Environment.Exit(0);

        private void MacroListView_ItemChecked(object? sender, ItemCheckedEventArgs e)
        {
            if (!Initialized)
            {
                return;
            }

            int index = MacroListView.Items.IndexOf(e.Item);
            Macro macro = Macros[index];
            macro.Active = e.Item.Checked;
        }

        public void RefreshMacroList(bool initialize = false)
        {
            MacroListView.Items.Clear();
            foreach (Macro macro in Macros)
            {
                ListViewItem macroInputFormatted = new ListViewItem(new string[] { macro.Name, macro.ActivationKey.ToString() }, -1);
                if (initialize)
                {
                    macroInputFormatted.Checked = false;
                }
                MacroListView.Items.Add(macroInputFormatted);
            }

            MacroListView.Refresh();
        }

        private void AddNewButton_Click(object sender, EventArgs e)
        {
            MacroCreator.UpdateForMacro(null);
            MacroCreator.ShowDialog();
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
                    MessageBox.Show("You can only edit one macro at a time!");
                    return;
                }

                ListViewItem selectedItem = MacroListView.SelectedItems[0];
                int index = MacroListView.Items.IndexOf(selectedItem);
                Macro macro = Macros[index];
                if (macro.Active)
                {
                    MessageBox.Show("You can only edit inactive macros!");
                    return;
                }

                MacroCreator.UpdateForMacro(macro);
                MacroCreator.OriginalIndex = index;
                MacroCreator.ShowDialog();
            }
            catch (Exception exception)
            {
                Program.Logger.Log("An exception occured while trying to edit a macro: " + exception.Message, LogType.Error);
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
                    MessageBox.Show("You can only edit one macro at a time!");
                    return;
                }

                ListViewItem selectedItem = MacroListView.SelectedItems[0];
                int index = MacroListView.Items.IndexOf(selectedItem);
                Macro macro = Macros[index];
                string filePath = Program.MacroPath + Path.DirectorySeparatorChar + macro.Name + ".smmc";
                Macros.RemoveAt(index);

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            catch (Exception exception)
            {
                Program.Logger.Log("An exception occured while trying to edit a macro: " + exception.Message, LogType.Error);
            }
            finally
            {
                RefreshMacroList();
            }
        }
    }
}
