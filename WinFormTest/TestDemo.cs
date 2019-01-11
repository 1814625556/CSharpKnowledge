using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormTest
{
    public partial class TestDemo : Form
    {
        public TestDemo()
        {
            InitializeComponent();
            
            //DrawingRectangle(new object(), new PaintEventArgs());
        }

        private void DrawingRectangle()
        {
            var pen = new Pen(Color.Red, 1);
            var x = textBox1.Location.X;
            var y = textBox1.Location.Y;
            var width = textBox1.Width;
            var height = textBox1.Height;
            Graphics g = this.panel1.CreateGraphics();
            g.DrawRectangle(pen, x - 1, y - 1, width + 2, height + 2);

            //Graphics gg = this.CreateGraphics();
            ////  Rectangle r=new Rectangle ();
            //Pen p = new Pen(Brushes.Red,10);

            //gg.DrawRectangle(p, 50, 50, 60, 60);
        }


        private void searchControl1_Click(object sender, EventArgs e)
        {
            
            var name = e.GetType();
        }

        private void UserDefinationClick(object sender, EventArgs e)
        {
            MessageBox.Show("这是用户自定义控件····");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawingRectangle();
        }

        private void TestDemo_Load(object sender, EventArgs e)
        {
            //DrawingRectangle();
        }

        private void TestDemo_Shown(object sender, EventArgs e)
        {
            //DrawingRectangle(); 
            this.A.Text = "aaaa";
            this.B.Text = "BBBB";
        }

        private void A_MouseEnter(object sender, EventArgs e)
        {
            this.A.Text = "";
        }

        private void A_MouseLeave(object sender, EventArgs e)
        {
            if (this.A.Text == "")
                this.A.Text = "aaaa";
        }

        private void B_Enter(object sender, EventArgs e)
        {
            this.B.Text = "";
        }

        private void B_Leave(object sender, EventArgs e)
        {
            if (this.B.Text == "")
                this.B.Text = "BBBB";
        }
    }
}
