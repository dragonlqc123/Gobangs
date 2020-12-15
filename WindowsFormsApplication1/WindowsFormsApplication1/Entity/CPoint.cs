using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1 
{
    public class CPoint
    {
        private DrawTool drawTool;
        public System.Drawing.PointF PointF { get; set; }

        public CPoint(int x, int y, DrawTool drawTool)
        {
            try

            {
                this.X = x;
                this.Y = y;
                PointF = new System.Drawing.PointF(x, y);
                this.drawTool = drawTool;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int X { get; set; }
        public int Y { get; set; }

        public System.Drawing.PointF GetNewLine()
        {
            return new System.Drawing.PointF(X, Y + 15);
        }

        public System.Drawing.PointF GetNewLine(int i)
        {
            return new System.Drawing.PointF(X, Y + 15*i);
        }

        public void ShowInfo(int newLine)
        {
            drawTool.ShowPoint("X=" + this.X + ";Y=" + this.Y, this.X, this.Y, newLine);
        }
    }

}
