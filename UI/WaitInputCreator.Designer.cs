namespace SmugMacros.UI
{
    partial class WaitInputCreator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitInputCreator));
            SaveButton = new Button();
            CancelButton = new Button();
            DurationInput = new NumericUpDown();
            InputKeyLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)DurationInput).BeginInit();
            SuspendLayout();
            // 
            // SaveButton
            // 
            SaveButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            SaveButton.Location = new Point(12, 47);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(150, 32);
            SaveButton.TabIndex = 1;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            CancelButton.Location = new Point(168, 47);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(150, 32);
            CancelButton.TabIndex = 2;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // DurationInput
            // 
            DurationInput.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            DurationInput.Location = new Point(136, 12);
            DurationInput.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            DurationInput.Name = "DurationInput";
            DurationInput.Size = new Size(182, 29);
            DurationInput.TabIndex = 0;
            // 
            // InputKeyLabel
            // 
            InputKeyLabel.AutoSize = true;
            InputKeyLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            InputKeyLabel.Location = new Point(12, 14);
            InputKeyLabel.Name = "InputKeyLabel";
            InputKeyLabel.Size = new Size(118, 21);
            InputKeyLabel.TabIndex = 7;
            InputKeyLabel.Text = "Duration (MS)";
            // 
            // WaitInputCreator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(330, 89);
            Controls.Add(InputKeyLabel);
            Controls.Add(DurationInput);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "WaitInputCreator";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Wait Input";
            ((System.ComponentModel.ISupportInitialize)DurationInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SaveButton;
        private Button CancelButton;
        private NumericUpDown DurationInput;
        private Label InputKeyLabel;
    }
}