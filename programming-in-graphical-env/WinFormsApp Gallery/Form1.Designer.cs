namespace WinFormsApp_Gallery
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            galleryLayoutPanel = new TableLayoutPanel();
            imageButton = new Button();
            colorButton = new Button();
            label1 = new Label();
            label2 = new Label();
            galleryLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // galleryLayoutPanel
            // 
            galleryLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            galleryLayoutPanel.ColumnCount = 2;
            galleryLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66.6666641F));
            galleryLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            galleryLayoutPanel.Controls.Add(imageButton, 1, 0);
            galleryLayoutPanel.Controls.Add(colorButton, 1, 1);
            galleryLayoutPanel.Controls.Add(label1, 0, 1);
            galleryLayoutPanel.Controls.Add(label2, 0, 0);
            galleryLayoutPanel.Location = new Point(12, 12);
            galleryLayoutPanel.Name = "galleryLayoutPanel";
            galleryLayoutPanel.RowCount = 2;
            galleryLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 24F));
            galleryLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 76F));
            galleryLayoutPanel.Size = new Size(760, 437);
            galleryLayoutPanel.TabIndex = 0;
            // 
            // imageButton
            // 
            imageButton.Dock = DockStyle.Fill;
            imageButton.Location = new Point(509, 3);
            imageButton.Name = "imageButton";
            imageButton.Size = new Size(248, 98);
            imageButton.TabIndex = 0;
            imageButton.Text = "Choose Image";
            imageButton.UseVisualStyleBackColor = true;
            imageButton.Click += imageButton_Click;
            // 
            // colorButton
            // 
            colorButton.Dock = DockStyle.Fill;
            colorButton.Location = new Point(509, 107);
            colorButton.Name = "colorButton";
            colorButton.Size = new Size(248, 327);
            colorButton.TabIndex = 1;
            colorButton.Text = "Choose Color";
            colorButton.UseVisualStyleBackColor = true;
            colorButton.Click += colorButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 104);
            label1.Name = "label1";
            label1.Size = new Size(500, 333);
            label1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(500, 104);
            label2.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(galleryLayoutPanel);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            galleryLayoutPanel.ResumeLayout(false);
            galleryLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel galleryLayoutPanel;
        private Button imageButton;
        private Button colorButton;
        private Label label1;
        private Label label2;
    }
}
