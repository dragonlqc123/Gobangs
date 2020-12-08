using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class CheckFind
    {
        private int maxY;
        private int maxX;
        private int minY;
        private int minX;
        private List<GrideView> _grideViews { get; set; }

        public CheckFind(int maxR,int maxC,int minR,int minC,List<GrideView> grideViews)
        {
            this.maxX = maxC;
            this.maxY = maxR;
            this.minX = minC;
            this.minY = minR;
            _grideViews = grideViews;
        }

        public bool Check(Node node,bool isBlanck)
        {
            List<Node> nodes = CheckLeftRight(node, isBlanck);
            if (CheckValid(nodes,isBlanck))
            {
                return true;
            }
            nodes = CheckTopDown(node, isBlanck);
            if (CheckValid(nodes, isBlanck))
            {
                return true;
            }
            nodes = CheckLeft(node, isBlanck);
            if (CheckValid(nodes, isBlanck))
            {
                return true;
            }
            nodes = CheckRight(node, isBlanck);
            if (CheckValid(nodes, isBlanck))
            {
                return true;
            }
            return false;
        }

        public List<Nodes> GetData(Node node, bool? isBlanck)
        {
            List<Nodes> keyValuePairs = new List<Nodes>();

            List<Node> LR = CheckLeftRight(node, isBlanck);
            LR = LR.OrderBy(x=>x.X).ToList();
            keyValuePairs.Add(new Nodes(LR==null?0:LR.Count, Copy(LR), Angle.HENG,this));

            List<Node> TD = CheckTopDown(node, isBlanck);
            TD = TD.OrderBy(x => x.Y).ToList();
            keyValuePairs.Add(new Nodes(TD == null ? 0 : TD.Count, Copy(TD), Angle.SHU,this));

            List < Node > LR_x = CheckLeft(node, isBlanck);
            LR_x = LR_x.OrderBy(x => x.X).ToList();
            keyValuePairs.Add(new Nodes(LR_x == null ? 0 : LR_x.Count, Copy(LR_x), Angle.ZX, this));

            List < Node > RL_x= CheckRight(node, isBlanck);
            RL_x = RL_x.OrderBy(x => x.X).ToList();
            keyValuePairs.Add(new Nodes(RL_x == null ? 0 : RL_x.Count, Copy(RL_x), Angle.YX, this));
            return keyValuePairs;
        }

        /// <summary>
        /// 左右
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private List<Node> CheckLeftRight(Node node, bool? isBlanck)
        {
            List<Node> list = new List<Node>();
            list.Add(node);
            int x = node.X;
            int y = node.Y;
            for (int i = 1; i <= 5; i++)
            {
                if (list.Count == 5)
                {
                    return list;
                }
                // 检查横向（Y）为准
                // 左边
                var view = _grideViews.Where(z => x - i >= minX && z.Node.X == x - i && z.Node.Y == y
                      &&
                      ((z.Node.State == 1 && z.Node.IsBlanck == isBlanck)
                      //|| (z.Node.State == 0 && z.Node.IsBlanck == null)
                      )
                      ).SingleOrDefault();
                if (view == null)
                    break;
                list.Add(view.Node);
            }
            for (int i = 1; i <= 5; i++)
            {
                if (list.Count == 5)
                {
                    return list;
                }
                // 检查横向（Y）为准
                // 右边
                var view = _grideViews.Where(z => x + i <= maxX && z.Node.X == x + i && z.Node.Y == y
                      &&
                              ((z.Node.State == 1 && z.Node.IsBlanck == isBlanck)
                      //|| (z.Node.State == 0 && z.Node.IsBlanck == null)
                      )
                      ).SingleOrDefault();
                if (view == null)
                    break;
                list.Add(view.Node);
            }
            if (list.Count == 5) return list;
            return list;
        }

        /// <summary>
        /// 上下
        /// </summary>
        /// <param name="node"></param>
        /// <param name="isBlanck"></param>
        /// <returns></returns>
        private List<Node> CheckTopDown(Node node, bool? isBlanck)
        {
            List<Node> list = new List<Node>();
            list.Add(node);
            int x = node.X;
            int y = node.Y;
            for (int i = 1; i <= 5; i++)
            {
                if (list.Count == 5)
                {
                    return list;
                }
                // 检查横向（X）为准
                // 上边
                var view = _grideViews.Where(z => y - i >= minY && z.Node.Y == y - i && z.Node.X == x
                      && 
                      ((z.Node.State == 1 && z.Node.IsBlanck == isBlanck)
                      //|| (z.Node.State == 0 && z.Node.IsBlanck == null)
                      )
                      ).SingleOrDefault();
                if (view == null)
                    break;
                list.Add(view.Node);
            }
            for (int i = 1; i <= 5; i++)
            {
                if (list.Count == 5)
                {
                    return list;
                }
                // 检查横向（X）为准
                // 下边
                var view = _grideViews.Where(z => y + i <= maxY && z.Node.Y == y + i && z.Node.X == x
                      &&
                              ((z.Node.State == 1 && z.Node.IsBlanck == isBlanck)
                      //|| (z.Node.State == 0 && z.Node.IsBlanck == null)
                      )
                      ).SingleOrDefault();
                if (view == null)
                    break;
                list.Add(view.Node);
            }
            if (list.Count == 5) return list;
            return list;
        }

        /// <summary>
        /// 左右
        /// </summary>
        /// <param name="node"></param>
        /// <param name="isBlanck"></param>
        /// <returns></returns>
        private List<Node> CheckLeft(Node node, bool? isBlanck)
        {
            List<Node> list = new List<Node>();
            list.Add(node);
            int x = node.X;
            int y = node.Y;
            for (int i = 1; i <= 5; i++)
            {
                if (list.Count == 5)
                {
                    return list;
                }
                // 检查横向（X）为准
                // 左上
                var view = _grideViews.Where(z => y - i >= minY && z.Node.Y == y - i 
                                               && x - i >= minX && z.Node.X == x - i
                                                 &&
                                                        ((z.Node.State == 1 && z.Node.IsBlanck == isBlanck)
                      //|| (z.Node.State == 0 && z.Node.IsBlanck == null)
                      )
                                                 ).SingleOrDefault();
                if (view == null)
                    break;
                list.Add(view.Node);
            }
            for (int i = 1; i <= 5; i++)
            {
                if (list.Count == 5)
                {
                    return list;
                }
                // 检查横向（X）为准
                // 右下
                var view = _grideViews.Where(z => y + i <= maxY && z.Node.Y == y + i 
                                               && x + i <= maxX && z.Node.X == x + i
                                                 &&
                                                 ((z.Node.State == 1 && z.Node.IsBlanck == isBlanck)
                      //|| (z.Node.State == 0 && z.Node.IsBlanck == null)
                      )
                                                 ).SingleOrDefault();
                if (view == null)
                    break;
                list.Add(view.Node);
            }
            if (list.Count == 5) return list;
            return list;
        }

        /// <summary>
        /// 右左
        /// </summary>
        /// <param name="node"></param>
        /// <param name="isBlanck"></param>
        /// <returns></returns>
        private List<Node> CheckRight(Node node, bool? isBlanck)
        {
            List<Node> list = new List<Node>();
            list.Add(node);
            int x = node.X;
            int y = node.Y;
            for (int i = 1; i <= 5; i++)
            {

                if (list.Count == 5)
                {
                    return list;
                }
                // 检查横向（X）为准
                // 左下
                var view = _grideViews.Where(z => y + i <= maxY && z.Node.Y == y + i
                                               && x - i >= minX && z.Node.X == x - i
                                                 &&
                                                          ((z.Node.State == 1 && z.Node.IsBlanck == isBlanck)
                      //|| (z.Node.State == 0 && z.Node.IsBlanck == null)
                      )
                                                 ).SingleOrDefault();
                if (view == null)
                    break;
                list.Add(view.Node);
            }
            for (int i = 1; i <= 5; i++)
            {

                if (list.Count == 5)
                {
                    return list;
                }
                // 检查横向（X）为准
                // 右上方
                var view = _grideViews.Where(z => y - i >= minY && z.Node.Y == y - i
                                               && x + i <= maxX && z.Node.X == x + i
                                               &&
                                                        ((z.Node.State == 1 && z.Node.IsBlanck == isBlanck)
                      //|| (z.Node.State == 0 && z.Node.IsBlanck == null)
                      )
                                               ).SingleOrDefault();
                if (view == null)
                    break;
                list.Add(view.Node);
            }
            if (list.Count == 5) return list;
            return list;
        }


        private bool CheckValid(List<Node> nodes,bool isBlanck)
        {
             nodes =nodes.Where(x => x.State == 1 && x.IsBlanck == isBlanck).ToList();
           
             if (nodes.Count >= 5)
             {
                 return true;
             }
             return false;
        }

        /// <summary>
        /// 检查下一个是否有位置摆放
        /// </summary>
        /// <param name="node"></param>
        /// <param name="position"></param>
        /// <param name="isBlanck"></param>
        /// <returns></returns>
        public bool CheckNextIsNull(Node node, Position position)
        {
            /// 检查下一个是否有位置摆放
            var _node = this.GetNextNode(node, position, null, 0);
            if (_node != null) return true;
            return false;
        }
        public Node GetNextIsNull(Node node, Position position)
        {
            /// 检查下一个是否有位置摆放
            var _node = this.GetNextNode(node, position, null, 0);
            return _node;
        }
        public Node GetNextNode(Node node,Position position, bool? isBlanck, int state)
        {
            GrideView view = null;
            int x = node.X;
            int y = node.Y;
            int i = 1;
            switch (position)
            {
                case Position.T:
                    view = _grideViews.Where(z => y - i >= minY && z.Node.Y == y - i && z.Node.X == x
                      && z.Node.State == state && z.Node.IsBlanck == isBlanck).SingleOrDefault();
                    break;
                case Position.D:
                    view = _grideViews.Where(z => y + i <= maxY && z.Node.Y == y + i && z.Node.X == x
                      && z.Node.State == state && z.Node.IsBlanck == isBlanck).SingleOrDefault();
                    break;
                case Position.L:
                    view = _grideViews.Where(z => x - i >= minX && z.Node.X == x - i && z.Node.Y == y
      && z.Node.State == state && z.Node.IsBlanck == isBlanck).SingleOrDefault();
                    break;
                case Position.R:
                    view = _grideViews.Where(z => x + i <= maxX && z.Node.X == x + i && z.Node.Y == y
                      && z.Node.State == state && z.Node.IsBlanck == isBlanck).SingleOrDefault();
                    break;
                case Position.TL:
                    view = _grideViews.Where(z => y - i >= minY && z.Node.Y == y - i
                                               && x - i >= minX && z.Node.X == x - i
                                                 && z.Node.State == state && z.Node.IsBlanck == isBlanck).SingleOrDefault();
                    break;
                case Position.TR:
                    view = _grideViews.Where(z => y - i >= minY && z.Node.Y == y - i
                                               && x + i <= maxX && z.Node.X == x + i
                                               && z.Node.State == state && z.Node.IsBlanck == isBlanck).SingleOrDefault();
                    break;
                case Position.DL:
                    view = _grideViews.Where(z => y + i <= maxY && z.Node.Y == y + i
                                               && x - i >= minX && z.Node.X == x - i
                                                 && z.Node.State == state && z.Node.IsBlanck == isBlanck).SingleOrDefault();
       

                    break;
                case Position.DR:
                    view = _grideViews.Where(z => y + i <= maxY && z.Node.Y == y + i
                                               && x + i <= maxX && z.Node.X == x + i
                                                 && z.Node.State == state && z.Node.IsBlanck == isBlanck).SingleOrDefault();
                    break;
            }
            if(view!=null)
                return view.Node.Copy();
            return null;
        }

        public List<Node> GetAllNodes(int state,bool? isBlanck)
        {
            var views = _grideViews.Where(z=>z.Node.State == state && z.Node.IsBlanck == isBlanck).ToList();
            if (views != null && views.Count > 0)
            {
                List<Node> _ls = views.Select(x => x.Node).ToList();
                return this.Copy(_ls); 
            }
            
            return null;
            
        }

        public Node GetNode(Node node)
        {
            int x = node.X;
            int y = node.Y;
            int state = node.State;
            bool? isBlanck = node.IsBlanck;
            var view = _grideViews.Where(z =>z.Node.Y == y && z.Node.X == x
                     && z.Node.State == state && z.Node.IsBlanck == isBlanck).SingleOrDefault();
            if(view!=null)
                return view.Node.Copy();
            return null;
        }
        public CheckFind Copy()
        {
           int maxCc =this.maxX;
           int maxRc =this.maxY;
           int minCc= this.minX;
           int minRc =this.minY;
            List<GrideView> grideViewsc = this.Copy(this._grideViews);
                //new List<GrideView>();
            //foreach (var _v in this._grideViews)
            //{
            //    grideViewsc.Add(_v.Copy());
            //}
            CheckFind checkFind = new CheckFind( maxRc,  maxCc,  minRc,  minCc,grideViewsc);
            return checkFind;
        }

        private List<GrideView> Copy(List<GrideView> grideViews)
        {
            List<GrideView> grideViewsc = new List<GrideView>();
            foreach (var _v in grideViews)
            {
                grideViewsc.Add(_v.Copy());
            }
            return grideViewsc;
        }
        private List<Node> Copy(List<Node> nodes)
        {
            List<Node> _nodes = new List<Node>();
            foreach (var _n in nodes)
            {
                _nodes.Add(_n.Copy());
            }
            return _nodes;
        }

        public bool SimulateSetState(bool isBlanck,int state, Node node)
        {
            if (node == null) return false;
           GrideView _view = _grideViews.Where(x => x.Node.cpoint.X == node.cpoint.X && x.Node.cpoint.Y == node.cpoint.Y).SingleOrDefault();
            if (_view != null)
            {
                return _view.Node.SetState(isBlanck, state);
            }
            return false; 
        }
    }


}
