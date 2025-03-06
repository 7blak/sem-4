namespace WinFormsApp_Tutorial
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
            components = new System.ComponentModel.Container();
            nameLabel = new Label();
            goButton = new Button();
            nameTextBox = new TextBox();
            nameErrorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)nameErrorProvider).BeginInit();
            SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(12, 14);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(67, 15);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Your name:";
            // 
            // goButton
            // 
            goButton.Location = new Point(12, 75);
            goButton.Name = "goButton";
            goButton.Size = new Size(75, 23);
            goButton.TabIndex = 1;
            goButton.Text = "OK";
            goButton.UseVisualStyleBackColor = true;
            goButton.Click += goButton_Click;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(12, 32);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(100, 23);
            nameTextBox.TabIndex = 2;
            nameTextBox.Validating += nameTextBox_Validating;
            // 
            // nameErrorProvider
            // 
            nameErrorProvider.ContainerControl = this;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.Disable;
            ClientSize = new Size(184, 161);
            Controls.Add(nameTextBox);
            Controls.Add(goButton);
            Controls.Add(nameLabel);
            Name = "Form1";
            Text = "Main Form";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)nameErrorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nameLabel;
        private Button goButton;
        private TextBox nameTextBox;
        private ErrorProvider nameErrorProvider;
    }
}
