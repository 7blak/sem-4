using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        private const string IniFilePath = "recent_files.ini";
        private const int MaxRecentFiles = 10;
        private List<string> recentFiles = new List<string>();
        private DirectBitmap drawArea;
        private int canvasWidth = 800;
        private int canvasHeight = 600;
        private Pen pen;
        private Pen secondaryPen;
        private Color prevColor = Color.White;
        private Color canvasColor = Color.White;
        private string lastFileName = "";
        private string lastFilePath = "";
        private Point previousPoint;
        private Cursor currentCursor = Cursors.Default;
        private float zoomLevel = 1.0f;
        private float[] zoomStep = { 10f, 5f, 3f, 2f, 1.5f, 1f, 0.75f, 0.5f, 0.25f, 0.1f };

        public Form1()
        {
            InitializeComponent();
            LoadRecentFiles();
            drawArea = new DirectBitmap(Canvas.Width, Canvas.Height);
            Canvas.Image = drawArea.Bitmap;
            pen = new Pen(Color.Black);
            secondaryPen = new Pen(Color.White);
            using (Graphics g = Graphics.FromImage(drawArea.Bitmap))
            {
                g.Clear(Color.White);
            }
            statusLabelSize.Text = $"{canvasWidth}, {canvasHeight} px";
            UpdateFileMenu();
        }

        private void LoadRecentFiles()
        {
            if (File.Exists(IniFilePath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(IniFilePath);
                    recentFiles.AddRange(lines);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading recent files: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveRecentFiles()
        {
            try
            {
                File.WriteAllLines(IniFilePath, recentFiles.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving recent files: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateFileMenu()
        {
            int exitIndex = fileToolStripMenuItem.DropDownItems.IndexOfKey("exitToolStripMenuItem");
            int separatorIndex = fileToolStripMenuItem.DropDownItems.IndexOfKey("toolStripSeparator3");
            ToolStripItem[] itemsToRemove = fileToolStripMenuItem.DropDownItems
        .OfType<ToolStripMenuItem>()
        .Where(item => item.Tag != null && item.Tag.ToString() == "RecentFile")
        .ToArray();

            foreach (var item in itemsToRemove)
            {
                fileToolStripMenuItem.DropDownItems.Remove(item);
            }
            for (int i = 0; i < recentFiles.Count; i++)
            {
                string PATH = recentFiles[i];
                ToolStripMenuItem item = new ToolStripMenuItem($"{i}: {Path.GetFileNameWithoutExtension(PATH)}");
                item.Tag = "RecentFile";
                item.Click += (sender, e) => OpenRecentFile(PATH);
                fileToolStripMenuItem.DropDownItems.Insert(7, item);
            }
        }
        private void ClearRecentFiles()
        {
            recentFiles.Clear();
            SaveRecentFiles();
            UpdateFileMenu();
        }
        private void OpenRecentFile(string fileName)
        {
            Bitmap loadedImage = new Bitmap(Image.FromFile(fileName));
            drawArea = new DirectBitmap(loadedImage.Width, loadedImage.Height);
            canvasHeight = drawArea.Height;
            canvasWidth = drawArea.Width;
            Canvas.Size = new Size(canvasWidth, canvasHeight);
            using (Graphics g = Graphics.FromImage(drawArea.Bitmap))
            {
                g.Clear(canvasColor);
                g.DrawImage(loadedImage, Point.Empty);
            }
            Canvas.Image = drawArea.Bitmap;
            Canvas.Invalidate();
            loadedImage.Dispose();
            recentFiles.Remove(fileName);
            recentFiles.Insert(0, fileName);
            if (recentFiles.Count > MaxRecentFiles)
                recentFiles.RemoveAt(recentFiles.Count - 1);
            SaveRecentFiles();
            UpdateFileMenu();
        }
        private void ediToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                prevColor = pen.Color;
                pen.Color = colorDialog.Color;
                panelCurrentColor.BackColor = colorDialog.Color;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = lastFileName;
            saveFileDialog.Filter = "Bitmap (*.bmp)|*.bmp|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG (*.png)|*.png|All picture files (*.bmp;*.jpg;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                lastFileName = Path.GetFileNameWithoutExtension(saveFileDialog.FileName);
                lastFilePath = saveFileDialog.FileName;
                File.Create(saveFileDialog.FileName).Close();
                drawArea.Bitmap.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point position = e.Location;
            if (e.Button == MouseButtons.Left)
            {
                using (Graphics g = Graphics.FromImage(Canvas.Image))
                {
                    g.DrawLine(pen, previousPoint, e.Location);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                using (Graphics g = Graphics.FromImage(Canvas.Image))
                {
                    g.DrawLine(secondaryPen, previousPoint, e.Location);
                }
            }
            previousPoint = e.Location;
            statusLabelPos.Text = $"{position.X}, {position.Y} px";
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

        private void Canvas_MouseLeave(object sender, EventArgs e)
        {
            statusLabelPos.Text = "";
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form2 form2 = new Form2())
            {
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    canvasHeight = form2.SelectedHeight;
                    canvasWidth = form2.SelectedWidth;
                    canvasColor = form2.SelectedColor;
                }
            }
            Canvas.Size = new Size(canvasWidth, canvasHeight);
            using (Graphics g = Graphics.FromImage(drawArea.Bitmap))
            {
                g.Clear(canvasColor);
            }
            Canvas.Invalidate();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Bitmap (*.bmp)|*.bmp|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG (*.png)|*.png|All picture files (*.bmp;*.jpg;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenRecentFile(openFileDialog.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lastFilePath == "")
                saveAsToolStripMenuItem_Click(sender, e);
            else
            {
                drawArea.Bitmap.Save(lastFilePath, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            UpdateFileMenu();
        }

        private void invertColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawArea.InvertColors();
            Canvas.Refresh();
        }

        private void Panel_Paint(object sender, MouseEventArgs e)
        {
            Panel panel = sender as Panel ?? throw new ArgumentNullException("Panel was null in panel_paint");
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                panel.BackColor = colorDialog.Color;
            }
        }

        private void Panel_SelectColor(object sender, MouseEventArgs e)
        {
            Panel panel = sender as Panel ?? throw new ArgumentNullException("Panel was null in panel_paint");
            if (e.Button == MouseButtons.Left)
            {
                pen.Color = panel.BackColor;
                panelCurrentColor.BackColor = panel.BackColor;
            }
            else if (e.Button == MouseButtons.Right)
            {
                secondaryPen.Color = panel.BackColor;
                panelSecondaryColor.BackColor = panel.BackColor;
            }
        }

        private void ZoomCanvas()
        {
            statusLabelZoom.Text = $"{zoomLevel * 100}%";
            int newWidth = (int)(drawArea.Width * zoomLevel);
            int newHeight = (int)(drawArea.Height * zoomLevel);

            Canvas.Width = newWidth; Canvas.Height = newHeight;
            Canvas.Invalidate();
        }
        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zoomLevel = Decrease(zoomLevel);
            ZoomCanvas();
        }
        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zoomLevel = Increase(zoomLevel);
            ZoomCanvas();
        }
        private float Decrease(float value)
        {
            foreach (float step in zoomStep)
            {
                if (value > step)
                {
                    value = step;
                    break;
                }
            }
            return value;
        }

        private float Increase(float value)
        {
            float temp = value;
            foreach (float step in zoomStep)
            {
                if (value < step)
                {
                    temp = step;
                }
            }
            return temp;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
    public class DirectBitmap : IDisposable
    {
        public Bitmap Bitmap { get; set; }
        public Int32[] Bits { get; private set; }
        public bool Disposed { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }

        protected GCHandle BitsHandle { get; private set; }

        public DirectBitmap(int width, int height)
        {
            Width = width;
            Height = height;
            Bits = new Int32[width * height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
        }

        public void SetPixel(int x, int y, Color colour)
        {
            int index = x + (y * Width);
            int col = colour.ToArgb();

            Bits[index] = col;
        }

        public Color GetPixel(int x, int y)
        {
            int index = x + (y * Width);
            int col = Bits[index];
            Color result = Color.FromArgb(col);

            return result;
        }

        public void InvertColors()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Color pixelColor = GetPixel(x, y);
                    Color invertedColor = Color.FromArgb(255 - pixelColor.R, 255 - pixelColor.G, 255 - pixelColor.B);
                    SetPixel(x, y, invertedColor);
                }
            }
        }

        public void Dispose()
        {
            if (Disposed) return;
            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
        }
    }
}
