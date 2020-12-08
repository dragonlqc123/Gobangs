using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Chessboard 
    {
        private LayoutNode LayoutNodes = new LayoutNode();
        private Context context = null;
        private DrawTool drawTool = null;
        public Node CreateChessBoard(int[] xs, int[] ys,
            System.Windows.Forms.Control control,bool isBlanck)
        {
            drawTool = new DrawTool(control);
            for (int i = 0; i < xs.Length; i++)
            {
                if (xs[i] == 0) continue;
                for (int j = 0; j < ys.Length; j++)
                {
                    if (ys[j] == 0) continue;
                    LayoutNodes.Create(j, i, xs[i], ys[j], drawTool);
                }
            }

           LayoutNodes.ShengCheng();
            context = new Context(LayoutNodes, new User(LayoutNodes));
            return LayoutNodes.CenterNode;

        }
        public ReturnInfo AddNode(int state, int x, int y,int qz)
        {
            return context.Next(state, x, y,qz);
        }
    }
}
