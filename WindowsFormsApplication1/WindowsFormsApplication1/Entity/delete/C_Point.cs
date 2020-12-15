using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.RectangleNew.Rectangles;

namespace WindowsFormsApplication1
{

    public class C_Point: RectangleNew.Rectangles.EntityData<string> //RectangleNew.Rectangles.IRectangleModel<string,C_Point>
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
        private C_Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
            PointF = new System.Drawing.PointF(x, y);
        }
        public int X { get; set; }
        public int Y { get; set; }


        #region 
        public override string _L => (X-Margin)+","+Y;

        public override string _R => (X + Margin) + "," + Y;

        public override string _U => X + "," + (Y-Margin);

        public override string _D => X + "," + (Y + Margin);

        public override string _L_LU => (X-Margin) + "," + (Y - Margin);

        public override string _L_RD => (X + Margin) + "," + (Y + Margin);

        public override string _R_RU => (X + Margin) + "," + (Y - Margin);

        public override string _R_LD => (X - Margin) + "," + (Y + Margin);


        #endregion

        public override string ToString()
        {
            return "X="+X+",Y="+Y;
        }

        /// <summary>
        /// 根据颜色查找，并且有值或者为空
        /// </summary>
        /// <param name="conditionType"></param>
        /// <returns></returns>
        public override bool SerchNode(object conditionType)
        {
            return true;
            throw new NotImplementedException();
        }

        //public override C_Point Copy()
        //{
        //    C_Point c_Point = new C_Point(this.X, this.Y);
        //    c_Point.GridView = this.GridView.Copy();
        //    return c_Point;
        //    throw new NotImplementedException();
        //}

        public override EntityData<string> Copy()
        {
            C_Point c_Point = new C_Point(this.X, this.Y);
            c_Point.GridView = this.GridView.Copy();
            return c_Point;
            throw new NotImplementedException();
        }
        //public override C_Point Copy()
        //{
        //    C_Point c_Point = new C_Point(this.X,this.Y);
        //    c_Point.GridView = this.GridView.Copy();
        //    return c_Point;
        //    throw new NotImplementedException();
        //}
    }
}
