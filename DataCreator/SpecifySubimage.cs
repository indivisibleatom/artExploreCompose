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
    public partial class SpecifySubimage : Form
    {
        private int m_width;
        private int m_height;

        public SpecifySubimage(int width, int height)
        {
            InitializeComponent();
            m_width = width;
            m_height = height;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numCols;
            int numRows;
            if (int.TryParse(textBox1.Text, out numCols) && int.TryParse(textBox2.Text, out numRows))
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    string folderName = folderBrowserDialog1.SelectedPath;
                    int sizeGridX = m_width / numCols;
                    int sizeGridY = m_height / numRows;
                }
            }
        }
    }
}
