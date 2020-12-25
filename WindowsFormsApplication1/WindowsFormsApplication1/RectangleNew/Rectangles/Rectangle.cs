using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew.Rectangles
{

    public class Rectangle<K, V> : NodeMultiwayCache<K, V>, IRectangle<K, V> where V : EntityData<K>, INodeCopy<V>
    {
        private TheScoreTemplate<K,V> theScoreTemplate;
        private AnalysisRecursion<K, V> analysisRecursion;
        private ScatterNode ScatterNode { get; }
        protected Rectangle(int captity) : base(captity)
        {
            analysisRecursion = new AnalysisRecursion<K, V>(AnalysisRecursion);
            theScoreTemplate = new TheScoreTemplate<K,V>(analysisRecursion);
        }
        public Rectangle(int captity, ScatterNode scatterNode) : this(captity)
        {
            ScatterNode = scatterNode;
        }
     
        public void AddNode(K key, V value)
        {
            this.AddFirstNode(key, value);
        }

        protected override V GetScatterNode(K key)
        {
            return (V)ScatterNode(key);
        }

        private NodeList<K, V> _Analysis(K key, object condition)
        {
            CalculateTheScore<K, V> _calculateTheScore = new CalculateTheScore<K, V>(CaculateTheScore);
            NodeMultiway<K, V> nodeMultiway = base.GetNodes(key, condition, _calculateTheScore);
            if (nodeMultiway == null) return null;
            var nodeList = nodeMultiway.ToList();
            var _ls = nodeList.OrderByDescending(x => x.Score).ToList();
            if (_ls != null && _ls.Count > 0)
                return _ls[0];
            return null;
        }

        private List<NodeList<K, V>> _AnalysisList(K key, object condition)
        {
            CalculateTheScore<K, V> _calculateTheScore = new CalculateTheScore<K, V>(CaculateTheScore);
            NodeMultiway<K, V> nodeMultiway = base.GetNodes(key, condition, _calculateTheScore);
            if (nodeMultiway == null) return null;
            var nodeList = nodeMultiway.ToList();
            var _ls = nodeList.OrderByDescending(x => x.Score).ToList();
            return _ls;
        }
        public V Analysis(K key, object condition)
        {
            NodeList<K, V> node = _Analysis(key, condition);
            if (node != null && node.Count > 0)
                return node.GetV();
            throw new NotImplementedException("Analysis=>未处理没有找到异常，需要实现！");
        }

        public V Analysis(object attackCondition, object defenseCondition, GetAll<K> getAll,K key)
        {
            //this.Summary_Get(key);
            var _attack = GetAllNodes1(getAll(attackCondition),attackCondition);
            var _defense = GetAllNodes1(getAll(defenseCondition),defenseCondition);
            Comparer:
            if (_attack == null && _defense == null)
                throw new NotImplementedException("分析时引发未处理异常！");
            var value = theScoreTemplate.AttackOrDefense(_attack, _defense);
            if (value == null)
            {
                _attack = GetAllNodes1(new List<K> { key }, attackCondition);
                _defense = GetAllNodes1(new List<K> { key }, defenseCondition);
                goto Comparer;
            }
            Console.WriteLine("=================================================");
            return value;
        }

        private INodeListScore<K, V> GetAllNodes(List<K> ks,object condition)
        {
            if (ks == null || ks.Count <= 0) return null;
            List<NodeList<K, V>> nodeList = new List<NodeList<K, V>>();
            foreach (K k in ks)
            {
                var _attackNew = _Analysis(k, condition);
                if (_attackNew != null)
                {
                    nodeList.Add(_attackNew);
                }
            }
            var _attack = nodeList.OrderByDescending(x => x.Score).FirstOrDefault();
            return _attack;
        }

        private INodeListScore<K, V> GetAllNodes1(List<K> ks, object condition)
        {
            if (ks == null || ks.Count <= 0) return null;
            List<NodeList<K, V>> nodeList = new List<NodeList<K, V>>();
            foreach (K k in ks)
            {
                var _attackNew = _AnalysisList(k, condition);
                if (_attackNew != null&& _attackNew.Count>0)
                {
                    nodeList.AddRange(_attackNew);
                }
            }
            var _attack = nodeList.OrderByDescending(x => x.Score).FirstOrDefault();
            return _attack;
        }

        private int AnalysisRecursion(IArgsTemplate<K, V> argsTemplate)
        {
            var node = _Analysis(argsTemplate.Node.Key, argsTemplate.SenderArgs);
            if (node != null)
            {
                return node.Score;
            }
            return 0;
        }

        public bool CheckVictory(K key, object condition)
        {
            List < NodeList < K, V >>  nodeLists = this._AnalysisList(key,condition);
            return theScoreTemplate.CheckVictory(nodeLists);
        }

        #region Console
        public void TestWriteLineAll()
        {
            base.WriteLine(Direction.H, Sort.ASC);
            base.WriteLine(Direction.H, Sort.DESC);
            base.WriteLine(Direction.S, Sort.ASC);
            base.WriteLine(Direction.S, Sort.DESC);
            base.WriteLine(Direction.LR, Sort.ASC);
            base.WriteLine(Direction.LR, Sort.DESC);
            base.WriteLine(Direction.RL, Sort.ASC);
            base.WriteLine(Direction.RL, Sort.DESC);
        }
        public void WriteLineAllDESC()
        {

            base.WriteLine(Direction.H, Sort.DESC);
            base.WriteLine(Direction.S, Sort.DESC);
            base.WriteLine(Direction.LR, Sort.DESC);
            base.WriteLine(Direction.RL, Sort.DESC);
        }
        public void WriteLineAllASC()
        {
            base.WriteLine(Direction.H, Sort.ASC);
            base.WriteLine(Direction.S, Sort.ASC);
            base.WriteLine(Direction.LR, Sort.ASC);
            base.WriteLine(Direction.RL, Sort.ASC);
        }

        public void WriteLineAll(K key)
        {
            var node = Summary_GetNode(key);
            base.WriteLine(Direction.H, Sort.ASC, node);
            base.WriteLine(Direction.H, Sort.DESC, node);
            Console.WriteLine();
            base.WriteLine(Direction.S, Sort.ASC, node);
            base.WriteLine(Direction.S, Sort.DESC, node);
            Console.WriteLine();
            base.WriteLine(Direction.LR, Sort.ASC, node);
            base.WriteLine(Direction.LR, Sort.DESC, node);
            Console.WriteLine();
            base.WriteLine(Direction.RL, Sort.ASC, node);
            base.WriteLine(Direction.RL, Sort.DESC, node);
            Console.WriteLine();
        }
        public void WriteLine(Direction direction, Sort sort, K key)
        {
            var node = Summary_GetNode(key);
            base.WriteLine(direction, sort, node);
        }


        public V TestAnalysis(K key, object condition, SearchTest<K> searchTest)
        {
            CalculateTheScore<K,V> _calculateTheScore = new CalculateTheScore<K,V>(CaculateTheScore);
            NodeMultiway < K, V > nodeMultiway= base.TestSeacheNodes(key, condition, searchTest, _calculateTheScore);
            var nodeList = nodeMultiway.ToList();
            var _ls = nodeList.OrderByDescending(x => x.Score).ToList();
            if (_ls != null && _ls.Count > 0)
                return _ls[0].GetV();
            return null;
        }

        /// <summary>
        /// 进行计算验证
        /// </summary>
        /// <param name="identification"></param>
        /// <returns></returns>
        private CalculateTheScoreArgs<K,V> CaculateTheScore(string identification)
        {
            try
            {
                return theScoreTemplate[identification];
            }
            catch (Exception ex)
            { throw ex; }
        }
        #endregion
    }



}
