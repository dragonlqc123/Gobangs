using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

    public class C_Point:RectangleNew.Rectangles.IRectangleModel<string>
    {
        private const int Margin = 100;
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


        #region 
        public string _L => (X-Margin)+""+Y;

        public string _R => (X + Margin) + "" + Y;

        public string _U => X + "" + (Y-Margin);

        public string _D => X + "" + (Y + Margin);

        public string _L_LU => (X-Margin) + "" + (Y - Margin);

        public string _L_RD => (X + Margin) + "" + (Y + Margin);

        public string _R_RU => (X + Margin) + "" + (Y - Margin);

        public string _R_LD => (X - Margin) + "" + (Y + Margin);


        #endregion

        public override string ToString()
        {
            return "X="+X+",Y="+Y;
        }

    }
}
