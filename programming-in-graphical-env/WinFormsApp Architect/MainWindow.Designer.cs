namespace WinFormsApp_Architect
{
    partial class MainWindow
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
            newBlueprintToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            Canvas = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBoxAdd = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            buttonCoffeeTable = new Button();
            buttonDoubleBed = new Button();
            buttonSofa = new Button();
            buttonTable = new Button();
            buttonWall = new Button();
            groupBoxCreated = new GroupBox();
            furnitureListBox = new ListBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Canvas).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            groupBoxAdd.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            groupBoxCreated.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(848, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newBlueprintToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // newBlueprintToolStripMenuItem
            // 
            newBlueprintToolStripMenuItem.Name = "newBlueprintToolStripMenuItem";
            newBlueprintToolStripMenuItem.ShortcutKeys = Keys.F2;
            newBlueprintToolStripMenuItem.Size = new Size(168, 22);
            newBlueprintToolStripMenuItem.Text = "New Blueprint";
            newBlueprintToolStripMenuItem.Click += newBlueprintToolStripMenuItem_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(Canvas);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tableLayoutPanel1);
            splitContainer1.Size = new Size(848, 617);
            splitContainer1.SplitterDistance = 282;
            splitContainer1.TabIndex = 1;
            // 
            // Canvas
            // 
            Canvas.Dock = DockStyle.Fill;
            Canvas.Location = new Point(0, 0);
            Canvas.Name = "Canvas";
            Canvas.Size = new Size(282, 617);
            Canvas.TabIndex = 0;
            Canvas.TabStop = false;
            Canvas.MouseDown += Canvas_MouseDown;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(groupBoxAdd, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBoxCreated, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(562, 617);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBoxAdd
            // 
            groupBoxAdd.Controls.Add(flowLayoutPanel1);
            groupBoxAdd.Dock = DockStyle.Fill;
            groupBoxAdd.Location = new Point(3, 3);
            groupBoxAdd.Name = "groupBoxAdd";
            groupBoxAdd.Size = new Size(556, 302);
            groupBoxAdd.TabIndex = 0;
            groupBoxAdd.TabStop = false;
            groupBoxAdd.Text = "Add furnitures";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(buttonCoffeeTable);
            flowLayoutPanel1.Controls.Add(buttonDoubleBed);
            flowLayoutPanel1.Controls.Add(buttonSofa);
            flowLayoutPanel1.Controls.Add(buttonTable);
            flowLayoutPanel1.Controls.Add(buttonWall);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 19);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(550, 280);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // buttonCoffeeTable
            // 
            buttonCoffeeTable.BackColor = Color.White;
            buttonCoffeeTable.BackgroundImage = Properties.Resources.coffee_table;
            buttonCoffeeTable.BackgroundImageLayout = ImageLayout.Stretch;
            buttonCoffeeTable.Location = new Point(3, 3);
            buttonCoffeeTable.Name = "buttonCoffeeTable";
            buttonCoffeeTable.Size = new Size(75, 75);
            buttonCoffeeTable.TabIndex = 0;
            buttonCoffeeTable.Tag = "Coffee Table";
            buttonCoffeeTable.UseVisualStyleBackColor = false;
            buttonCoffeeTable.Click += buttonFurniture_Click;
            // 
            // buttonDoubleBed
            // 
            buttonDoubleBed.BackColor = Color.White;
            buttonDoubleBed.BackgroundImage = Properties.Resources.double_bed;
            buttonDoubleBed.BackgroundImageLayout = ImageLayout.Stretch;
            buttonDoubleBed.Location = new Point(84, 3);
            buttonDoubleBed.Name = "buttonDoubleBed";
            buttonDoubleBed.Size = new Size(75, 75);
            buttonDoubleBed.TabIndex = 1;
            buttonDoubleBed.Tag = "Double Bed";
            buttonDoubleBed.UseVisualStyleBackColor = false;
            buttonDoubleBed.Click += buttonFurniture_Click;
            // 
            // buttonSofa
            // 
            buttonSofa.BackColor = Color.White;
            buttonSofa.BackgroundImage = Properties.Resources.sofa;
            buttonSofa.BackgroundImageLayout = ImageLayout.Stretch;
            buttonSofa.Location = new Point(165, 3);
            buttonSofa.Name = "buttonSofa";
            buttonSofa.Size = new Size(75, 75);
            buttonSofa.TabIndex = 2;
            buttonSofa.Tag = "Sofa";
            buttonSofa.UseVisualStyleBackColor = false;
            buttonSofa.Click += buttonFurniture_Click;
            // 
            // buttonTable
            // 
            buttonTable.BackColor = Color.White;
            buttonTable.BackgroundImage = Properties.Resources.table;
            buttonTable.BackgroundImageLayout = ImageLayout.Stretch;
            buttonTable.Location = new Point(246, 3);
            buttonTable.Name = "buttonTable";
            buttonTable.Size = new Size(75, 75);
            buttonTable.TabIndex = 3;
            buttonTable.Tag = "Table";
            buttonTable.UseVisualStyleBackColor = false;
            buttonTable.Click += buttonFurniture_Click;
            // 
            // buttonWall
            // 
            buttonWall.BackColor = Color.White;
            buttonWall.BackgroundImage = Properties.Resources.wall;
            buttonWall.BackgroundImageLayout = ImageLayout.Stretch;
            buttonWall.Location = new Point(327, 3);
            buttonWall.Name = "buttonWall";
            buttonWall.Size = new Size(75, 75);
            buttonWall.TabIndex = 4;
            buttonWall.Tag = "Wall";
            buttonWall.UseVisualStyleBackColor = false;
            buttonWall.Click += buttonFurniture_Click;
            // 
            // groupBoxCreated
            // 
            groupBoxCreated.Controls.Add(furnitureListBox);
            groupBoxCreated.Dock = DockStyle.Fill;
            groupBoxCreated.Location = new Point(3, 311);
            groupBoxCreated.Name = "groupBoxCreated";
            groupBoxCreated.Size = new Size(556, 303);
            groupBoxCreated.TabIndex = 1;
            groupBoxCreated.TabStop = false;
            groupBoxCreated.Text = "Craeted furnitures";
            // 
            // furnitureListBox
            // 
            furnitureListBox.Dock = DockStyle.Fill;
            furnitureListBox.FormattingEnabled = true;
            furnitureListBox.ItemHeight = 15;
            furnitureListBox.Location = new Point(3, 19);
            furnitureListBox.Name = "furnitureListBox";
            furnitureListBox.Size = new Size(550, 281);
            furnitureListBox.TabIndex = 0;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(848, 641);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(400, 300);
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Architector";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Canvas).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            groupBoxAdd.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            groupBoxCreated.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newBlueprintToolStripMenuItem;
        private SplitContainer splitContainer1;
        private PictureBox Canvas;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBoxAdd;
        private GroupBox groupBoxCreated;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button buttonCoffeeTable;
        private Button buttonDoubleBed;
        private Button buttonSofa;
        private Button buttonTable;
        private Button buttonWall;
        private ListBox furnitureListBox;
    }
}
