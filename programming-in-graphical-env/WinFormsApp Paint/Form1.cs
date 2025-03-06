namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Bitmap drawArea;
        private int canvasHeight = 600;
        private int canvasWidth = 800;
        private Pen pen;
        private float penSize = 20;
        private Color penColorPrev = Color.White;
        private Color penColor = Color.Black;
        private Color canvasColor = Color.White;
        private Point previousPoint = Point.Empty;
        private string lastFileName = "";
        public Form1()
        {
            InitializeComponent();
            drawArea = new Bitmap(Canvas.Size.Width, Canvas.Size.Height);
            Canvas.Image = drawArea;
            pen = new Pen(penColor);
            stripBarSize.Text = "800, 600 px";
            stripBarCurrent.Text = "0, 0 px";
            openFileDialog1.Filter = "Image Files(*.BMP; *.PNG; *.JPG; *.JPEG)| *.BMP; *.PNG; *.JPG; *.JPEG";
            saveFileDialog1.Filter = "Bitmap File(*.BMP)| *.BMP";
            saveFileDialog1.FileName = lastFileName;
            using (Graphics g = Graphics.FromImage(drawArea))
            {
                g.Clear(Color.White);
            }


        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (NewDialog dlg = new NewDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    canvasHeight = dlg.SelectedHeight;
                    canvasWidth = dlg.SelectedWidth;
                    penColor = dlg.SelectedColor;
                    canvasColor = dlg.SelectedColor;
                }
            }
            Canvas.Size = new Size(canvasWidth, canvasHeight);
            using (Graphics g = Graphics.FromImage(drawArea))
            {
                g.Clear(canvasColor);
            }
            Canvas.Invalidate();
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point position = e.Location;
            if (e.Button == MouseButtons.Left)
            {
                using (Graphics g = Graphics.FromImage(drawArea))
                {
                    g.DrawLine(pen, previousPoint, e.Location);
                }
            }
            previousPoint = e.Location;
            stripBarCurrent.Text = $"{position.X}, {position.Y} px";
            stripBarSize.Text = $"{canvasWidth}, {canvasHeight} px";
            Canvas.Refresh();
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            previousPoint = e.Location;
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            previousPoint = Point.Empty;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = lastFileName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lastFileName = Path.GetFileNameWithoutExtension(saveFileDialog1.FileName);
            }
        }

        private void Canvas_Click(object sender, EventArgs e)
        {

        }

        private void editColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                penColorPrev = penColor;
                penColor = colorDialog.Color;
                pen = new Pen(penColor);
            }
        }
    }
    public class NewDialog : Form
    {
        private Label widthLabel;
        private Label heightLabel;
        private Label backgroundLabel;
        private NumericUpDown widthNumeric;
        private NumericUpDown heightNumeric;
        private Button newButton;
        private Button cancelButton;
        private ColorDialog colorDialog;
        private Color selectedColor;
        public NewDialog()
        {
            this.Text = "New image...";
            this.Size = new System.Drawing.Size(300, 200);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            widthLabel = new Label();
            widthLabel.Text = "Width";
            widthLabel.Location = new Point(20, 20);
            this.Controls.Add(widthLabel);

            widthNumeric = new NumericUpDown();
            widthNumeric.Location = new Point(120, 20);
            widthNumeric.Minimum = 1;
            widthNumeric.Maximum = 10000;
            this.Controls.Add(widthNumeric);

            heightLabel = new Label();
            heightLabel.Text = "Height";
            heightLabel.Location = new Point(20, 60);
            this.Controls.Add(heightLabel);

            heightNumeric = new NumericUpDown();
            heightNumeric.Location = new Point(120, 60);
            heightNumeric.Minimum = 1;
            heightNumeric.Maximum = 10000;
            this.Controls.Add(heightNumeric);

            backgroundLabel = new Label();
            backgroundLabel.Text = "Background";
            backgroundLabel.Location = new Point(20, 100);
            this.Controls.Add(backgroundLabel);

            Button colorButton = new Button();
            colorButton.Text = "Pick Color";
            colorButton.Location = new Point(120, 100);
            colorButton.Click += ColorButton_Click;
            this.Controls.Add(colorButton);

            newButton = new Button();
            newButton.Text = "New";
            newButton.DialogResult = DialogResult.OK;
            newButton.Location = new Point(50, 130);
            this.Controls.Add(newButton);

            cancelButton = new Button();
            cancelButton.Text = "Cancel";
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new Point(150, 130);
            this.Controls.Add(cancelButton);

            colorDialog = new ColorDialog();
        }

        public int SelectedWidth
        {
            get { return (int)widthNumeric.Value; }
        }

        public int SelectedHeight
        {
            get { return (int)heightNumeric.Value; }
        }

        public Color SelectedColor
        {
            get { return colorDialog.Color; }
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                selectedColor = colorDialog.Color;
            }
        }
    }
}
