using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class DrawTool
    {
        private Control control;
        //private bool isBlanck;, bool isBlanck

        public DrawTool(Control control)
        {
            Control = control;
            //this.isBlanck = isBlanck;
        }

        public Control Control { get => control; set => control = value; }

        /// <summary>
        /// 画圆
        /// </summary>
        /// <param name="x">圆的X坐标</param>
        /// <param name="y">圆的Y坐标</param>
        /// <param name="radii">圆的半径</param>
        public void DrawPiece(int x, int y,int radii, bool isBlanck)
        {
            Graphics g = Control.CreateGraphics();
            Brush b = (isBlanck?Brushes.Black:Brushes.White);
            Rectangle rectangle = new Rectangle(x - radii, y - radii, radii * 2, radii * 2);
            g.FillEllipse(b, rectangle);
        }
        public void ShowPoint(string info,Node node,int i)
        {
            var g = control.CreateGraphics();
            Brush b = Brushes.White;
            Font myFont = new Font("Verdana", 10);
            g.DrawString(info, myFont, b, node.cpoint.GetNewLine(i));
        }

        public void ShowPoint(string info, int x, int y, int i)
        {
            var g = control.CreateGraphics();
            Brush b = Brushes.White;
            Font myFont = new Font("Verdana", 10);
            g.DrawString(info, myFont, b, new System.Drawing.PointF(x, y + 15 * i));
        }
    }
}
