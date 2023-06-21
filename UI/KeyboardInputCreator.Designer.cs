namespace SmugMacros.UI
{
    partial class KeyboardInputCreator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyboardInputCreator));
            SaveButton = new Button();
            CancelButton = new Button();
            KeyBox = new ComboBox();
            StateBox = new ComboBox();
            InputKeyLabel = new Label();
            InputStateLabel = new Label();
            SuspendLayout();
            // 
            // SaveButton
            // 
            SaveButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            SaveButton.Location = new Point(12, 82);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(150, 32);
            SaveButton.TabIndex = 2;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            CancelButton.Location = new Point(168, 82);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(150, 32);
            CancelButton.TabIndex = 3;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // KeyBox
            // 
            KeyBox.DropDownStyle = ComboBoxStyle.DropDownList;
            KeyBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            KeyBox.FormattingEnabled = true;
            KeyBox.Location = new Point(72, 12);
            KeyBox.Name = "KeyBox";
            KeyBox.Size = new Size(246, 29);
            KeyBox.TabIndex = 4;
            // 
            // StateBox
            // 
            StateBox.DropDownStyle = ComboBoxStyle.DropDownList;
            StateBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            StateBox.FormattingEnabled = true;
            StateBox.Location = new Point(72, 47);
            StateBox.Name = "StateBox";
            StateBox.Size = new Size(246, 29);
            StateBox.TabIndex = 5;
            // 
            // InputKeyLabel
            // 
            InputKeyLabel.AutoSize = true;
            InputKeyLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            InputKeyLabel.Location = new Point(12, 15);
            InputKeyLabel.Name = "InputKeyLabel";
            InputKeyLabel.Size = new Size(38, 21);
            InputKeyLabel.TabIndex = 6;
            InputKeyLabel.Text = "Key";
            // 
            // InputStateLabel
            // 
            InputStateLabel.AutoSize = true;
            InputStateLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            InputStateLabel.Location = new Point(12, 50);
            InputStateLabel.Name = "InputStateLabel";
            InputStateLabel.Size = new Size(49, 21);
            InputStateLabel.TabIndex = 7;
            InputStateLabel.Text = "State";
            // 
            // KeyboardInputCreator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(330, 125);
            Controls.Add(InputStateLabel);
            Controls.Add(InputKeyLabel);
            Controls.Add(StateBox);
            Controls.Add(KeyBox);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "KeyboardInputCreator";
            Text = "Keyboard Input";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SaveButton;
        private Button CancelButton;
        private ComboBox KeyBox;
        private ComboBox StateBox;
        private Label InputKeyLabel;
        private Label InputStateLabel;
    }
}