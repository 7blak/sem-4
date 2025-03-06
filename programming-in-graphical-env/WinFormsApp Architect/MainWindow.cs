using System.ComponentModel;

namespace WinFormsApp_Architect
{
    public partial class MainWindow : Form
    {
        private Blueprint blueprint;
        private Button selectedButton = null;
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            blueprint = new Blueprint(Canvas.Width, Canvas.Height);
            Canvas.Image = blueprint.Bitmap;
            furnitureListBox.DataSource = blueprint.Furnitures;
        }
        private void newBlueprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Initialize();
        }
        private void buttonFurniture_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (selectedButton == null)
            {
                btn.BackColor = Color.AntiqueWhite;
                selectedButton = btn;
            }
            else if(selectedButton == btn)
            {
                btn.BackColor = Color.White;
                selectedButton = btn;
            }
            else
            {
                btn.BackColor = Color.AntiqueWhite;
                selectedButton.BackColor = Color.White;
                selectedButton = btn;
            }
        }
        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (selectedButton != null)
                {
                    blueprint.AddFurniture(new Furniture(e.Location, selectedButton.BackgroundImage, selectedButton.Tag.ToString()));
                    selectedButton.BackColor = Color.White;
                    selectedButton = null;
                    blueprint.Draw();
                    Canvas.Refresh();
                }
            }
        }
    }
    public class Blueprint
    {
        public BindingList<Furniture> Furnitures { get; }
        public Bitmap Bitmap { get; private set; }
        private Color backgroundColor = Color.White;
        public Blueprint(int width, int height)
        {
            Bitmap = new Bitmap(width, height);
            Furnitures = new BindingList<Furniture>();
            Draw();
        }
        public void AddFurniture(Furniture furniture)
        {
            Furnitures.Add(furniture);
        }
        public void Draw()
        {
            using (Graphics g = Graphics.FromImage(Bitmap))
            {
                g.Clear(backgroundColor);
                foreach(Furniture furniture in Furnitures)
                    furniture.Draw(g);
            }
        }
    }
    public class Furniture
    {
        private Point position;
        private Image icon;
        private string name;
        public Furniture(Point position, Image icon, string name)
        {
            this.position = position;
            this.icon = icon;
            this.name = name;
        }
        public void Draw(Graphics g)
        {
            var center = new Point(position.X - icon.Size.Width / 2, position.Y - icon.Size.Height / 2);
            g.DrawImage(icon, center);
        }
        public override string ToString()
        {
            return name + " " + position.ToString();
        }
    }
}
