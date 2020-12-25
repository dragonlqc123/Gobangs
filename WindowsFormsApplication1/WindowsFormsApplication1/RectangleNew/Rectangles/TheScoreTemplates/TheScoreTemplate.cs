using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew.Rectangles
{

    public class TheScoreTemplate<K,V>
    {

        private StrategyTheScore<K,V> strategyTheScore;

        private AnalysisRecursion<K, V> _analysisRecursion;
        private TheScoreSubTemplate1<K, V> subTemplate1;
        private TheScoreTemplate1<K, V> template1;
        private TheScoreTemplate()
        {
            strategyTheScore = new StrategyTheScore<K, V>(StrategyTheScore);
            subTemplate1 = new TheScoreSubTemplate1<K, V>(StrategyTheScore);
            template1 = new TheScoreTemplate1<K, V>(StrategyTheScore);
        }
        public TheScoreTemplate(AnalysisRecursion<K, V> analysisRecursion):this()
        {
            _analysisRecursion = analysisRecursion;
        }
       

       
        public CalculateTheScoreArgs<K, V> this[string key]
        {
            get
            {
                try
                {
                    //if (key.IndexOf("+") <= -1|| key.Contains("-1"))
                    //{
                    //    //CalculateTheScoreArgs<K, V> strategyArgs1 = new CalculateTheScoreArgs<K, V>(strategyTheScore, -1000000, null, 0, 0, null);
                    //    //return strategyArgs1;
                    //    return null;
                    //}
                    return template1[key];
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        public V AttackOrDefense<K, V>(INodeListScore<K, V> attack, INodeListScore<K, V> defense) where V : EntityData<K>, INodeCopy<V>
        {
            if (attack == null) return defense.GetV();
            if (defense == null) return attack.GetV();
            if (attack.Score >= defense.Score)
            {
                return attack.GetV();
            }
            else
                return defense.GetV();
            throw new NotImplementedException("AttackOrDefense=>未处理没有找到异常，需要实现！");
        }
        
        private List<ScoreEntity<K, V>> StrategyTheScore(IStrategyArgs<K, V> strategyArgs)
        {
            try
            {
                TheScoreTemplate<K, V> theScoreTemplate = new TheScoreTemplate<K, V>();
                List<ScoreEntity<K, V>> scoreList = new List<ScoreEntity<K, V>>();

                foreach (var _index in strategyArgs.StrategyIndexs)
                {
                    var _result = subTemplate1.Get(_index.NewTemplateSorce);
                    //var _result = this[_index.NewTemplateSorce];
                    //var _score = _analysisRecursion(_index);  
                    if (_result == null) continue;
                    scoreList.Add(new ScoreEntity<K, V>(_index, _result, _result.Score+_index.Weight));
                }
                return scoreList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private V Sefense(IStrategyArgs<K, V> strategyArgs)
        {
            return default(V);
        }

        public bool CheckVictory<K, V>(List<NodeList<K, V>> nodeLists) where V : EntityData<K>, INodeCopy<V>
        {
            if (nodeLists != null)
            {
                var _ls = nodeLists.Where(x => x.Score >= 50000).ToList();
                if (_ls != null && _ls.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }


}
