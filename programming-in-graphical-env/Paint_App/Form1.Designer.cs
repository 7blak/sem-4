namespace Paint
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
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            printToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripSeparator3 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            cutToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            selectAllToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            zoomToolStripMenuItem = new ToolStripMenuItem();
            zoomOutToolStripMenuItem = new ToolStripMenuItem();
            zoomInToolStripMenuItem = new ToolStripMenuItem();
            resetZoomToolStripMenuItem = new ToolStripMenuItem();
            imageToolStripMenuItem = new ToolStripMenuItem();
            colorsToolStripMenuItem = new ToolStripMenuItem();
            ediToolStripMenuItem = new ToolStripMenuItem();
            invertColorsToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            statusLabelPos = new ToolStripStatusLabel();
            statusLabelSize = new ToolStripStatusLabel();
            statusLabelZoom = new ToolStripStatusLabel();
            panel1 = new Panel();
            Canvas = new PictureBox();
            splitContainer1 = new SplitContainer();
            buttonLine = new Button();
            buttonSelect = new Button();
            buttonPen = new Button();
            splitContainer2 = new SplitContainer();
            panel29 = new Panel();
            panel30 = new Panel();
            panel36 = new Panel();
            panel37 = new Panel();
            panel31 = new Panel();
            panel32 = new Panel();
            panel38 = new Panel();
            panel39 = new Panel();
            panel28 = new Panel();
            panel27 = new Panel();
            panel40 = new Panel();
            panel41 = new Panel();
            panel26 = new Panel();
            panel25 = new Panel();
            panel42 = new Panel();
            panel43 = new Panel();
            panel24 = new Panel();
            panel23 = new Panel();
            panel44 = new Panel();
            panel45 = new Panel();
            panel22 = new Panel();
            panel21 = new Panel();
            panel46 = new Panel();
            panel33 = new Panel();
            panel20 = new Panel();
            panel19 = new Panel();
            panel47 = new Panel();
            panel48 = new Panel();
            panel18 = new Panel();
            panel17 = new Panel();
            panel49 = new Panel();
            panel50 = new Panel();
            panel16 = new Panel();
            panel15 = new Panel();
            panel14 = new Panel();
            panel13 = new Panel();
            panel53 = new Panel();
            panel54 = new Panel();
            panel12 = new Panel();
            panel11 = new Panel();
            panel55 = new Panel();
            panel56 = new Panel();
            panel10 = new Panel();
            panel9 = new Panel();
            panel57 = new Panel();
            panel58 = new Panel();
            panel8 = new Panel();
            panel7 = new Panel();
            panel59 = new Panel();
            panel60 = new Panel();
            panel6 = new Panel();
            panel5 = new Panel();
            panel61 = new Panel();
            panel62 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel2 = new Panel();
            panel64 = new Panel();
            panelCurrentColor = new Panel();
            panel66 = new Panel();
            panelSecondaryColor = new Panel();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Canvas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            panel29.SuspendLayout();
            panel36.SuspendLayout();
            panel31.SuspendLayout();
            panel38.SuspendLayout();
            panel28.SuspendLayout();
            panel40.SuspendLayout();
            panel26.SuspendLayout();
            panel42.SuspendLayout();
            panel24.SuspendLayout();
            panel44.SuspendLayout();
            panel22.SuspendLayout();
            panel46.SuspendLayout();
            panel20.SuspendLayout();
            panel47.SuspendLayout();
            panel18.SuspendLayout();
            panel49.SuspendLayout();
            panel16.SuspendLayout();
            panel14.SuspendLayout();
            panel53.SuspendLayout();
            panel12.SuspendLayout();
            panel55.SuspendLayout();
            panel10.SuspendLayout();
            panel57.SuspendLayout();
            panel8.SuspendLayout();
            panel59.SuspendLayout();
            panel6.SuspendLayout();
            panel61.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel64.SuspendLayout();
            panel66.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, viewToolStripMenuItem, imageToolStripMenuItem, colorsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(984, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, loadToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, toolStripSeparator1, printToolStripMenuItem, toolStripSeparator2, toolStripSeparator3, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            fileToolStripMenuItem.DropDownOpening += fileToolStripMenuItem_DropDownOpening;
            fileToolStripMenuItem.DropDownItemClicked += fileToolStripMenuItem_DropDownOpening;
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+N";
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newToolStripMenuItem.Size = new Size(195, 22);
            newToolStripMenuItem.Text = "New...";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+O";
            loadToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            loadToolStripMenuItem.Size = new Size(195, 22);
            loadToolStripMenuItem.Text = "Open...";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+S";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(195, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+S";
            saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            saveAsToolStripMenuItem.Size = new Size(195, 22);
            saveAsToolStripMenuItem.Text = "Save As...";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(192, 6);
            // 
            // printToolStripMenuItem
            // 
            printToolStripMenuItem.Name = "printToolStripMenuItem";
            printToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+P";
            printToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.P;
            printToolStripMenuItem.Size = new Size(195, 22);
            printToolStripMenuItem.Text = "Print";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(192, 6);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(192, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeyDisplayString = "Alt+F4";
            exitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            exitToolStripMenuItem.Size = new Size(195, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, selectAllToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+X";
            cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            cutToolStripMenuItem.Size = new Size(164, 22);
            cutToolStripMenuItem.Text = "Cut";
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C";
            copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            copyToolStripMenuItem.Size = new Size(164, 22);
            copyToolStripMenuItem.Text = "Copy";
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+V";
            pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            pasteToolStripMenuItem.Size = new Size(164, 22);
            pasteToolStripMenuItem.Text = "Paste";
            // 
            // selectAllToolStripMenuItem
            // 
            selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            selectAllToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+A";
            selectAllToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            selectAllToolStripMenuItem.Size = new Size(164, 22);
            selectAllToolStripMenuItem.Text = "Select All";
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { zoomToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(44, 20);
            viewToolStripMenuItem.Text = "View";
            // 
            // zoomToolStripMenuItem
            // 
            zoomToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { zoomOutToolStripMenuItem, zoomInToolStripMenuItem, resetZoomToolStripMenuItem });
            zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            zoomToolStripMenuItem.Size = new Size(106, 22);
            zoomToolStripMenuItem.Text = "Zoom";
            // 
            // zoomOutToolStripMenuItem
            // 
            zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            zoomOutToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl -";
            zoomOutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.OemMinus;
            zoomOutToolStripMenuItem.Size = new Size(177, 22);
            zoomOutToolStripMenuItem.Text = "Zoom Out";
            zoomOutToolStripMenuItem.Click += zoomInToolStripMenuItem_Click;
            // 
            // zoomInToolStripMenuItem
            // 
            zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            zoomInToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl +";
            zoomInToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Oemplus;
            zoomInToolStripMenuItem.Size = new Size(177, 22);
            zoomInToolStripMenuItem.Text = "Zoom In";
            zoomInToolStripMenuItem.Click += zoomOutToolStripMenuItem_Click;
            // 
            // resetZoomToolStripMenuItem
            // 
            resetZoomToolStripMenuItem.Name = "resetZoomToolStripMenuItem";
            resetZoomToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+0";
            resetZoomToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D0;
            resetZoomToolStripMenuItem.Size = new Size(177, 22);
            resetZoomToolStripMenuItem.Text = "Reset Zoom";
            // 
            // imageToolStripMenuItem
            // 
            imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            imageToolStripMenuItem.Size = new Size(52, 20);
            imageToolStripMenuItem.Text = "Image";
            // 
            // colorsToolStripMenuItem
            // 
            colorsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ediToolStripMenuItem, invertColorsToolStripMenuItem });
            colorsToolStripMenuItem.Name = "colorsToolStripMenuItem";
            colorsToolStripMenuItem.Size = new Size(53, 20);
            colorsToolStripMenuItem.Text = "Colors";
            // 
            // ediToolStripMenuItem
            // 
            ediToolStripMenuItem.Name = "ediToolStripMenuItem";
            ediToolStripMenuItem.Size = new Size(178, 22);
            ediToolStripMenuItem.Text = "Edit Colors...";
            ediToolStripMenuItem.Click += ediToolStripMenuItem_Click;
            // 
            // invertColorsToolStripMenuItem
            // 
            invertColorsToolStripMenuItem.Name = "invertColorsToolStripMenuItem";
            invertColorsToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+I";
            invertColorsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.I;
            invertColorsToolStripMenuItem.Size = new Size(178, 22);
            invertColorsToolStripMenuItem.Text = "Invert Colors";
            invertColorsToolStripMenuItem.Click += invertColorsToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.ShortcutKeyDisplayString = "F12";
            toolStripMenuItem1.ShortcutKeys = Keys.F12;
            toolStripMenuItem1.Size = new Size(141, 22);
            toolStripMenuItem1.Text = "About...";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabelPos, statusLabelSize, statusLabelZoom });
            statusStrip1.Location = new Point(0, 739);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(984, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusLabelPos
            // 
            statusLabelPos.BackColor = Color.Transparent;
            statusLabelPos.Name = "statusLabelPos";
            statusLabelPos.Size = new Size(0, 17);
            // 
            // statusLabelSize
            // 
            statusLabelSize.BackColor = Color.Transparent;
            statusLabelSize.Name = "statusLabelSize";
            statusLabelSize.Size = new Size(934, 17);
            statusLabelSize.Spring = true;
            statusLabelSize.Text = "0, 0 px";
            // 
            // statusLabelZoom
            // 
            statusLabelZoom.BackColor = Color.Transparent;
            statusLabelZoom.Name = "statusLabelZoom";
            statusLabelZoom.Size = new Size(35, 17);
            statusLabelZoom.Text = "100%";
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.AutoScrollMargin = new Size(5, 5);
            panel1.BackColor = SystemColors.ControlDarkDark;
            panel1.Controls.Add(Canvas);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(882, 640);
            panel1.TabIndex = 5;
            // 
            // Canvas
            // 
            Canvas.BackColor = SystemColors.MenuHighlight;
            Canvas.Location = new Point(5, 5);
            Canvas.Margin = new Padding(5);
            Canvas.Name = "Canvas";
            Canvas.Size = new Size(800, 600);
            Canvas.TabIndex = 2;
            Canvas.TabStop = false;
            Canvas.MouseDown += Canvas_MouseDown;
            Canvas.MouseLeave += Canvas_MouseLeave;
            Canvas.MouseMove += Canvas_MouseMove;
            Canvas.MouseUp += Canvas_MouseUp;
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = SystemColors.Control;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = SystemColors.Control;
            splitContainer1.Panel1.Controls.Add(buttonLine);
            splitContainer1.Panel1.Controls.Add(buttonSelect);
            splitContainer1.Panel1.Controls.Add(buttonPen);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(984, 715);
            splitContainer1.SplitterDistance = 98;
            splitContainer1.TabIndex = 6;
            // 
            // buttonLine
            // 
            buttonLine.Location = new Point(12, 80);
            buttonLine.Name = "buttonLine";
            buttonLine.Size = new Size(75, 23);
            buttonLine.TabIndex = 2;
            buttonLine.Text = "Line";
            buttonLine.UseVisualStyleBackColor = true;
            // 
            // buttonSelect
            // 
            buttonSelect.Location = new Point(12, 51);
            buttonSelect.Name = "buttonSelect";
            buttonSelect.Size = new Size(75, 23);
            buttonSelect.TabIndex = 1;
            buttonSelect.Text = "Select";
            buttonSelect.UseVisualStyleBackColor = true;
            // 
            // buttonPen
            // 
            buttonPen.Location = new Point(12, 22);
            buttonPen.Name = "buttonPen";
            buttonPen.Size = new Size(75, 23);
            buttonPen.TabIndex = 0;
            buttonPen.Text = "Pen";
            buttonPen.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.FixedPanel = FixedPanel.Panel1;
            splitContainer2.IsSplitterFixed = true;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.BackColor = SystemColors.Control;
            splitContainer2.Panel1.Controls.Add(panel29);
            splitContainer2.Panel1.Controls.Add(panel36);
            splitContainer2.Panel1.Controls.Add(panel31);
            splitContainer2.Panel1.Controls.Add(panel38);
            splitContainer2.Panel1.Controls.Add(panel28);
            splitContainer2.Panel1.Controls.Add(panel40);
            splitContainer2.Panel1.Controls.Add(panel26);
            splitContainer2.Panel1.Controls.Add(panel42);
            splitContainer2.Panel1.Controls.Add(panel24);
            splitContainer2.Panel1.Controls.Add(panel44);
            splitContainer2.Panel1.Controls.Add(panel22);
            splitContainer2.Panel1.Controls.Add(panel46);
            splitContainer2.Panel1.Controls.Add(panel20);
            splitContainer2.Panel1.Controls.Add(panel47);
            splitContainer2.Panel1.Controls.Add(panel18);
            splitContainer2.Panel1.Controls.Add(panel49);
            splitContainer2.Panel1.Controls.Add(panel16);
            splitContainer2.Panel1.Controls.Add(panel14);
            splitContainer2.Panel1.Controls.Add(panel53);
            splitContainer2.Panel1.Controls.Add(panel12);
            splitContainer2.Panel1.Controls.Add(panel55);
            splitContainer2.Panel1.Controls.Add(panel10);
            splitContainer2.Panel1.Controls.Add(panel57);
            splitContainer2.Panel1.Controls.Add(panel8);
            splitContainer2.Panel1.Controls.Add(panel59);
            splitContainer2.Panel1.Controls.Add(panel6);
            splitContainer2.Panel1.Controls.Add(panel61);
            splitContainer2.Panel1.Controls.Add(panel3);
            splitContainer2.Panel1.Controls.Add(panel2);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(panel1);
            splitContainer2.Size = new Size(882, 715);
            splitContainer2.SplitterDistance = 71;
            splitContainer2.TabIndex = 0;
            // 
            // panel29
            // 
            panel29.BorderStyle = BorderStyle.Fixed3D;
            panel29.Controls.Add(panel30);
            panel29.Location = new Point(300, 40);
            panel29.Margin = new Padding(1);
            panel29.Name = "panel29";
            panel29.Size = new Size(30, 30);
            panel29.TabIndex = 16;
            // 
            // panel30
            // 
            panel30.BackColor = Color.FromArgb(255, 242, 0);
            panel30.Location = new Point(3, 3);
            panel30.Name = "panel30";
            panel30.Size = new Size(20, 20);
            panel30.TabIndex = 0;
            panel30.MouseClick += Panel_SelectColor;
            panel30.MouseDoubleClick += Panel_Paint;
            // 
            // panel36
            // 
            panel36.BorderStyle = BorderStyle.Fixed3D;
            panel36.Controls.Add(panel37);
            panel36.Location = new Point(492, 40);
            panel36.Margin = new Padding(1);
            panel36.Name = "panel36";
            panel36.Size = new Size(30, 30);
            panel36.TabIndex = 9;
            // 
            // panel37
            // 
            panel37.BackColor = Color.FromArgb(111, 49, 137);
            panel37.Location = new Point(3, 3);
            panel37.Name = "panel37";
            panel37.Size = new Size(20, 20);
            panel37.TabIndex = 0;
            panel37.MouseClick += Panel_SelectColor;
            panel37.MouseDoubleClick += Panel_Paint;
            // 
            // panel31
            // 
            panel31.BorderStyle = BorderStyle.Fixed3D;
            panel31.Controls.Add(panel32);
            panel31.Location = new Point(300, 3);
            panel31.Margin = new Padding(1);
            panel31.Name = "panel31";
            panel31.Size = new Size(30, 30);
            panel31.TabIndex = 15;
            // 
            // panel32
            // 
            panel32.BackColor = Color.FromArgb(255, 242, 0);
            panel32.Location = new Point(3, 3);
            panel32.Name = "panel32";
            panel32.Size = new Size(20, 20);
            panel32.TabIndex = 0;
            panel32.MouseClick += Panel_SelectColor;
            panel32.MouseDoubleClick += Panel_Paint;
            // 
            // panel38
            // 
            panel38.BorderStyle = BorderStyle.Fixed3D;
            panel38.Controls.Add(panel39);
            panel38.Location = new Point(460, 40);
            panel38.Margin = new Padding(1);
            panel38.Name = "panel38";
            panel38.Size = new Size(30, 30);
            panel38.TabIndex = 21;
            // 
            // panel39
            // 
            panel39.BackColor = Color.FromArgb(47, 54, 153);
            panel39.Location = new Point(3, 3);
            panel39.Name = "panel39";
            panel39.Size = new Size(20, 20);
            panel39.TabIndex = 0;
            panel39.MouseClick += Panel_SelectColor;
            panel39.MouseDoubleClick += Panel_Paint;
            // 
            // panel28
            // 
            panel28.BorderStyle = BorderStyle.Fixed3D;
            panel28.Controls.Add(panel27);
            panel28.Location = new Point(492, 3);
            panel28.Margin = new Padding(1);
            panel28.Name = "panel28";
            panel28.Size = new Size(30, 30);
            panel28.TabIndex = 2;
            // 
            // panel27
            // 
            panel27.BackColor = Color.FromArgb(111, 49, 137);
            panel27.Location = new Point(3, 3);
            panel27.Name = "panel27";
            panel27.Size = new Size(20, 20);
            panel27.TabIndex = 0;
            panel27.MouseClick += Panel_SelectColor;
            panel27.MouseDoubleClick += Panel_Paint;
            // 
            // panel40
            // 
            panel40.BorderStyle = BorderStyle.Fixed3D;
            panel40.Controls.Add(panel41);
            panel40.Location = new Point(428, 40);
            panel40.Margin = new Padding(1);
            panel40.Name = "panel40";
            panel40.Size = new Size(30, 30);
            panel40.TabIndex = 10;
            // 
            // panel41
            // 
            panel41.BackColor = Color.FromArgb(77, 109, 243);
            panel41.Location = new Point(3, 3);
            panel41.Name = "panel41";
            panel41.Size = new Size(20, 20);
            panel41.TabIndex = 0;
            panel41.MouseClick += Panel_SelectColor;
            panel41.MouseDoubleClick += Panel_Paint;
            // 
            // panel26
            // 
            panel26.BorderStyle = BorderStyle.Fixed3D;
            panel26.Controls.Add(panel25);
            panel26.Location = new Point(460, 3);
            panel26.Margin = new Padding(1);
            panel26.Name = "panel26";
            panel26.Size = new Size(30, 30);
            panel26.TabIndex = 3;
            // 
            // panel25
            // 
            panel25.BackColor = Color.FromArgb(47, 54, 153);
            panel25.Location = new Point(3, 3);
            panel25.Name = "panel25";
            panel25.Size = new Size(20, 20);
            panel25.TabIndex = 0;
            panel25.MouseClick += Panel_SelectColor;
            panel25.MouseDoubleClick += Panel_Paint;
            // 
            // panel42
            // 
            panel42.BorderStyle = BorderStyle.Fixed3D;
            panel42.Controls.Add(panel43);
            panel42.Location = new Point(396, 40);
            panel42.Margin = new Padding(1);
            panel42.Name = "panel42";
            panel42.Size = new Size(30, 30);
            panel42.TabIndex = 11;
            // 
            // panel43
            // 
            panel43.BackColor = Color.FromArgb(0, 183, 239);
            panel43.Location = new Point(3, 3);
            panel43.Name = "panel43";
            panel43.Size = new Size(20, 20);
            panel43.TabIndex = 0;
            panel43.MouseClick += Panel_SelectColor;
            panel43.MouseDoubleClick += Panel_Paint;
            // 
            // panel24
            // 
            panel24.BorderStyle = BorderStyle.Fixed3D;
            panel24.Controls.Add(panel23);
            panel24.Location = new Point(428, 3);
            panel24.Margin = new Padding(1);
            panel24.Name = "panel24";
            panel24.Size = new Size(30, 30);
            panel24.TabIndex = 2;
            // 
            // panel23
            // 
            panel23.BackColor = Color.FromArgb(77, 109, 243);
            panel23.Location = new Point(3, 3);
            panel23.Name = "panel23";
            panel23.Size = new Size(20, 20);
            panel23.TabIndex = 0;
            panel23.MouseClick += Panel_SelectColor;
            panel23.MouseDoubleClick += Panel_Paint;
            // 
            // panel44
            // 
            panel44.BorderStyle = BorderStyle.Fixed3D;
            panel44.Controls.Add(panel45);
            panel44.Location = new Point(364, 40);
            panel44.Margin = new Padding(1);
            panel44.Name = "panel44";
            panel44.Size = new Size(30, 30);
            panel44.TabIndex = 12;
            // 
            // panel45
            // 
            panel45.BackColor = Color.FromArgb(0, 192, 0);
            panel45.Location = new Point(3, 3);
            panel45.Name = "panel45";
            panel45.Size = new Size(20, 20);
            panel45.TabIndex = 0;
            panel45.MouseClick += Panel_SelectColor;
            panel45.MouseDoubleClick += Panel_Paint;
            // 
            // panel22
            // 
            panel22.BorderStyle = BorderStyle.Fixed3D;
            panel22.Controls.Add(panel21);
            panel22.Location = new Point(396, 3);
            panel22.Margin = new Padding(1);
            panel22.Name = "panel22";
            panel22.Size = new Size(30, 30);
            panel22.TabIndex = 2;
            // 
            // panel21
            // 
            panel21.BackColor = Color.FromArgb(0, 183, 239);
            panel21.Location = new Point(3, 3);
            panel21.Name = "panel21";
            panel21.Size = new Size(20, 20);
            panel21.TabIndex = 0;
            panel21.MouseClick += Panel_SelectColor;
            panel21.MouseDoubleClick += Panel_Paint;
            // 
            // panel46
            // 
            panel46.BorderStyle = BorderStyle.Fixed3D;
            panel46.Controls.Add(panel33);
            panel46.Location = new Point(332, 40);
            panel46.Margin = new Padding(1);
            panel46.Name = "panel46";
            panel46.Size = new Size(30, 30);
            panel46.TabIndex = 13;
            // 
            // panel33
            // 
            panel33.BackColor = Color.FromArgb(168, 230, 29);
            panel33.Location = new Point(3, 3);
            panel33.Name = "panel33";
            panel33.Size = new Size(20, 20);
            panel33.TabIndex = 0;
            panel33.MouseClick += Panel_SelectColor;
            panel33.MouseDoubleClick += Panel_Paint;
            // 
            // panel20
            // 
            panel20.BorderStyle = BorderStyle.Fixed3D;
            panel20.Controls.Add(panel19);
            panel20.Location = new Point(364, 3);
            panel20.Margin = new Padding(1);
            panel20.Name = "panel20";
            panel20.Size = new Size(30, 30);
            panel20.TabIndex = 2;
            // 
            // panel19
            // 
            panel19.BackColor = Color.FromArgb(0, 192, 0);
            panel19.Location = new Point(3, 3);
            panel19.Name = "panel19";
            panel19.Size = new Size(20, 20);
            panel19.TabIndex = 0;
            panel19.MouseClick += Panel_SelectColor;
            panel19.MouseDoubleClick += Panel_Paint;
            // 
            // panel47
            // 
            panel47.BorderStyle = BorderStyle.Fixed3D;
            panel47.Controls.Add(panel48);
            panel47.Location = new Point(268, 40);
            panel47.Margin = new Padding(1);
            panel47.Name = "panel47";
            panel47.Size = new Size(30, 30);
            panel47.TabIndex = 14;
            // 
            // panel48
            // 
            panel48.BackColor = Color.FromArgb(255, 192, 14);
            panel48.Location = new Point(3, 3);
            panel48.Name = "panel48";
            panel48.Size = new Size(20, 20);
            panel48.TabIndex = 0;
            panel48.MouseClick += Panel_SelectColor;
            panel48.MouseDoubleClick += Panel_Paint;
            // 
            // panel18
            // 
            panel18.BorderStyle = BorderStyle.Fixed3D;
            panel18.Controls.Add(panel17);
            panel18.Location = new Point(332, 3);
            panel18.Margin = new Padding(1);
            panel18.Name = "panel18";
            panel18.Size = new Size(30, 30);
            panel18.TabIndex = 2;
            // 
            // panel17
            // 
            panel17.BackColor = Color.FromArgb(168, 230, 29);
            panel17.Location = new Point(3, 3);
            panel17.Name = "panel17";
            panel17.Size = new Size(20, 20);
            panel17.TabIndex = 0;
            panel17.MouseClick += Panel_SelectColor;
            panel17.MouseDoubleClick += Panel_Paint;
            // 
            // panel49
            // 
            panel49.BorderStyle = BorderStyle.Fixed3D;
            panel49.Controls.Add(panel50);
            panel49.Location = new Point(236, 40);
            panel49.Margin = new Padding(1);
            panel49.Name = "panel49";
            panel49.Size = new Size(30, 30);
            panel49.TabIndex = 15;
            // 
            // panel50
            // 
            panel50.BackColor = Color.FromArgb(255, 128, 0);
            panel50.Location = new Point(3, 3);
            panel50.Name = "panel50";
            panel50.Size = new Size(20, 20);
            panel50.TabIndex = 0;
            panel50.MouseClick += Panel_SelectColor;
            panel50.MouseDoubleClick += Panel_Paint;
            // 
            // panel16
            // 
            panel16.BorderStyle = BorderStyle.Fixed3D;
            panel16.Controls.Add(panel15);
            panel16.Location = new Point(268, 3);
            panel16.Margin = new Padding(1);
            panel16.Name = "panel16";
            panel16.Size = new Size(30, 30);
            panel16.TabIndex = 2;
            // 
            // panel15
            // 
            panel15.BackColor = Color.FromArgb(255, 192, 14);
            panel15.Location = new Point(3, 3);
            panel15.Name = "panel15";
            panel15.Size = new Size(20, 20);
            panel15.TabIndex = 0;
            panel15.MouseClick += Panel_SelectColor;
            panel15.MouseDoubleClick += Panel_Paint;
            // 
            // panel14
            // 
            panel14.BorderStyle = BorderStyle.Fixed3D;
            panel14.Controls.Add(panel13);
            panel14.Location = new Point(236, 3);
            panel14.Margin = new Padding(1);
            panel14.Name = "panel14";
            panel14.Size = new Size(30, 30);
            panel14.TabIndex = 2;
            // 
            // panel13
            // 
            panel13.BackColor = Color.FromArgb(255, 128, 0);
            panel13.Location = new Point(3, 3);
            panel13.Name = "panel13";
            panel13.Size = new Size(20, 20);
            panel13.TabIndex = 0;
            panel13.MouseClick += Panel_SelectColor;
            panel13.MouseDoubleClick += Panel_Paint;
            // 
            // panel53
            // 
            panel53.BorderStyle = BorderStyle.Fixed3D;
            panel53.Controls.Add(panel54);
            panel53.Location = new Point(204, 40);
            panel53.Margin = new Padding(1);
            panel53.Name = "panel53";
            panel53.Size = new Size(30, 30);
            panel53.TabIndex = 17;
            // 
            // panel54
            // 
            panel54.BackColor = Color.Red;
            panel54.Location = new Point(3, 3);
            panel54.Name = "panel54";
            panel54.Size = new Size(20, 20);
            panel54.TabIndex = 0;
            panel54.MouseClick += Panel_SelectColor;
            panel54.MouseDoubleClick += Panel_Paint;
            // 
            // panel12
            // 
            panel12.BorderStyle = BorderStyle.Fixed3D;
            panel12.Controls.Add(panel11);
            panel12.Location = new Point(204, 3);
            panel12.Margin = new Padding(1);
            panel12.Name = "panel12";
            panel12.Size = new Size(30, 30);
            panel12.TabIndex = 2;
            // 
            // panel11
            // 
            panel11.BackColor = Color.Red;
            panel11.Location = new Point(3, 3);
            panel11.Name = "panel11";
            panel11.Size = new Size(20, 20);
            panel11.TabIndex = 0;
            panel11.MouseClick += Panel_SelectColor;
            panel11.MouseDoubleClick += Panel_Paint;
            // 
            // panel55
            // 
            panel55.BorderStyle = BorderStyle.Fixed3D;
            panel55.Controls.Add(panel56);
            panel55.Location = new Point(172, 40);
            panel55.Margin = new Padding(1);
            panel55.Name = "panel55";
            panel55.Size = new Size(30, 30);
            panel55.TabIndex = 18;
            // 
            // panel56
            // 
            panel56.BackColor = Color.Maroon;
            panel56.Location = new Point(3, 3);
            panel56.Name = "panel56";
            panel56.Size = new Size(20, 20);
            panel56.TabIndex = 0;
            panel56.MouseClick += Panel_SelectColor;
            panel56.MouseDoubleClick += Panel_Paint;
            // 
            // panel10
            // 
            panel10.BorderStyle = BorderStyle.Fixed3D;
            panel10.Controls.Add(panel9);
            panel10.Location = new Point(172, 3);
            panel10.Margin = new Padding(1);
            panel10.Name = "panel10";
            panel10.Size = new Size(30, 30);
            panel10.TabIndex = 2;
            // 
            // panel9
            // 
            panel9.BackColor = Color.Maroon;
            panel9.Location = new Point(3, 3);
            panel9.Name = "panel9";
            panel9.Size = new Size(20, 20);
            panel9.TabIndex = 0;
            panel9.MouseClick += Panel_SelectColor;
            panel9.MouseDoubleClick += Panel_Paint;
            // 
            // panel57
            // 
            panel57.BorderStyle = BorderStyle.Fixed3D;
            panel57.Controls.Add(panel58);
            panel57.Location = new Point(140, 40);
            panel57.Margin = new Padding(1);
            panel57.Name = "panel57";
            panel57.Size = new Size(30, 30);
            panel57.TabIndex = 19;
            // 
            // panel58
            // 
            panel58.BackColor = Color.Gray;
            panel58.Location = new Point(3, 3);
            panel58.Name = "panel58";
            panel58.Size = new Size(20, 20);
            panel58.TabIndex = 0;
            panel58.MouseClick += Panel_SelectColor;
            panel58.MouseDoubleClick += Panel_Paint;
            // 
            // panel8
            // 
            panel8.BorderStyle = BorderStyle.Fixed3D;
            panel8.Controls.Add(panel7);
            panel8.Location = new Point(140, 3);
            panel8.Margin = new Padding(1);
            panel8.Name = "panel8";
            panel8.Size = new Size(30, 30);
            panel8.TabIndex = 2;
            // 
            // panel7
            // 
            panel7.BackColor = Color.Gray;
            panel7.Location = new Point(3, 3);
            panel7.Name = "panel7";
            panel7.Size = new Size(20, 20);
            panel7.TabIndex = 0;
            panel7.MouseClick += Panel_SelectColor;
            panel7.MouseDoubleClick += Panel_Paint;
            // 
            // panel59
            // 
            panel59.BorderStyle = BorderStyle.Fixed3D;
            panel59.Controls.Add(panel60);
            panel59.Location = new Point(108, 40);
            panel59.Margin = new Padding(1);
            panel59.Name = "panel59";
            panel59.Size = new Size(30, 30);
            panel59.TabIndex = 20;
            // 
            // panel60
            // 
            panel60.BackColor = Color.FromArgb(64, 64, 64);
            panel60.Location = new Point(3, 3);
            panel60.Name = "panel60";
            panel60.Size = new Size(20, 20);
            panel60.TabIndex = 0;
            panel60.MouseClick += Panel_SelectColor;
            panel60.MouseDoubleClick += Panel_Paint;
            // 
            // panel6
            // 
            panel6.BorderStyle = BorderStyle.Fixed3D;
            panel6.Controls.Add(panel5);
            panel6.Location = new Point(108, 3);
            panel6.Margin = new Padding(1);
            panel6.Name = "panel6";
            panel6.Size = new Size(30, 30);
            panel6.TabIndex = 2;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(64, 64, 64);
            panel5.Location = new Point(3, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(20, 20);
            panel5.TabIndex = 0;
            panel5.MouseClick += Panel_SelectColor;
            panel5.MouseDoubleClick += Panel_Paint;
            // 
            // panel61
            // 
            panel61.BorderStyle = BorderStyle.Fixed3D;
            panel61.Controls.Add(panel62);
            panel61.Location = new Point(76, 40);
            panel61.Margin = new Padding(1);
            panel61.Name = "panel61";
            panel61.Size = new Size(30, 30);
            panel61.TabIndex = 7;
            // 
            // panel62
            // 
            panel62.BackColor = Color.Black;
            panel62.Location = new Point(3, 3);
            panel62.Name = "panel62";
            panel62.Size = new Size(20, 20);
            panel62.TabIndex = 0;
            panel62.MouseClick += Panel_SelectColor;
            panel62.MouseDoubleClick += Panel_Paint;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(panel4);
            panel3.Location = new Point(76, 3);
            panel3.Margin = new Padding(1);
            panel3.Name = "panel3";
            panel3.Size = new Size(30, 30);
            panel3.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Black;
            panel4.Location = new Point(3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(20, 20);
            panel4.TabIndex = 0;
            panel4.MouseClick += Panel_SelectColor;
            panel4.MouseDoubleClick += Panel_Paint;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(panel64);
            panel2.Controls.Add(panel66);
            panel2.Location = new Point(5, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(65, 65);
            panel2.TabIndex = 0;
            // 
            // panel64
            // 
            panel64.BorderStyle = BorderStyle.Fixed3D;
            panel64.Controls.Add(panelCurrentColor);
            panel64.Location = new Point(10, 10);
            panel64.Margin = new Padding(1);
            panel64.Name = "panel64";
            panel64.Size = new Size(30, 30);
            panel64.TabIndex = 2;
            // 
            // panelCurrentColor
            // 
            panelCurrentColor.BackColor = Color.Black;
            panelCurrentColor.Location = new Point(3, 3);
            panelCurrentColor.Name = "panelCurrentColor";
            panelCurrentColor.Size = new Size(20, 20);
            panelCurrentColor.TabIndex = 0;
            // 
            // panel66
            // 
            panel66.BorderStyle = BorderStyle.Fixed3D;
            panel66.Controls.Add(panelSecondaryColor);
            panel66.Location = new Point(25, 25);
            panel66.Margin = new Padding(1);
            panel66.Name = "panel66";
            panel66.Size = new Size(30, 30);
            panel66.TabIndex = 2;
            // 
            // panelSecondaryColor
            // 
            panelSecondaryColor.BackColor = Color.White;
            panelSecondaryColor.Location = new Point(3, 3);
            panelSecondaryColor.Name = "panelSecondaryColor";
            panelSecondaryColor.Size = new Size(20, 20);
            panelSecondaryColor.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(984, 761);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(700, 500);
            Name = "Form1";
            Text = "MS Paint 2024";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Canvas).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            panel29.ResumeLayout(false);
            panel36.ResumeLayout(false);
            panel31.ResumeLayout(false);
            panel38.ResumeLayout(false);
            panel28.ResumeLayout(false);
            panel40.ResumeLayout(false);
            panel26.ResumeLayout(false);
            panel42.ResumeLayout(false);
            panel24.ResumeLayout(false);
            panel44.ResumeLayout(false);
            panel22.ResumeLayout(false);
            panel46.ResumeLayout(false);
            panel20.ResumeLayout(false);
            panel47.ResumeLayout(false);
            panel18.ResumeLayout(false);
            panel49.ResumeLayout(false);
            panel16.ResumeLayout(false);
            panel14.ResumeLayout(false);
            panel53.ResumeLayout(false);
            panel12.ResumeLayout(false);
            panel55.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel57.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel59.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel61.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel64.ResumeLayout(false);
            panel66.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem imageToolStripMenuItem;
        private ToolStripMenuItem colorsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem ediToolStripMenuItem;
        private ToolStripMenuItem invertColorsToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabelPos;
        private ToolStripStatusLabel statusLabelSize;
        private Panel panel1;
        private PictureBox Canvas;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private Button buttonLine;
        private Button buttonSelect;
        private Button buttonPen;
        private ToolStripMenuItem zoomToolStripMenuItem;
        private ToolStripMenuItem zoomOutToolStripMenuItem;
        private ToolStripMenuItem zoomInToolStripMenuItem;
        private ToolStripMenuItem resetZoomToolStripMenuItem;
        private Panel panel3;
        private Panel panel4;
        private Panel panel2;
        private Panel panel28;
        private Panel panel27;
        private Panel panel26;
        private Panel panel25;
        private Panel panel24;
        private Panel panel23;
        private Panel panel22;
        private Panel panel21;
        private Panel panel20;
        private Panel panel19;
        private Panel panel18;
        private Panel panel17;
        private Panel panel16;
        private Panel panel15;
        private Panel panel14;
        private Panel panel13;
        private Panel panel12;
        private Panel panel11;
        private Panel panel10;
        private Panel panel9;
        private Panel panel8;
        private Panel panel7;
        private Panel panel6;
        private Panel panel5;
        private Panel panel33;
        private Panel panel36;
        private Panel panel37;
        private Panel panel38;
        private Panel panel39;
        private Panel panel40;
        private Panel panel41;
        private Panel panel42;
        private Panel panel43;
        private Panel panel44;
        private Panel panel45;
        private Panel panel46;
        private Panel panel47;
        private Panel panel48;
        private Panel panel49;
        private Panel panel50;
        private Panel panel53;
        private Panel panel54;
        private Panel panel55;
        private Panel panel56;
        private Panel panel57;
        private Panel panel58;
        private Panel panel59;
        private Panel panel60;
        private Panel panel61;
        private Panel panel62;
        private Panel panel66;
        private Panel panelSecondaryColor;
        private Panel panel64;
        private Panel panelCurrentColor;
        private Panel panel29;
        private Panel panel30;
        private Panel panel31;
        private Panel panel32;
        private ToolStripStatusLabel statusLabelZoom;
    }
}
