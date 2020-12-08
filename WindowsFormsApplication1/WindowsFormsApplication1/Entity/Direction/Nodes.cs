using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Nodes
    {
        public Nodes(int count, List<Node> ls, Angle angle, CheckFind checkFind)
        {
            NoTuseds = new List<Node>();
            Ls = new List<Node>();
            foreach (var _node in ls)
            {
                if (_node.State == 0)
                {
                    _node.Angle = angle;
                    this.NoTuseds.Add(_node);
                }
                else
                {
                    _node.Angle = angle;
                    this.Ls.Add(_node);
                }
            }
            Count = this.Ls.Count;
            Angle = angle;
            this.InitData(checkFind);
        }

        public void InitData(CheckFind checkFind)
        {
            Node max;
            Node min;
            bool isMax = false;
            bool isMin = false;

            if (this.Ls.Count <= 0) return;
            min = Top;
            max = After;
            if (this.Angle == Angle.HENG)
            {
                isMin = checkFind.CheckNextIsNull(min, Position.L);

                isMax = checkFind.CheckNextIsNull(max, Position.R);
                if (isMax)
                {
                    AfterNext = checkFind.GetNextIsNull(max, Position.R);
                    AfterNext.Angle = this.Angle;
                    var n = checkFind.GetNextNode(AfterNext, Position.R, max.IsBlanck, 1);
                    if (n == null) AfterNextNext = 0;
                    else AfterNextNext = 1;
                }
                else if (isMin)
                {
                    TopNext = checkFind.GetNextIsNull(min, Position.L);
                    TopNext.Angle = this.Angle;
                    var n = checkFind.GetNextNode(TopNext, Position.L, min.IsBlanck, 1);
                    if (n == null) TopNextNext = 0;
                    else TopNextNext = 1;
                }
            }
            else if (this.Angle == Angle.SHU)
            {
                isMin = checkFind.CheckNextIsNull(min, Position.T);
                isMax = checkFind.CheckNextIsNull(max, Position.D);
                if (isMax)
                {
                    AfterNext = checkFind.GetNextIsNull(max, Position.D);
                    AfterNext.Angle = this.Angle;
                    var n = checkFind.GetNextNode(AfterNext, Position.D, max.IsBlanck, 1);
                    if (n == null) AfterNextNext = 0;
                    else AfterNextNext = 1;
                }
                else if (isMin)
                {
                    TopNext = checkFind.GetNextIsNull(min, Position.T);
                    TopNext.Angle = this.Angle;
                    var n = checkFind.GetNextNode(TopNext, Position.T, min.IsBlanck, 1);
                    if (n == null) TopNextNext = 0;
                    else TopNextNext = 1;
                }
            }
            else if (this.Angle == Angle.ZX)
            {
                isMin = checkFind.CheckNextIsNull(min, Position.TL);
                isMax = checkFind.CheckNextIsNull(max, Position.DR);
                if (isMax)
                {
                    AfterNext = checkFind.GetNextIsNull(max, Position.DR);
                    AfterNext.Angle = this.Angle;
                    var n = checkFind.GetNextNode(AfterNext, Position.DR, max.IsBlanck, 1);
                    if (n == null) AfterNextNext = 0;
                    else AfterNextNext = 1;
                }
                else if (isMin)
                {
                    TopNext = checkFind.GetNextIsNull(min, Position.TL);
                    TopNext.Angle = this.Angle;
                    var n = checkFind.GetNextNode(TopNext, Position.TL, min.IsBlanck, 1);
                    if (n == null) TopNextNext = 0;
                    else TopNextNext = 1;
                }
            }
            else if (this.Angle == Angle.YX)
            {
                isMin = checkFind.CheckNextIsNull(min, Position.DL);
                isMax = checkFind.CheckNextIsNull(max, Position.TR);
                if (isMax)
                {
                    AfterNext = checkFind.GetNextIsNull(max, Position.TR);
                    AfterNext.Angle = this.Angle;
                    var n = checkFind.GetNextNode(AfterNext, Position.TR, max.IsBlanck, 1);
                    if (n == null) AfterNextNext = 0;
                    else AfterNextNext = 1;
                }
                else if (isMin)
                {
                    TopNext = checkFind.GetNextIsNull(min, Position.DL);
                    TopNext.Angle = this.Angle;
                    var n = checkFind.GetNextNode(TopNext, Position.DL, min.IsBlanck, 1);
                    if (n == null) TopNextNext = 0;
                    else TopNextNext = 1;
                }
            }

            if (isMin || isMax) { Block = 2; }
            if (!isMin && !isMax) { Block = -1; }
            if (isMin && isMax) { Block = 1; }


        }

        /// <summary>
        /// 阻死 -1：堵死；1：无锁；2：锁一半；
        /// </summary>
        public int Block { get; private set; }

        public Node GetNode(CheckFind checkFind, bool isBlanck)
        {
            string outText = "";
            if (Block == 1)
            {
                /// 需要侧列
                if (NoTuseds != null && NoTuseds.Count == 1)
                {
                    var __nodel = NoTuseds[NoTuseds.Count - 1];
                    __nodel.Rate = Analysis.Contrast(__nodel, checkFind, isBlanck, out outText);
                    __nodel.RateText = outText;
                    return __nodel;
                }
                else
                {
                    if (AfterNextNext != 0 && TopNextNext != 0)
                    {
                        var afterRa = Analysis.Contrast(AfterNext, checkFind, isBlanck, out outText);
                        var topRa = Analysis.Contrast(TopNext, checkFind, isBlanck, out outText);
                        if (afterRa > topRa)
                        {
                            AfterNext.Rate = afterRa;
                            AfterNext.RateText = outText;
                            return AfterNext;
                        }
                        else
                        {
                            TopNext.Rate = topRa;
                            TopNext.RateText = outText;
                            return TopNext;
                        }
                    }
                    else if (AfterNextNext != 0)
                    {
                        var afterRa = Analysis.Contrast(AfterNext, checkFind, isBlanck, out outText);
                        AfterNext.Rate = afterRa;
                        AfterNext.RateText = outText;
                        return AfterNext;
                    }
                    else if (TopNextNext != 0)
                    {
                        var topRa = Analysis.Contrast(TopNext, checkFind, isBlanck, out outText);
                        TopNext.Rate = topRa;
                        TopNext.RateText = outText;
                        return TopNext;
                    }
                }
                // 还需要策略[挨着墙]
                var __node = TopNext != null ? TopNext : AfterNext;
                __node.Rate = Analysis.Contrast(__node, checkFind, isBlanck, out outText);
                __node.RateText = outText;
                return __node;
            }
            if (Block == 2)
            {
                var __node = TopNext != null ? TopNext : AfterNext;
                __node.Rate = Analysis.Contrast(__node, checkFind, isBlanck, out outText);
                __node.RateText = outText;
                return __node;
            }
            return null;
        }
        public Node Top { get { return Ls[0]; } }
        public Node TopNext { get; private set; }

        public Node NextNode
        {
            get
            {
                if (TopNext != null && TopNext.Rate > 0)
                {
                    return TopNext;
                }
                else if (AfterNext != null && AfterNext.Rate > 0)
                {
                    return AfterNext;
                }
                return null;
            }
        }
        public int TopNextNext { get; private set; }
        public Node After { get { return Ls[Count - 1]; } }
        public Node AfterNext { get; private set; }
        public int AfterNextNext { get; private set; }

        public Angle Angle { get; set; }
        public int Count { get; set; }
        public List<Node> Ls { get; set; }

        private List<Node> NoTuseds { get; set; }

        /// <summary>
        /// 胜率
        /// </summary>
        public decimal SuccessRate
        {
            get
            {
                decimal rate = 5 * (Block == 2 ? 1 : Block);
                //if (Count < 5)
                //{
                    decimal js = (TopNextNext + AfterNextNext) == 0 ? 0.00M :
                        (-0.5M * (TopNextNext + AfterNextNext));

                    //rate = (Count + js) / rate;
                    rate =  rate+js;
                //}
                if (Count == 5)
                {
                    Console.WriteLine("xxx");
                }
                if (Count == 4)
                {
                    Console.WriteLine("xxx");
                }
                decimal x = ((5 - Count) * 1.00M == 0.00M ? 0.1M : (5 - Count) * 1.00M);

                Decimal result = rate / x;
                if (result == 0.8M)
                {
                    Console.WriteLine("xxx");
                }
                //}
                RateText = string.Format("{0}/{1}={2}", rate, x, result.ToString("0.00"));

                return result;
            }

        }

        public decimal YGRate { get; set; }
        public string RateText { get; private set; }


        public static List<Node> Sort(List<Node> nodes)
        {

            if (nodes[0].Angle == Angle.HENG)
                nodes = nodes.OrderByDescending(x => x.X).ToList();

            else if (nodes[0].Angle == Angle.SHU)
                nodes = nodes.OrderByDescending(x => x.Y).ToList();

            else if (nodes[0].Angle == Angle.ZX)
                nodes = nodes.OrderByDescending(x => x.X).ToList();

            else if (nodes[0].Angle == Angle.YX)
                nodes = nodes.OrderByDescending(x => x.X).ToList();
            return nodes;
        }
    }
}
