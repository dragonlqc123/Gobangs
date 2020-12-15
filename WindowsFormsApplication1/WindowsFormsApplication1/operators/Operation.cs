using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public abstract class Operation
    {
        private bool isBlanck;
        private LayoutNode layoutNodes;
        protected DrawTool drawTool;
        public Operation(bool isBlanck, LayoutNode layoutNodes)
        {
            this.isBlanck = isBlanck;
            this.layoutNodes = layoutNodes;
            this.drawTool = layoutNodes.DrawTool;
        }

        public bool IsBlanck { get => isBlanck; }
        public LayoutNode LayoutNodes { get => layoutNodes; }

        protected Node SetState(int state, int x, int y,int qz)
        {
            var node = LayoutNodes[x + "," + y];
            bool falg = node.SetState(isBlanck, state);
            if(falg) drawTool.DrawPiece(x, y,qz,isBlanck);
            return node;
        }

        public bool Check(int state, int x, int y, int qz)
        {
            Node node = this.SetState(state, x,y,qz);
            return layoutNodes.CheckFind.Check(node, isBlanck);
        }

        /// <summary>
        /// 下一步
        /// </summary>
        /// <param name="context"></param>
        public abstract Operation Next(Context context);

        public ReturnInfo GetReturn(bool falg)
        {
            if (isBlanck) return new ReturnInfo(falg, "黑方");
            else return new ReturnInfo(falg, "白方");
        }
        public virtual Node Defense(int x, int y,Context context,int qz) { return null; }
        
    }
}
