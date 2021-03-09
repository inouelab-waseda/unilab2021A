using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unilab2021A.Forms
{
    public partial class TestStage : Form
    {
        private Graphics _graphics;
        // private Field _field;
        private int[,] _field;
        // private int FieldWidth => _field.Width;
        private int FieldWidth => _field.GetLength(0);
        // private int FieldHeight => _field.Height;
        private int FieldHeight => _field.GetLength(1);
        public float CellWidth => (float)pictureBox1.Width / FieldWidth;
        public float CellHeight => (float)pictureBox1.Height / FieldHeight;
        
        public TestStage()
        {
            InitializeComponent();

            // graphics
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _graphics = Graphics.FromImage(pictureBox1.Image);

            _field = new int[10, 6];

            _initialize();
        }

        public void _initialize()
        {
            _field[0, 0] = 1;
            _field[1, 1] = 1;
            _field[2, 2] = 1;
            _field[3, 3] = 1;
            _field[4, 4] = 1;
            _field[5, 4] = 1;
            _field[6, 3] = 1;
            Image img = Image.FromFile("..\\..\\Images\\snowman.jpg");
            _graphics.Clear(Color.LightGreen);
            for(var x = 0; x < FieldWidth; x++)
            {
                for(var y= 0; y < FieldHeight; y++)
                {
                    if(_field[x, y] == 1) _graphics.DrawImage(img, x * CellWidth, y * CellHeight, CellWidth, CellHeight);
                }
            }
        }
    }
}
