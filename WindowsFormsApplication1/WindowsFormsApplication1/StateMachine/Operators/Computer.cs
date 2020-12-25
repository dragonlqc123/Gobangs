using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Computer : Operation
    {
        //private Analysis analysis;
        private Node CurentNode;
        public Computer(LayoutNode layoutNodes) : base(true, layoutNodes)
        {
        }
        
        public override Operation Next(Context context)
        {
            return context.user;
        }

        public override Node Defense(int x, int y, Context context, int qz)
        {
            //var node = LayoutNodes[x + "," + y];
            //analysis = new Analysis(LayoutNodes.CheckFind.Copy(), node, !base.IsBlanck);
            //Analysis analysis1 = new Analysis(LayoutNodes.CheckFind.Copy(), CurentNode, base.IsBlanck);
            //Contrast Contrast = new Contrast(analysis, analysis1);
            //var _node = Contrast.ContrastFX();
            //if (_node == null)
            //{
            //    Nodes nodes = Analysis.AnalysisData(IsBlanck, LayoutNodes.CheckFind.Copy(), false);
            //    if (nodes != null)
            //    {
            //        _node = nodes.NextNode;
            //        if (_node == null)
            //        {
            //            _node = analysis1.GetDefautNode(node);
            //        }
            //    }
            //    else
            //        _node = analysis1.GetDefautNode(node);
            //}
            var _node = LayoutNodes.test.AttackorDefense(base.IsBlanck,!base.IsBlanck, x + "," + y).GridView.Node;
            if (_node != null)
            {
                CurentNode = SetState(1, _node.cpoint.X, _node.cpoint.Y, qz);
                //drawTool.ShowPoint("" + CurentNode.RateText, CurentNode, 1);
                //CurentNode.ShowInfo(2);
                //CurentNode.cpoint.ShowInfo(3);
                return CurentNode;
            }
            return null;
        }

        
    }
}
