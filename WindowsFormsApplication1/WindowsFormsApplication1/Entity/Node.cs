using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{

    public class Node
    {
        public CPoint cpoint = null;
        private DrawTool drawTool;
        public Node(int x,int y, DrawTool drawTool)
        {
            this.drawTool = drawTool;
            cpoint = new CPoint(x,y,drawTool);
        }


        public string ID { get { return this.X + "" + this.Y; } }

        public int X { get; set; }
        public int Y { get; set; }

        public bool IsCentre { get; set; }


        public bool? IsBlanck = null;


        /// <summary>
        /// 0:默认；1：选中
        /// </summary>
        public int State { get; set; }

        public void SetNodeX(int x)
        {
            if (this.IsCentre)
                this.X = 0;
            else
                this.X = x;
        }

        public void SetNodeY(int y)
        {
            if (this.IsCentre)
                this.Y = 0;
            else
                this.Y = y;
        }

        public bool SetState(bool isBlanck, int state)
        {
            if (this.State == 0)
            {
                this.IsBlanck = isBlanck;
                this.State = state;
                return true;
            }
            return false;
        }

        //public List<Nodes> NodeList { get; set; }
        public decimal Rate { get; internal set; }

        public string RateText { get; set; }
        public Angle Angle { get; internal set; }

        internal Node Copy()
        {
            Node node = new Node(this.cpoint.X,this.cpoint.Y,this.drawTool);
            node.X = this.X;
            node.Y = this.Y;
            node.IsCentre =this.IsCentre;
            node.IsBlanck = this.IsBlanck;
            node.State = this.State;
            node.Rate = this.Rate;
            return node;
        }

        public void ShowInfo(int newLine)
        {
            drawTool.ShowPoint("X=" + this.X + ";Y=" + this.Y, this.cpoint.X,this.cpoint.Y, newLine);
        }
    }

}
