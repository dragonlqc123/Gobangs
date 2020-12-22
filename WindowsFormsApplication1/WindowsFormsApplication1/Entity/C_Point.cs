using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.RectangleNew.Rectangles;

namespace WindowsFormsApplication1.delete
{

    public class C_Point: IRectangleModel<string>
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
        public string _L => (X-Margin)+","+Y;

        public string _R => (X + Margin) + "," + Y;

        public string _U => X + "," + (Y-Margin);

        public string _D => X + "," + (Y + Margin);

        public string _L_LU => (X-Margin) + "," + (Y - Margin);

        public string _L_RD => (X + Margin) + "," + (Y + Margin);

        public string _R_RU => (X + Margin) + "," + (Y - Margin);

        public string _R_LD => (X - Margin) + "," + (Y + Margin);


        #endregion

        public override string ToString()
        {
            return "X="+X+",Y="+Y;
        }


        public C_Point Copy()
        {
            C_Point c_Point = new C_Point(this.X, this.Y);
            c_Point.GridView = this.GridView.Copy();
            return c_Point;
        }

        /// <summary>
        /// 根据颜色查找，并且有值或者为空
        /// </summary>
        /// <param name="conditionType"></param>
        /// <returns></returns>
        public bool SerchNode(object senderArgs)
        {
            if (this.GridView.Node.IsBlanck == null || this.GridView.Node.IsBlanck == Boolean.Parse(senderArgs.ToString()))
                return true;
            else return false;
            throw new NotImplementedException();
        }
        public string ToIdentification(object senderArgs)
        {
            if (this.GridView.Node.IsBlanck == null)
                return "+";
            else if (this.GridView.Node.IsBlanck == Boolean.Parse(senderArgs.ToString()))
                return "O";
         
            return "-1";
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
