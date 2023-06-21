namespace SmugMacros.UI
{
    partial class MouseInputCreator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MouseInputCreator));
            MouseXLabel = new Label();
            InputLabel = new Label();
            MouseInputBox = new ComboBox();
            CancelButton = new Button();
            SaveButton = new Button();
            label1 = new Label();
            MouseXDropDown = new NumericUpDown();
            MouseYDropDown = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)MouseXDropDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MouseYDropDown).BeginInit();
            SuspendLayout();
            // 
            // MouseXLabel
            // 
            MouseXLabel.AutoSize = true;
            MouseXLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            MouseXLabel.Location = new Point(12, 43);
            MouseXLabel.Name = "MouseXLabel";
            MouseXLabel.Size = new Size(75, 21);
            MouseXLabel.TabIndex = 13;
            MouseXLabel.Text = "Mouse X";
            // 
            // InputLabel
            // 
            InputLabel.AutoSize = true;
            InputLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            InputLabel.Location = new Point(12, 9);
            InputLabel.Name = "InputLabel";
            InputLabel.Size = new Size(106, 21);
            InputLabel.TabIndex = 12;
            InputLabel.Text = "Mouse Input";
            // 
            // MouseInputBox
            // 
            MouseInputBox.DropDownStyle = ComboBoxStyle.DropDownList;
            MouseInputBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MouseInputBox.FormattingEnabled = true;
            MouseInputBox.Items.AddRange(new object[] { "Move", "Left Down", "Left Up", "Right Down", "Right Up", "Middle Down", "Middle Up", "Upper Side Down", "Upper Side Up", "Lower Side Down", "Lower Side Up" });
            MouseInputBox.Location = new Point(124, 6);
            MouseInputBox.Name = "MouseInputBox";
            MouseInputBox.Size = new Size(194, 29);
            MouseInputBox.TabIndex = 10;
            // 
            // CancelButton
            // 
            CancelButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            CancelButton.Location = new Point(168, 111);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(150, 32);
            CancelButton.TabIndex = 9;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            SaveButton.Location = new Point(12, 111);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(150, 32);
            SaveButton.TabIndex = 8;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 78);
            label1.Name = "label1";
            label1.Size = new Size(75, 21);
            label1.TabIndex = 14;
            label1.Text = "Mouse Y";
            // 
            // MouseXDropDown
            // 
            MouseXDropDown.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MouseXDropDown.Location = new Point(124, 41);
            MouseXDropDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            MouseXDropDown.Name = "MouseXDropDown";
            MouseXDropDown.Size = new Size(194, 29);
            MouseXDropDown.TabIndex = 15;
            // 
            // MouseYDropDown
            // 
            MouseYDropDown.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MouseYDropDown.Location = new Point(124, 76);
            MouseYDropDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            MouseYDropDown.Name = "MouseYDropDown";
            MouseYDropDown.Size = new Size(194, 29);
            MouseYDropDown.TabIndex = 16;
            // 
            // MouseInputCreator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(330, 155);
            Controls.Add(MouseYDropDown);
            Controls.Add(MouseXDropDown);
            Controls.Add(label1);
            Controls.Add(MouseXLabel);
            Controls.Add(InputLabel);
            Controls.Add(MouseInputBox);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            ImeMode = ImeMode.Off;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MouseInputCreator";
            Text = "Mouse Input";
            ((System.ComponentModel.ISupportInitialize)MouseXDropDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)MouseYDropDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label MouseXLabel;
        private Label InputLabel;
        private ComboBox MouseInputBox;
        private Button CancelButton;
        private Button SaveButton;
        private Label label1;
        private NumericUpDown MouseXDropDown;
        private NumericUpDown MouseYDropDown;
    }
}