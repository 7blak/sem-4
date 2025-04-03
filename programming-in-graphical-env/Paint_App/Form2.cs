using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form2 : Form
    {
        private Color selectedColor = Color.White;

        public Form2()
        {
            InitializeComponent();
        }
        public Color SelectedColor { get { return selectedColor; } }
        public int SelectedHeight { get { return (int)numericHeight.Value; } }
        public int SelectedWidth { get { return (int)numericWidth.Value; } }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK )
            {
                selectedColor = colorDialog.Color;
                buttonColor.BackColor = selectedColor;
            }
        }
    }
}
