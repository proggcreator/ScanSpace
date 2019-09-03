using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab10_11
{
    public partial class First : Form
    {
        public First()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ScanSpace newForn = new ScanSpace();

            Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void First_Load(object sender, EventArgs e)
        {
            label1.Parent = pictureBox1;
            label2.Parent = pictureBox1;
            button1.Parent = pictureBox1;
        }
    }
}
