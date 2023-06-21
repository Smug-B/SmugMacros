namespace SmugMacros.UI
{
    partial class MainUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUI));
            MacrosLabel = new Label();
            MacroListView = new ListView();
            Name = new ColumnHeader();
            Keybind = new ColumnHeader();
            AddNewButton = new Button();
            EditButton = new Button();
            DeleteButton = new Button();
            SuspendLayout();
            // 
            // MacrosLabel
            // 
            MacrosLabel.AutoSize = true;
            MacrosLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            MacrosLabel.Location = new Point(12, 9);
            MacrosLabel.Name = "MacrosLabel";
            MacrosLabel.Size = new Size(65, 21);
            MacrosLabel.TabIndex = 0;
            MacrosLabel.Text = "Macros";
            // 
            // MacroListView
            // 
            MacroListView.AllowColumnReorder = true;
            MacroListView.CheckBoxes = true;
            MacroListView.Columns.AddRange(new ColumnHeader[] { Name, Keybind });
            MacroListView.FullRowSelect = true;
            MacroListView.GridLines = true;
            MacroListView.LabelEdit = true;
            MacroListView.Location = new Point(12, 33);
            MacroListView.Name = "MacroListView";
            MacroListView.Size = new Size(460, 340);
            MacroListView.Sorting = SortOrder.Ascending;
            MacroListView.TabIndex = 0;
            MacroListView.UseCompatibleStateImageBehavior = false;
            MacroListView.View = View.Details;
            // 
            // Name
            // 
            Name.Text = "Name";
            Name.Width = 340;
            // 
            // Keybind
            // 
            Keybind.Text = "Keybind";
            Keybind.Width = 116;
            // 
            // AddNewButton
            // 
            AddNewButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            AddNewButton.Location = new Point(12, 382);
            AddNewButton.Name = "AddNewButton";
            AddNewButton.Size = new Size(150, 60);
            AddNewButton.TabIndex = 3;
            AddNewButton.Text = "Add New";
            AddNewButton.UseVisualStyleBackColor = true;
            AddNewButton.Click += AddNewButton_Click;
            // 
            // EditButton
            // 
            EditButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            EditButton.Location = new Point(168, 382);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(150, 60);
            EditButton.TabIndex = 4;
            EditButton.Text = "Edit";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            DeleteButton.Location = new Point(324, 382);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(150, 60);
            DeleteButton.TabIndex = 5;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // MainUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 450);
            Controls.Add(AddNewButton);
            Controls.Add(DeleteButton);
            Controls.Add(EditButton);
            Controls.Add(MacroListView);
            Controls.Add(MacrosLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Text = "Smug Macros";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label MacrosLabel;
        private RichTextBox richTextBox1;
        private ListView MacroListView;
        private ColumnHeader Name;
        private ColumnHeader Keybind;
        private Button AddNewButton;
        private Button EditButton;
        private Button DeleteButton;
    }
}