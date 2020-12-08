using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

    public class C_Point
    {

        public GrideView GridView { get; set; }

        public System.Drawing.PointF PointF { get; set; }

        public C_Point(int r, int c, int x, int y, DrawTool drawTool)
        {
            this.X = x;
            this.Y = y;
            PointF = new System.Drawing.PointF(x, y);
            GridView = new GrideView(r, c, x, y, drawTool);
        }

        public int X { get; set; }
        public int Y { get; set; }


    }
}
