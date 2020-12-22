using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew
{
    public class NodeList<K, V> : INodeList<K, V>, INodeListScore<K, V> where V : ILRUNodeToString, INodeDirection<K>, INodeSerach, INodeCopy<V>
    {
        private CalculateTheScoreArgs<K, V> _calculateTheScoreArgs;
        private StrategyArgs<K, V> _args;
        private DesignativePosition<K, V> _designativePosition;
        private Displacement _displacement;
        private object _senderArgs;
        public NodeList(Node<K, V> head, Node<K, V> tail, int count, string answerSheet,
            DesignativePosition<K, V> designativePosition,
            Displacement displacement, CalculateTheScore<K, V> calculateTheScore, object senderArgs) :
            this(head, tail, count, answerSheet,
             designativePosition,
             displacement, senderArgs)
        {
            //Head = head;
            //Tail = tail;
            //Count = count;
            //AnswerSheet = answerSheet;
            //_displacement = displacement;
            //_designativePosition = designativePosition;
            //_senderArgs = senderArgs;
            if (calculateTheScore != null)
            {
                _calculateTheScoreArgs = calculateTheScore(AnswerSheet);
                if (_calculateTheScoreArgs != null)
                {
                    Score = _calculateTheScoreArgs.Score;
                    InitStrategyArgs();
                }
            }
            if (AnswerSheet.Contains("$"))
            {

            }
            Console.WriteLine("生成格式样式：" + AnswerSheet);
        }

        private NodeList(Node<K, V> head, Node<K, V> tail, int count, string answerSheet,
            DesignativePosition<K, V> designativePosition,
            Displacement displacement, object senderArgs)
        {
            Head = head;
            Tail = tail;
            Count = count;
            AnswerSheet = answerSheet;
            _displacement = displacement;
            _designativePosition = designativePosition;
            _senderArgs = senderArgs;
        }

        private NodeList(Node<K, V> head, Node<K, V> tail, int count, string answerSheet,
           DesignativePosition<K, V> designativePosition,
           Displacement displacement, CalculateTheScoreArgs<K, V> strategyArgs, object senderArgs)
        {
            Score = strategyArgs.Score;
            InitStrategyArgs();
        }

        private void InitStrategyArgs()
        {
            if (_displacement != null)
            {

                /// 重置 Head 和 Tail
                _displacement(_calculateTheScoreArgs.LeftCount, _calculateTheScoreArgs.RightCount);
                if (_designativePosition != null)
                {
                    if (_calculateTheScoreArgs.StrategyIndexs != null)
                    {
                        List<IArgsTemplate<K, V>> nodes = new List<IArgsTemplate<K, V>>();
                        foreach (int position in _calculateTheScoreArgs.StrategyIndexs)
                        {
                            var _node = _designativePosition(position);
                            nodes.Add(new ArgsTemplate<K, V>(_node, _calculateTheScoreArgs.TemplateSorce, position, _node.Value.Symbol(), _senderArgs));
                        }
                        _args = new StrategyArgs<K, V>(_calculateTheScoreArgs.Score, nodes);
                    }
                }
            }
            else
                throw new Exception("根据模板位移失败！");
        }

        public V GetV()
        {
            if (_calculateTheScoreArgs != null)
            {
                if (_args == null) return default(V);
                List<ScoreEntity<K, V>> scoreEntitys = _calculateTheScoreArgs.StrategyTheScore(_args);
                var _Highests = scoreEntitys.OrderByDescending(x => x.CalculateArgs.Score).ToList();
                if (_Highests.Count > 0)
                {
                    // 可以继续分析，分数相等的情况下，继续预演
                    return _Highests[0].ArgsTemplates.Node.Value;
                }
                return default(V);
            }
            return default(V);
        }
        //private int NextP(List<ScoreEntity<K, V>> scoreEntitys)
        //{
        //    if (scoreEntitys != null && scoreEntitys.Count > 1)
        //    {
        //        List<ScoreEntity<K, V>> _news = scoreEntitys.Where(x => x.CalculateArgs.Score == scoreEntitys[0].CalculateArgs.Score).ToList();
        //        if (_news.Count > 1)
        //        {
        //            foreach (var _args in _news)
        //            {
        //                StrategyArgs<K, V> args = NextPreview(_args);
        //                var Highests = _calculateTheScoreArgs.StrategyTheScore(args);
        //                var _Highests = Highests.OrderByDescending(x => x.CalculateArgs.Score).ToList();
        //                _args.CalculateArgs.LJ += NextP(scoreEntitys);
        //            }
        //        }
        //        return scoreEntitys[0].CalculateArgs.Score;
        //    }
        //    else
        //    {
        //        return scoreEntitys[0].CalculateArgs.Score;
        //    }
        //}


        public Node<K, V> Head { get; }
        public Node<K, V> Tail { get; }
        public int Count { get; }

        public string AnswerSheet { get; }

        public int Score { get; private set; }

        public StrategyArgs<K, V> NextPreview(ScoreEntity<K, V> ScoreEntity)
        {
            NodeList<K, V> nodeList = new NodeList<K, V>(this.Head.Copy(), this.Tail.Copy(), this.Count, this.AnswerSheet, this._designativePosition, this._displacement, ScoreEntity.CalculateArgs, this._senderArgs);
            nodeList._args.ParentScoreEntity = ScoreEntity;
            return nodeList._args;
        }
    }

    public class ScoreEntity<K, V>
    {
        public ScoreEntity(IArgsTemplate<K, V> argsTemplates, CalculateTheScoreArgs<K, V> calculateArgs,int score)
        {
            ArgsTemplates = argsTemplates;
            CalculateArgs = calculateArgs;
            Score = score;
        }

        public IArgsTemplate<K, V> ArgsTemplates { get; set; }
        public CalculateTheScoreArgs<K, V> CalculateArgs { get; set; }
        public int Score { get; set; }

    }
}
