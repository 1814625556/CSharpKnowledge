using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormTest.UIControls
{
    public partial class RoundTxtBox : UserControl
    {
        public RoundTxtBox()
        {
            InitializeComponent();
        }

        public string InnerText {
            get { return this.InnerTextbox.Text; }
            set { this.InnerTextbox.Text = value; }
        }

        private void DrawLines()
        {

            //ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle,
            //    borderColor, 2, ButtonBorderStyle.Solid,// 左
            //    borderColor, 2, ButtonBorderStyle.Solid,//上
            //    borderColor, 2, ButtonBorderStyle.Solid,//右
            //    borderColor, 2, ButtonBorderStyle.Solid);//下
            //var pen = new Pen(Color.Red, 1);
            //pen.DashStyle = DashStyle.Solid;
            //pen.
        }

        private void RoundTxtBox_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle,
                Color.Red, 1, ButtonBorderStyle.Solid,// 左
                Color.Red, 1, ButtonBorderStyle.Solid,//上
                Color.Red, 1, ButtonBorderStyle.Solid,//右
                Color.Red, 1, ButtonBorderStyle.Solid);//下
            //var pen1 = new Pen(Color.Red, 1);
            //pen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            //pen1.DashPattern = new float[] { 4f, 2f };
            //e.Graphics.DrawRectangle(pen1, 0, 0, this.Width-4, this.Height - 1);
        }
    }
}
