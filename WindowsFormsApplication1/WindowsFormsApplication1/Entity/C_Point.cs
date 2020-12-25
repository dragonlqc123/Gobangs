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
        public override string _L => (X- CheckerboardConfig.Margin) +","+Y;

        public override string _R => (X + CheckerboardConfig.Margin) + "," + Y;

        public override string _U => X + "," + (Y- CheckerboardConfig.Margin);

        public override string _D => X + "," + (Y + CheckerboardConfig.Margin);

        public override string _L_LU => (X- CheckerboardConfig.Margin) + "," + (Y - CheckerboardConfig.Margin);

        public override string _L_RD => (X + CheckerboardConfig.Margin) + "," + (Y + CheckerboardConfig.Margin);

        public override string _R_RU => (X + CheckerboardConfig.Margin) + "," + (Y - CheckerboardConfig.Margin);

        public override string _R_LD => (X - CheckerboardConfig.Margin) + "," + (Y + CheckerboardConfig.Margin);


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
        public override bool SerchNode(object senderArgs)
        {
            if ((this.GridView.Node.IsBlanck == null || this.GridView.Node.IsBlanck == Boolean.Parse(senderArgs.ToString()))
                && !IsIllegalSymbol(senderArgs))
                return true;
            else return false;
            throw new NotImplementedException();
        }

        public override string ToIdentification(object senderArgs)
        {
            if (this.GridView.Node.IsBlanck == null)
                return EmptySymbol();
            else if (this.GridView.Node.IsBlanck == Boolean.Parse(senderArgs.ToString()))
                return Symbol();
            return IllegalSymbol();
        }

       

        public override EntityData<string> Copy()
        {
            C_Point c_Point = new C_Point(this.X, this.Y);
            c_Point.GridView = this.GridView.Copy();
            return c_Point;
            throw new NotImplementedException();
        }

        public override string Symbol()
        {
            return "O";
        }

        public override bool IsIllegalSymbol(object senderArgs)
        {
            return this.ToIdentification(senderArgs) == IllegalSymbol();
        }

        public override string EmptySymbol()
        {
            return "+";
        }

        public override string IllegalSymbol()
        {
            return "$";
        }

        public override int MaxCount()
        {
            return 6;
        }
    }
}
