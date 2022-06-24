using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ForbiddenBook
{
    public partial class Form1 : Form
    {
        private int[] buffer;
        private int currentIndex;
        private object lockObj;
        EntropyEngine ee;
        private int width;
        private int height;
        string[] charArray = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", ".", "," };

        public Form1()
        {
            InitializeComponent();

            width = 640;
            height = 480;
            buffer = new int[width * height];
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            lockObj = new object();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Start")
            {
                button1.Text = "Stop";
                ee = new EntropyEngine();
                ee.RaiseSeq += new RaiseHandler(AddToBuffer);
                ee.StartEngine();
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
                ee.KillThreads();
                button1.Text = "Start";
            }
        }

        private void AddToBuffer(int i)
        {
            lock (lockObj)
            {
                if (currentIndex >= buffer.Length)
                    currentIndex = 0;

                buffer[currentIndex++] = i;
            }
        }

        private Bitmap GenerateImage(int x, int y)
        {
            Bitmap _bm = new Bitmap(x, y);
            int index = 0;

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Color _c = Color.FromArgb(0, 0, buffer[index++]);
                    _bm.SetPixel(i, j, _c);
                }
            }

            return _bm;
        }

        public string GenerateText()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < buffer.Length; i++)
            {
                sb.Append(charArray[buffer[i] % charArray.Length]);
            }

            return sb.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
            pictureBox1.BackgroundImage = GenerateImage(width, height);
            

            if (textBox1.TextLength > width * height * 2)
                textBox1.Clear();

            textBox1.AppendText(GenerateText());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            ee.KillThreads();
        }
    }
}