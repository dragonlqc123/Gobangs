using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        // 成员
        /// <summary>
        /// 棋盘类
        /// </summary>
        private chessboard cb = new chessboard();
        Graphics g = null;
        Graphics graphics = null;
        Rectangle rectangle;
        /// <summary>
        /// 鼠标X坐标
        /// </summary>
        int x = 0;
        /// <summary>
        /// 鼠标Y坐标
        /// </summary>
        int y = 0;
        /// <summary>
        /// 开始状态
        /// </summary>
        bool beginState = false;

        /// <summary>
        /// 棋盘初始大小
        /// </summary>
        
        private int hw = CheckerboardConfig.Margin;

        /// <summary>
        /// 棋子大小
        /// </summary>
       
        private int qz = CheckerboardConfig.Piece;

        #region 

        /// <summary>
        /// 构造方法
        /// </summary>
       
        public Form2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region 画图方法

        /// <summary>
        /// 画圆
        /// </summary>
        /// <param name="x">圆的X坐标</param>
        /// <param name="y">圆的Y坐标</param>
        /// <param name="radii">圆的半径</param>
        
        private void DrawRund(int x, int y,int radii)
        {
            g = this.CreateGraphics();
            SolidBrush s = new SolidBrush(Color.Blue);
            int k = radii*2;
            //double b = System.Math.Sqrt(k * k + k * k);
            //double e = b / 2;
            Rectangle r = new Rectangle(Convert.ToInt32(x - radii), Convert.ToInt32(y - radii), k, k);
            g.FillPie(s, r, 0, 360);
        }

        /// <summary>
        /// 画圆
        /// </summary>
        /// <param name="x">圆的X坐标</param>
        /// <param name="y">圆的Y坐标</param>
        /// <param name="radii">圆的半径</param>
        private void drawImage(int x, int y,int radii)
        {
            g = this.CreateGraphics();
            Brush b = Brushes.Black;
            rectangle = new Rectangle(x - radii, y - radii, radii * 2, radii * 2);
            //rectangle = new Rectangle(x , y, radii * 2, radii * 2);
            g.FillEllipse(b, rectangle);
        } 

        /// <summary>
        /// 画棋盘
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="cellWidth"></param>
        
        private void DrawLine(int FcellWidth)
        {
            /// 行边距
            int rolMarginWidth = CheckerboardConfig.RolMarginWidth;
            /// 列边距
            int colMarginWidth = CheckerboardConfig.ColMarginWidth;
            ////////////////////////////////

            int cellWidth = cb.CbCell = FcellWidth;

            if (cellWidth == 0)
            {
                cellWidth = 50;
            }
            ////////////////////////////////
            g = this.CreateGraphics();
            Brush b = Brushes.Black;
            Pen p = new Pen(b, 2);

            /////////////////////////////////////////////////////////////////
            /// 列数
            int colCount = (this.Width - rolMarginWidth*2 - 15) / cellWidth;
            /// 棋盘宽度
            int endFwidth = (this.Width - rolMarginWidth*2 - 15) / cellWidth * cellWidth;
            /// 棋盘与窗体的[左右]边距
            rolMarginWidth += ((this.Width - rolMarginWidth*2 - 15) - endFwidth) / 2;

            /////////////////////////////////////////////////////////////////
            /// 行数
            int rolCount = (this.Height - colMarginWidth*2 - 15) / cellWidth;
            /// 棋盘高度
            int endFheight = (this.Height - colMarginWidth * 2 - 15) / cellWidth * cellWidth;
            /// 棋盘与窗体的[上下]边距
            colMarginWidth += ((this.Height - colMarginWidth * 2 - 15) - endFheight) / 2;

            ///* 添加棋盘属性 *///
            //cb = new chessboard(rolCount,colCount);
            cb.CbColCount = colCount;
            cb.CbRowCount = rolCount;
            cb.LeftMargin = rolMarginWidth;
            cb.TopMargin = colMarginWidth;
           
            /////////////////////////////////////////////////////////////////
            int ooo = 0;
            /// 画行
            for (int i = colMarginWidth,j=0; i <= endFheight + colMarginWidth + 1; i += cellWidth,j++)
            {
                Point p1;
                Point p2;
                p1 = new Point(rolMarginWidth, i);
                p2 = new Point(endFwidth+rolMarginWidth, i);
                g.DrawLine(p, p1, p2);
                ooo = i;
                ///* 添加棋盘属性 *///
                cb.CbYzb[j] = i;
            }

            cb.EndMaxX = endFwidth + rolMarginWidth;
            cb.EndMaxY = ooo;
            //////////////////////////////////////////////////////////////////

            /// 画列
            for (int i = rolMarginWidth,j=0; i <= endFwidth + rolMarginWidth; i += cellWidth,j++)
            {
                Point p4;
                Point p3;
                p3 = new Point(i, colMarginWidth);
                p4 = new Point(i, ooo);
                g.DrawLine(p, p3, p4);
                /// 添加棋盘X坐标到数组
                cb.CbXzb[j] = i;
            }

            Node node = cb.Create(this);
            drawImage(node.cpoint.X,node.cpoint.Y,5);
        }

        #endregion

        #region 事件处理

        /// <summary>
        /// 鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            // DrawRund(x, y, 75);
            //DrawLine(50);
            if (e != null)
            {
                if (e.Button == MouseButtons.Left && beginState)
                {
                    /// 鼠标范围[也可以说是下棋的范围或棋盘的范围]
                    if (e.X >= cb.LeftMargin && e.X <= cb.EndMaxX && e.Y >= cb.TopMargin && e.Y <= cb.EndMaxY)
                    {
                        x = cb.GetXzb(x);
                        y = cb.GetYzb(y);
                        /// 检查数组是否存在,存在false,不存在true
                        if (cb.CheckIsNot(x, y))
                        {
                            ReturnInfo info = cb.AddzbNew(x, y, qz);
                            if (info.IsSucces)
                            {
                                MessageBox.Show(info.Info + "胜利！  ", "胜利", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                button1_Click(sender, e);
                            }
                        }
                }
                }
            }
        }

        /// <summary>
        /// 鼠标移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
           this.Text = "X: "+(x = e.X).ToString();
           this.Text += " Y: "+(y = e.Y).ToString();
        }

        /// <summary>
        /// 当需要重绘时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
      
        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            g = graphics;
        }

        #endregion

        #region 操作

        /// <summary>
        /// 开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //cb = new chessboard();
            btnBig.Enabled = true;
            beginState = true;
            g = this.CreateGraphics();
            g.Clear(Color.DarkGreen);
            DrawLine(hw);
        }

        /// <summary>
        /// 放大棋盘
        /// <summary>
        private void btnBig_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            Button btnName = (Button)sender;
            if (btnName.Name == "btnBig")
            {
                if (hw < 999)
                {
                    hw++;
                }
                else
                {
                    g = this.CreateGraphics();
                    MessageBox.Show("已是最大棋盘!","警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                if (hw > 2)
                {
                    hw--;
                }
                else
                {
                    g = this.CreateGraphics();
                    MessageBox.Show("已是最小棋盘!","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
            }
            beginState = true;
            g.Clear(Color.DarkGreen);
            DrawLine(hw);
            setQz();
        }

        #endregion

        #region 方法

        /// <summary>
        /// 设置棋子大小
        /// </summary>
        private void setQz()
        {
            qz = cb.ChessManRaii = hw / 2;
        }

        
        #endregion

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}
