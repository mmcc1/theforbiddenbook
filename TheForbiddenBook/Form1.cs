using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheForbiddenBook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void generatePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            int _index = 0;

            TheForbiddenBook _tfb = new TheForbiddenBook();

            string[] _thePage = _tfb.GeneratePage(1000);
            string _finalString = "";

            for(int i = 0; i < _thePage.Length; i++)
            {
                _finalString += _thePage[i];
            }

            textBox1.Text = _finalString;
        }

        private void generateImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TheForbiddenBook _tfb = new TheForbiddenBook();

            pictureBox1.Image = _tfb.GenerateImage(1024, 768);
        }
    }
}
