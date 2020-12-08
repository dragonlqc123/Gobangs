using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Analysis
    {
        private CheckFind checkFind;
        private Node node;
        private bool isBlanck;
        public List<Nodes> NodesGridView { get; set; }
        public decimal SuccessRate { get; private set; }


        public Analysis(CheckFind checkFind, Node node, bool isBlanck)
        {
            this.checkFind = checkFind;
            this.node = node;
            this.isBlanck = isBlanck;
            NodesGridView = new List<Nodes>();
        }
        public Node AnalysisData()
        {
            if (this.node == null) { return null; }
            SuccessRate = 0.0000m;
            List<Node> _entitys = checkFind.GetAllNodes(this.node.State, this.isBlanck);


            foreach (var _entity in _entitys)
            {
                List<Nodes> ls = checkFind.GetData(_entity, _entity.IsBlanck);

                NodesGridView.AddRange(ls);
            }
            var _resultLis = NodesGridView.Where(x => x.SuccessRate >= 2.5M).ToList();
            if (_resultLis != null && _resultLis.Count > 0)
            {
                _resultLis= _resultLis.OrderByDescending(x => x.SuccessRate).ToList();
                var _node1 = _resultLis[0].NextNode;

                if (_node1 != null)
                {
                    SuccessRate = _resultLis[0].SuccessRate;
                    return _node1;
                }
            }

            // 添加一个子
            foreach (var _view in NodesGridView)
            {
                Node __view = _view.GetNode(checkFind.Copy(), Convert.ToBoolean(this.isBlanck));
                if (__view != null)
                    _view.YGRate = __view.Rate;
            }

            var _NodesGridView = NodesGridView.Where(x => x.YGRate != 0.00M && x.YGRate >= 2.5M).OrderByDescending(x => x.YGRate).ToList();

            if (_NodesGridView != null && _NodesGridView.Count > 0)
            {
                var _node = _NodesGridView[0].NextNode;

                if (_node != null)
                {
                    SuccessRate = _NodesGridView[0].YGRate;
                    return _node;
                }
            }
            return null;
        }

        public static Decimal Contrast(Node _node,CheckFind checkFind, bool isBlanck,out string text)
        {
            text = "";
            bool IsBlanck = isBlanck;
            Node node = checkFind.GetNode(_node);
            bool falg = checkFind.SimulateSetState(isBlanck,1,node);//node.SetState(IsBlanck, 1);
            if (!falg) return 0.00M;
            Nodes nodes = AnalysisData(IsBlanck, checkFind,true);
            if (nodes != null)
            {
                text = nodes.RateText;
                return nodes.SuccessRate;
            }
            return 0.00M;
           
        }
        public static Nodes AnalysisData(bool? IsBlanck, CheckFind checkFind,bool isCheck)
        {
            List<Nodes> TNodesGridView = new List<Nodes>();
            List<Node> _entitys = checkFind.GetAllNodes(1, IsBlanck);
            if (_entitys == null || _entitys.Count <= 0) return null;
            foreach (var _entity in _entitys)
            {
                List<Nodes> ls = checkFind.GetData(_entity, IsBlanck);
                TNodesGridView.AddRange(ls);
            }
            if (isCheck)
            {
                var _resultLis = TNodesGridView.Where(x => x.SuccessRate >= 2.5M).ToList();
                if (_resultLis != null && _resultLis.Count > 0)
                {
                    _resultLis = _resultLis.OrderByDescending(x => x.SuccessRate).ToList();
                    return _resultLis[0];

                    //var _node1 = _resultLis[0].NextNode;
                    //if (_node1 != null)
                    //{
                    //    text = _resultLis[0].RateText;
                    //    return _resultLis[0].SuccessRate;
                    //}
                }
                return null;
            }
            else
            {

                var _NodesGridView = TNodesGridView.OrderByDescending(x => x.SuccessRate).ToList();
                if (_NodesGridView != null && _NodesGridView.Count > 0)
                {
                    return _NodesGridView[0];
                }
                //return GetDefautNode(node);
                throw new NotImplementedException("未处理异常！");
            }
        }
        
        public Node GetDefautNode(Node node)
        {
            Node _n = null;
            foreach (var pos in positions)
            {
                _n = checkFind.GetNextIsNull(node, pos);
                if (_n != null) return _n;
            }
            if (_n == null)
            {

            }
            return null;
        }

        private List<Position> positions = new List<Position>() { Position.L, Position.R , Position.T , Position.D , Position.TL , Position.TR ,  Position.DR ,Position.DL };

    }

    public class SortRate
    {
        public SortRate(decimal rate, Node node)
        {
            Rate = rate;
            Node = node;
        }

        public Decimal Rate { get; set; }
        public Node Node { get; set; }
    }
}

//public Node AnalysisData()
//{
//    if (this.node == null) { return null; }
//    SuccessRate = 0.0000m;
//    List<Node> _entitys = checkFind.GetAllNodes(this.node.State, this.isBlanck);


//    foreach (var _entity in _entitys)
//    {
//        List<Nodes> ls = checkFind.GetData(_entity, _entity.IsBlanck);
//        NodesGridView.AddRange(ls);
//    }
//    //var _NodesGridView = NodesGridView.OrderByDescending(x => x.SuccessRate).ToList();
//    //List<Node> _NodesGridView = new List<Node>();
//    //List<SortRate> sortRates = new List<SortRate>();
//    List<Node> sortRates = new List<Node>();
//    foreach (var _view in NodesGridView)
//    {
//        Node __view = _view.GetNode(checkFind,Convert.ToBoolean(this.isBlanck));
//        if (__view != null)
//        {
//            sortRates.Add(__view);
//        }
//    }
//    var list  = sortRates.OrderByDescending(x => x.Rate).ToList();

//    //if (list != null && list.Count > 0)
//    //{

//    //}
//    var _result = list.Where(x => x.Angle == list[0].Angle && list[0].Rate == x.Rate).ToList();
//    // 排序
//   _result = Nodes.Sort(list);
//    if (_result.Count > 0)
//    {

//        Node _node = _result[0];
//        if (_node != null)
//        {
//            SuccessRate = _result[0].Rate;
//            return _node;
//        }
//    }
//    return GetDefautNode(this.node);
//}
