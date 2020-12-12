using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

    public class GrideView
    {


        private DrawTool drawTool;

        public GrideView(int r, int c, int x, int y, DrawTool drawTool)
        {
            this.Row = r;
            this.Cl = c;
            Node = new Node(x, y, drawTool);
            this.drawTool = drawTool;
        }
        private GrideView()
        {
            
        }


        public int Cl { get; set; }
        public int Row { get; set; }

        public Node Node { get; set; }

        #region 
        public Node SetCenter()
        {
            Node.IsCentre = true;
            return Node;
        }
        
        public void SetNodeX(int x)
        {
            Node.SetNodeX(x);
        }

        public void SetNodeY(int y)
        {
            Node.SetNodeY(y);
        }

        public void SetNode(int x, int y)
        {
            Node.SetNodeX(x);
            Node.SetNodeY(y);
            ShowAll();
        }

        public void ShowInfo(int newLine)
        {
            drawTool.ShowPoint("R=" + Row + ";C=" + Cl, this.Node.cpoint.X,this.Node.cpoint.Y, newLine);
        }

        public void ShowAll()
        {
            this.ShowInfo(0);
            this.Node.ShowInfo(1);
            this.Node.cpoint.ShowInfo(2);
        }

        public GrideView Copy()
        {
            GrideView _news = new GrideView();
            _news.Cl = this.Cl;
            _news.Row = this.Row;
            _news.Node = this.Node.Copy();
            _news.drawTool = this.drawTool;
            return _news;
        }

        #endregion
    }

}
