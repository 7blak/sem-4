namespace WinFormsApp_Calendar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            splitContainer = new SplitContainer();
            noteTextBox = new TextBox();
            monthCalendar = new MonthCalendar();
            calendarListView = new ListView();
            dateColumnHeader = new ColumnHeader();
            noteColumnHeader = new ColumnHeader();
            removeButton = new Button();
            addButton = new Button();
            notifyIcon1 = new NotifyIcon(components);
            notifyIconContextMenu = new ContextMenuStrip(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer
            // 
            splitContainer.BackColor = Color.LightSteelBlue;
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 0);
            splitContainer.Name = "splitContainer";
            splitContainer.Orientation = Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.BackColor = SystemColors.ControlLight;
            splitContainer.Panel1.Controls.Add(noteTextBox);
            splitContainer.Panel1.Controls.Add(monthCalendar);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.BackColor = SystemColors.ControlLight;
            splitContainer.Panel2.Controls.Add(calendarListView);
            splitContainer.Panel2.Controls.Add(removeButton);
            splitContainer.Panel2.Controls.Add(addButton);
            splitContainer.Size = new Size(800, 450);
            splitContainer.SplitterDistance = 266;
            splitContainer.TabIndex = 0;
            // 
            // noteTextBox
            // 
            noteTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            noteTextBox.Location = new Point(554, 3);
            noteTextBox.Multiline = true;
            noteTextBox.Name = "noteTextBox";
            noteTextBox.Size = new Size(234, 260);
            noteTextBox.TabIndex = 1;
            // 
            // monthCalendar
            // 
            monthCalendar.CalendarDimensions = new Size(2, 1);
            monthCalendar.Location = new Point(0, 3);
            monthCalendar.MaxSelectionCount = 1;
            monthCalendar.Name = "monthCalendar";
            monthCalendar.TabIndex = 0;
            // 
            // calendarListView
            // 
            calendarListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            calendarListView.Columns.AddRange(new ColumnHeader[] { dateColumnHeader, noteColumnHeader });
            calendarListView.FullRowSelect = true;
            calendarListView.Location = new Point(12, 42);
            calendarListView.Name = "calendarListView";
            calendarListView.Size = new Size(776, 126);
            calendarListView.TabIndex = 2;
            calendarListView.UseCompatibleStateImageBehavior = false;
            calendarListView.View = View.Details;
            calendarListView.SelectedIndexChanged += calendarListView_SelectedIndexChanged;
            // 
            // dateColumnHeader
            // 
            dateColumnHeader.Text = "Date";
            dateColumnHeader.Width = 120;
            // 
            // noteColumnHeader
            // 
            noteColumnHeader.Text = "Note";
            noteColumnHeader.Width = 200;
            // 
            // removeButton
            // 
            removeButton.Enabled = false;
            removeButton.Location = new Point(93, 13);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(75, 23);
            removeButton.TabIndex = 1;
            removeButton.Text = "Remove";
            removeButton.UseVisualStyleBackColor = true;
            removeButton.Click += removeButton_Click;
            // 
            // addButton
            // 
            addButton.Location = new Point(12, 13);
            addButton.Name = "addButton";
            addButton.Size = new Size(75, 23);
            addButton.TabIndex = 0;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = notifyIconContextMenu;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "Windows Forms Calendar";
            notifyIcon1.Visible = true;
            // 
            // notifyIconContextMenu
            // 
            notifyIconContextMenu.Name = "contextMenuStrip1";
            notifyIconContextMenu.Size = new Size(61, 4);
            notifyIconContextMenu.Click += notifyIconContextMenu_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel1.PerformLayout();
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer;
        private TextBox noteTextBox;
        private MonthCalendar monthCalendar;
        private ListView calendarListView;
        private Button removeButton;
        private Button addButton;
        private ColumnHeader dateColumnHeader;
        private ColumnHeader noteColumnHeader;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip notifyIconContextMenu;
    }
}
