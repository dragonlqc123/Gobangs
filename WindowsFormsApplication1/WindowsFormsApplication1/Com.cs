using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{

    /// <summary>
    /// 该类定义了棋盘的一些属性
    /// </summary>
    public class chessboard
    {
        Chessboard boards = null;
        #region 属性

        private int cbRowCount;
        /// <summary>
        /// 棋盘的行数
        /// </summary>
        public int CbRowCount
        {
            get { return cbRowCount; }
            set { cbRowCount = value; }
        }

        private int cbColCount;
        /// <summary>
        /// 棋盘的列数
        /// </summary>
        public int CbColCount
        {
            get { return cbColCount; }
            set { cbColCount = value; }
        }
        

        private int leftMargin;
        /// <summary>
        /// 棋盘左边距
        /// </summary>
        public int LeftMargin
        {
            get { return leftMargin; }
            set { leftMargin = value; }
        }

        private int topMargin;
        /// <summary>
        /// 棋盘右边距
        /// </summary>
        public int TopMargin
        {
            get { return topMargin; }
            set { topMargin = value; }
        }

        private int endMaxX;
        /// <summary>
        /// 棋盘在窗体中的结束位置[X]
        /// </summary>
        public int EndMaxX
        {
            get { return endMaxX; }
            set { endMaxX = value; }
        }
       
        private int endMaxY;
        /// <summary>
        /// 棋盘在窗体中的结束位置[Y]
        /// </summary>
        public int EndMaxY
        {
            get { return endMaxY; }
            set { endMaxY = value; }
        }

       
        private int[] cbXzb = new int[100];
        /// <summary>
        /// 存储棋盘X交叉点的位置
        /// </summary>
        public int[] CbXzb
        {
            get { return cbXzb; }
            set { cbXzb = value; }
        }

        private int[] cbYzb = new int[100];
        /// <summary>
        /// 存储棋盘Y交叉点的位置
        /// </summary>
        public int[] CbYzb
        {
            get { return cbYzb; }
            set { cbYzb = value; }
        }

        private int chessManRaii;

        /// <summary>
        /// 棋子半径
        /// </summary>
        public int ChessManRaii
        {
            get { return chessManRaii; }
            set { chessManRaii = value; }
        }

        private int cbCell;

        /// <summary>
        /// 棋盘的单元格
        /// </summary>
        public int CbCell
        {
            get { return cbCell; }
            set { cbCell = value; }
        }

        private int[,] cbXYzb = new int[100,100];

        /// <summary>
        /// 数组存棋子的坐标
        /// </summary>
        public int[,] CbXYzb
        {
          get { return cbXYzb; }
          set { cbXYzb = value; }
        }

        private int cbXYzbCount;

        /// <summary>
        /// 存棋子数组的长度
        /// </summary>
        public int CbXYzbCount
        {
            get { return cbXYzbCount; }
            set { cbXYzbCount = value; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public chessboard()
        {

        }
        public chessboard(int row,int cl)
        {
            this.CbXzb = new int[cl];
            this.CbYzb = new int[row];
            this.CbColCount = cl;
            this.CbRowCount = row;
        }
        #endregion

        #region 方法

        /// <summary>
        /// 获取X的标准坐标
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int GetXzb(int x)
        {
            for (int i = 0; i < this.CbColCount; i++)
            {
                if (this.CbXzb[i] - this.cbCell * 0.6 < x && this.CbXzb[i] + this.cbCell * 0.6 > x)
                {
                    x = this.CbXzb[i];
                    return x;
                }
            }
            return this.CbXzb[this.CbColCount]; 
        }

        /// <summary>
        /// 获取Y的标准坐标
        /// </summary>
        /// <returns></returns>
        public int GetYzb(int y)
        {
            for (int i = 0; i < this.CbRowCount; i++)
            {
                if (this.CbYzb[i] - this.cbCell * 0.6 < y && this.CbYzb[i] + this.cbCell * 0.6 > y)
                {
                    y = this.CbYzb[i];
                    return y;
                }
            }
            return this.CbYzb[this.CbRowCount]; 
        }

        /// <summary>
        /// 检查哪方胜利
        /// </summary>
        /// <returns></returns>
        //public bool CheckSuccee(Node node)
        //{
        //    return boards.Check(node, true);
        //}

       

        private int i = 0;
        private int j = 0;
        /// <summary>
        /// 添加坐标
        /// </summary>
        public Node Addzb(int x,int y)
        {
            for (int k = i; k <= i; k++)
            {
                for (int b = j; b < j + 2; b++)
                {
                    this.CbXYzb[i, j] = x;
                    this.CbXYzb[i, j + 1] = y;
                }
            }
            i++;

            //return boards.SetState(true,1,x,y);
            return null;
        }

        public ReturnInfo AddzbNew(int x, int y,int qz)
        {
            return boards.AddNode(1, x, y, qz);
        }
        /// <summary>
        /// 检查数组是否存在,存在false,不存在true
        /// </summary>
        /// <returns></returns>
        public bool CheckIsNot(int x, int y)
        {
            for (int k = i; k <= i; k++)
            {
                for (int b = j; b < j + 2; b++)
                {
                    if (this.CbXYzb[i, j] == x && this.CbXYzb[i, j + 1] == y)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

        public Node Create(System.Windows.Forms.Control control)
        {
            boards = new Chessboard();
            return boards.CreateChessBoard(this.CbXzb, this.cbYzb, control,false);
        }

    }
}
