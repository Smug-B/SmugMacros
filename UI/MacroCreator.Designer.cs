namespace SmugMacros.UI
{
    partial class MacroCreator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MacroCreator));
            AddButton = new Label();
            AddKeyboardButton = new Button();
            AddMouseInputButton = new Button();
            AddWaitButton = new Button();
            MacroListView = new ListView();
            InputType = new ColumnHeader();
            InputInfo = new ColumnHeader();
            DeleteButton = new Button();
            NameLabel = new Label();
            NameTextbox = new TextBox();
            EditButton = new Button();
            SaveButton = new Button();
            CancelButton = new Button();
            KeybindBox = new ComboBox();
            ActivationKeybindLabel = new Label();
            SuspendLayout();
            // 
            // AddButton
            // 
            AddButton.AutoSize = true;
            AddButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            AddButton.Location = new Point(12, 369);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(53, 21);
            AddButton.TabIndex = 1;
            AddButton.Text = "Add...";
            // 
            // AddKeyboardButton
            // 
            AddKeyboardButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            AddKeyboardButton.Location = new Point(12, 393);
            AddKeyboardButton.Name = "AddKeyboardButton";
            AddKeyboardButton.Size = new Size(150, 32);
            AddKeyboardButton.TabIndex = 2;
            AddKeyboardButton.Text = "Keyboard Input";
            AddKeyboardButton.UseVisualStyleBackColor = true;
            AddKeyboardButton.Click += AddKeyboardButton_Click;
            // 
            // AddMouseInputButton
            // 
            AddMouseInputButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            AddMouseInputButton.Location = new Point(168, 393);
            AddMouseInputButton.Name = "AddMouseInputButton";
            AddMouseInputButton.Size = new Size(150, 32);
            AddMouseInputButton.TabIndex = 3;
            AddMouseInputButton.Text = "Mouse Input";
            AddMouseInputButton.UseVisualStyleBackColor = true;
            AddMouseInputButton.Click += AddMouseInputButton_Click;
            // 
            // AddWaitButton
            // 
            AddWaitButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            AddWaitButton.Location = new Point(322, 393);
            AddWaitButton.Name = "AddWaitButton";
            AddWaitButton.Size = new Size(150, 32);
            AddWaitButton.TabIndex = 4;
            AddWaitButton.Text = "Wait";
            AddWaitButton.UseVisualStyleBackColor = true;
            AddWaitButton.Click += AddWaitButton_Click;
            // 
            // MacroListView
            // 
            MacroListView.AllowColumnReorder = true;
            MacroListView.CheckBoxes = true;
            MacroListView.Columns.AddRange(new ColumnHeader[] { InputType, InputInfo });
            MacroListView.FullRowSelect = true;
            MacroListView.GridLines = true;
            MacroListView.LabelEdit = true;
            MacroListView.Location = new Point(12, 79);
            MacroListView.Name = "MacroListView";
            MacroListView.Size = new Size(460, 248);
            MacroListView.Sorting = SortOrder.Ascending;
            MacroListView.TabIndex = 5;
            MacroListView.UseCompatibleStateImageBehavior = false;
            MacroListView.View = View.Details;
            // 
            // InputType
            // 
            InputType.Text = "Input Type";
            InputType.Width = 200;
            // 
            // InputInfo
            // 
            InputInfo.Text = "Input Info";
            InputInfo.Width = 256;
            // 
            // DeleteButton
            // 
            DeleteButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            DeleteButton.Location = new Point(324, 334);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(150, 32);
            DeleteButton.TabIndex = 7;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            NameLabel.Location = new Point(9, 12);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(56, 21);
            NameLabel.TabIndex = 8;
            NameLabel.Text = "Name";
            // 
            // NameTextbox
            // 
            NameTextbox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            NameTextbox.Location = new Point(71, 9);
            NameTextbox.MaxLength = 100;
            NameTextbox.Name = "NameTextbox";
            NameTextbox.Size = new Size(401, 29);
            NameTextbox.TabIndex = 9;
            // 
            // EditButton
            // 
            EditButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            EditButton.Location = new Point(12, 334);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(150, 32);
            EditButton.TabIndex = 6;
            EditButton.Text = "Edit";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            SaveButton.Location = new Point(12, 431);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(227, 50);
            SaveButton.TabIndex = 10;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            CancelButton.Location = new Point(245, 431);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(227, 50);
            CancelButton.TabIndex = 11;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // KeybindBox
            // 
            KeybindBox.DropDownStyle = ComboBoxStyle.DropDownList;
            KeybindBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            KeybindBox.FormattingEnabled = true;
            KeybindBox.Location = new Point(168, 44);
            KeybindBox.Name = "KeybindBox";
            KeybindBox.Size = new Size(304, 29);
            KeybindBox.TabIndex = 12;
            // 
            // ActivationKeybindLabel
            // 
            ActivationKeybindLabel.AutoSize = true;
            ActivationKeybindLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            ActivationKeybindLabel.Location = new Point(9, 47);
            ActivationKeybindLabel.Name = "ActivationKeybindLabel";
            ActivationKeybindLabel.Size = new Size(156, 21);
            ActivationKeybindLabel.TabIndex = 13;
            ActivationKeybindLabel.Text = "Activation Keybind";
            // 
            // MacroCreator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(486, 493);
            Controls.Add(ActivationKeybindLabel);
            Controls.Add(KeybindBox);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            Controls.Add(NameTextbox);
            Controls.Add(NameLabel);
            Controls.Add(DeleteButton);
            Controls.Add(EditButton);
            Controls.Add(MacroListView);
            Controls.Add(AddWaitButton);
            Controls.Add(AddMouseInputButton);
            Controls.Add(AddKeyboardButton);
            Controls.Add(AddButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MacroCreator";
            Text = "MacroCreator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label AddButton;
        private Button AddKeyboardButton;
        private Button AddMouseInputButton;
        private Button AddWaitButton;
        private ListView MacroListView;
        private ColumnHeader InputType;
        private ColumnHeader InputInfo;
        private Button DeleteButton;
        private Label NameLabel;
        private TextBox NameTextbox;
        private Button EditButton;
        private Button SaveButton;
        private Button CancelButton;
        private ComboBox KeybindBox;
        private Label ActivationKeybindLabel;
    }
}