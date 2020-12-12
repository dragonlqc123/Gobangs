using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public class LayoutNode
    {
        private DrawTool _drawTool = null;
        

        public LayoutNode()
        {
            _grideViews = new List<GrideView>();
            _c_Points = new Dictionary<string, C_Point>();
        }

        private List<GrideView> _grideViews { get; set; }

        private Dictionary<string,C_Point> _c_Points { get; set; }

        public CheckFind CheckFind { get; set; }
        public DrawTool DrawTool { get => _drawTool; }

        public Node CenterNode = null;

        private int maxRow = 0;
        private int maxCl = 0;
   
        //private int minRow = 0;
        //private int minCl = 0;
        #region 
        /// <summary>
        /// 创建
        /// </summary>
        public C_Point Create(int r,int c,int x,int y, DrawTool drawTool)
        {
            this._drawTool = drawTool;
            C_Point c_Point = new C_Point(r, c, x, y, drawTool);
            if (!_c_Points.ContainsKey(x + "" + y))
            {
                _c_Points.Add(x + "" + y, c_Point);
            }
            else
            {
                MessageBox.Show(x + "" + y);
            }
            _grideViews.Add(c_Point.GridView);
            return c_Point;
        }
        
        public void ShengCheng()
        {
            
            var rows = _grideViews.OrderByDescending(x => x.Row).ToList();
            var cls = _grideViews.OrderByDescending(x => x.Cl).ToList();
            maxRow = rows[0].Row;
            maxCl = cls[0].Cl;
            int center = (maxRow - maxRow % 2) / 2;
            int centerCl = (maxCl - maxCl % 2) / 2;
            var _view = _grideViews.Where(x => x.Row == center && x.Cl == centerCl).SingleOrDefault();
            CenterNode = _view.Node;
            _view.SetCenter();
           /// 生成节点
            for (int i = _view.Cl; i >= 0; i--)
            {
                for (int j = _view.Row; j >= 0; j--)
                {
                    var _v = _grideViews.Where(x => x.Row == j && x.Cl == i).SingleOrDefault();
                    _v.SetNode(i - _view.Cl, j - _view.Row);
                }

                for (int j = _view.Row; j <= maxRow; j++)
                {
                    var _v = _grideViews.Where(x => x.Row == j && x.Cl == i).SingleOrDefault();
                    _v.SetNode(i - _view.Cl, j - _view.Row);
                }
            }
            for (int i = _view.Cl; i <= maxCl; i++)
            {
                for (int j = _view.Row; j >= 0; j--)
                {
                    var _v = _grideViews.Where(x => x.Row == j && x.Cl == i).SingleOrDefault();
                    _v.SetNode(i - _view.Cl, j - _view.Row);
                }
                for (int j = _view.Row; j <= maxRow; j++)
                {
                    var _v = _grideViews.Where(x => x.Row == j && x.Cl == i).SingleOrDefault();
                    _v.SetNode(i - _view.Cl, j - _view.Row);
                }
            }

            var nodeMaxR = _grideViews.OrderByDescending(x => x.Node.Y).ToList();
            var nodeMaxC = _grideViews.OrderByDescending(x => x.Node.X).ToList();


            var nodeMinR = _grideViews.OrderBy(x => x.Node.Y).ToList();
            var nodeMinC = _grideViews.OrderBy(x => x.Node.X).ToList();

            CheckFind = new CheckFind(nodeMaxR[0].Node.Y, nodeMaxC[0].Node.X, nodeMinR[0].Node.Y, nodeMinC[0].Node.X, _grideViews);
             test = new RectangleNew.TestDemo(10000, _c_Points);
        }
        RectangleNew.TestDemo test;
        public Node this[string key]
        {
            get
            {
                var _a = test[key];
                if (_c_Points.ContainsKey(key))
                    return _c_Points[key].GridView.Node;
                return null;
            }
        }
        #endregion
    }
}
