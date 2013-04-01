using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataCreator
{
    public partial class Form1 : Form
    {
        private string m_filePath;
        private int m_width, m_height;

        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Image Files (*.jpg, *.png)|*.jpg;*.png";
        }

        private void selectImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                m_filePath = openFileDialog1.FileName;
                pictureBox1.Image = new Bitmap(m_filePath);
                m_width = pictureBox1.Image.Width;
                m_height = pictureBox1.Image.Height;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SpecifySubimage s = new SpecifySubimage(m_width, m_height);
            s.Show();
        }
    }
}
