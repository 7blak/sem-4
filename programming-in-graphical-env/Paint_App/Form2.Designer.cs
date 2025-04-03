namespace Paint
{
    partial class Form2
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            numericWidth = new NumericUpDown();
            numericHeight = new NumericUpDown();
            buttonColor = new Button();
            label4 = new Label();
            label5 = new Label();
            buttonCancel = new Button();
            buttonNew = new Button();
            ((System.ComponentModel.ISupportInitialize)numericWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericHeight).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 0;
            label1.Text = "Width:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 49);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 1;
            label2.Text = "Height:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 92);
            label3.Name = "label3";
            label3.Size = new Size(74, 15);
            label3.TabIndex = 2;
            label3.Text = "Background:";
            // 
            // numericWidth
            // 
            numericWidth.Location = new Point(122, 7);
            numericWidth.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericWidth.Name = "numericWidth";
            numericWidth.Size = new Size(120, 23);
            numericWidth.TabIndex = 3;
            numericWidth.Value = new decimal(new int[] { 800, 0, 0, 0 });
            // 
            // numericHeight
            // 
            numericHeight.Location = new Point(122, 47);
            numericHeight.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericHeight.Name = "numericHeight";
            numericHeight.Size = new Size(120, 23);
            numericHeight.TabIndex = 4;
            numericHeight.Value = new decimal(new int[] { 600, 0, 0, 0 });
            // 
            // buttonColor
            // 
            buttonColor.FlatStyle = FlatStyle.Popup;
            buttonColor.Location = new Point(122, 88);
            buttonColor.Name = "buttonColor";
            buttonColor.Size = new Size(120, 23);
            buttonColor.TabIndex = 5;
            buttonColor.UseVisualStyleBackColor = true;
            buttonColor.Click += buttonColor_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(248, 9);
            label4.Name = "label4";
            label4.Size = new Size(20, 15);
            label4.TabIndex = 6;
            label4.Text = "px";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(248, 49);
            label5.Name = "label5";
            label5.Size = new Size(20, 15);
            label5.TabIndex = 7;
            label5.Text = "px";
            // 
            // buttonCancel
            // 
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(193, 144);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 8;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonNew
            // 
            buttonNew.DialogResult = DialogResult.OK;
            buttonNew.Location = new Point(112, 144);
            buttonNew.Name = "buttonNew";
            buttonNew.Size = new Size(75, 23);
            buttonNew.TabIndex = 9;
            buttonNew.Text = "New";
            buttonNew.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(279, 180);
            Controls.Add(buttonNew);
            Controls.Add(buttonCancel);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(buttonColor);
            Controls.Add(numericHeight);
            Controls.Add(numericWidth);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form2";
            Text = "New image...";
            ((System.ComponentModel.ISupportInitialize)numericWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericHeight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private NumericUpDown numericWidth;
        private NumericUpDown numericHeight;
        private Button buttonColor;
        private Label label4;
        private Label label5;
        private Button buttonCancel;
        private Button buttonNew;
    }
}