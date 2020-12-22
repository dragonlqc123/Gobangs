using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew.Rectangles.delete
{

    public class TheScoreTemplate<K,V>
    {

        private StrategyTheScore<K,V> strategyTheScore;
        //private Dictionary<string, int> _theScoreDic;
        //private Dictionary<string, int> _subTheScoreDic;

        private AnalysisRecursion<K, V> _analysisRecursion;
        private TheScoreTemplate()
        {
            strategyTheScore = new StrategyTheScore<K, V>(StrategyTheScore);
            //_theScoreDic = InitTheScoreTemplate("template.txt");
            //_subTheScoreDic = InitTheScoreTemplate("subtemplate.txt");
        }
        public TheScoreTemplate(AnalysisRecursion<K, V> analysisRecursion):this()
        {
            _analysisRecursion = analysisRecursion;
        }
        ///// <summary>
        ///// 初始化评分模板subtemplate
        ///// </summary>
        ///// <returns></returns>
        //private Dictionary<string, int> InitTheScoreTemplate(string fileName)
        //{
        //    try
        //    {
        //        var theScoreDic = new Dictionary<string, int>();
        //        using (System.IO.StreamReader sr = new System.IO.StreamReader(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName)))
        //        {
        //            string line;
        //            while ((line = sr.ReadLine()) != null)
        //            {
        //                string[] strs = line.Split('=');
        //                if (strs.Length != 2) continue;
        //                if (!theScoreDic.ContainsKey(strs[0]))
        //                {
        //                    theScoreDic.Add(strs[0], int.Parse(strs[1]));
        //                }
        //            }
        //        }
        //        return theScoreDic;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("The file could not be read:");
        //        Console.WriteLine(e.Message);
        //    }
        //    return null;
        //}

        //private void Write(string key, string fileName)
        //{
        //    using (System.IO.StreamWriter file = new System.IO.StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName), true))
        //    {
        //        file.WriteLine(key);
        //    }
        //}

        public CalculateTheScoreArgs<K, V> this[string key]
        {
            get
            {
                try
                {
                    if (key.Contains("-1"))
                    {
                        CalculateTheScoreArgs<K, V> strategyArgs1 = new CalculateTheScoreArgs<K, V>(strategyTheScore, -1000000, null, 0, 0, null);
                        return strategyArgs1;
                    }
                    List<int> strategyIndexs = new List<int>();
                    int sorce = 0;
                    string templateStr = "";
                    string _totalStrs;
                    string _subStrs;
                    foreach (var _tempStr in _theScoreDic.Keys)
                    {
                        if (key.Length > _tempStr.Length) { _totalStrs = key; _subStrs = _tempStr; }
                        else { _totalStrs = _tempStr; _subStrs = key; }
                        if (_totalStrs.Contains(_subStrs))
                        {

                            var _sorce = _theScoreDic[_tempStr];
                            if (_sorce > sorce)
                            {
                                templateStr = _tempStr;
                                sorce = _sorce;
                            }
                        }
                    }
                    int[] items = QueryString(key, templateStr);
                    string _newTemplate = templateStr;
                    int _score = sorce;
                    if (key.Length < templateStr.Length)
                    {
                        _newTemplate = key;
                        _score *= -1; 
                    }
                    strategyIndexs = GetStoma(_newTemplate);
                    CalculateTheScoreArgs<K, V> strategyArgs = new CalculateTheScoreArgs<K, V>(strategyTheScore, _score, _newTemplate, items[0], items[1], strategyIndexs);
                    return strategyArgs;
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

        //private List<int> GetStoma(string templateStr)
        //{
        //    try
        //    {
        //        string[] strs = templateStr.Split('+');
        //        List<int> _ls = new List<int>();
        //        for (int i = 0; i < strs.Length; i++)
        //        {
        //            if (strs[i] == "")
        //                _ls.Add(i + 1);

        //        }
        //        return _ls;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        private List<ScoreEntity<K, V>> StrategyTheScore(IStrategyArgs<K, V> strategyArgs)
        {
            try
            {
                TheScoreTemplate<K, V> theScoreTemplate = new TheScoreTemplate<K, V>();
                List<ScoreEntity<K, V>> scoreList = new List<ScoreEntity<K, V>>();

                foreach (var _index in strategyArgs.StrategyIndexs)
                {

                     var _result =Get(_index.NewTemplateSorce);
                    //var _result = this[_index.NewTemplateSorce];
                    //var _score = _analysisRecursion(_index);  
                    if (_result == null) continue;
                    scoreList.Add(new ScoreEntity<K, V>(_index, _result, _result.Score));
                }
                return scoreList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private CalculateTheScoreArgs<K, V> Get(string key)
        {
            try
            {
                List<int> strategyIndexs = new List<int>();
                int sorce = 0;
                string templateStr = null;
                string _totalStrs;
                string _subStrs;
                foreach (var _tempStr in _subTheScoreDic.Keys)
                {
                    if (key.Length > _tempStr.Length) { _totalStrs = key; _subStrs = _tempStr; }
                    else { _totalStrs = _tempStr; _subStrs = key; }
                    if (_totalStrs.Contains(_subStrs))
                    {

                        var _sorce = _subTheScoreDic[_tempStr];
                        if (_sorce > sorce)
                        {
                            sorce = _sorce;
                            templateStr = _tempStr;
                        }
                    }
                }
                if (templateStr != null)// && key.Length >= templateStr.Length)
                {
                    int[] items = QueryString(key, templateStr);
                    strategyIndexs = GetStoma(templateStr);
                    CalculateTheScoreArgs<K, V> strategyArgs = new CalculateTheScoreArgs<K, V>(strategyTheScore, sorce, templateStr, items[0], items[1], strategyIndexs);
                    return strategyArgs;
                }
                else
                {
                    this.Write(key + "=5", "subtemplate.txt");
                    _subTheScoreDic = InitTheScoreTemplate("subtemplate.txt");
                    return Get(key);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //private V StrategyTheScore(IStrategyArgs<K, V> strategyArgs)
        //{
        //    TheScoreTemplate<K, V> theScoreTemplate = new TheScoreTemplate<K, V>();
        //    List<ScoreEntity<K, V>> scoreList = new List<ScoreEntity<K, V>>();

        //    foreach (var _index in strategyArgs.StrategyIndexs)
        //    {
        //        var _reslut = theScoreTemplate[_index.NewTemplateSorce];
        //        scoreList.Add(new ScoreEntity<K, V>(_index, _reslut));
        //    }
        //    var _Highests = scoreList.OrderByDescending(x => x.Args.Score).ToList();

        //    // 可以继续分析，分数相等的情况下，继续预演
        //    return _Highests[0].ArgsTemplates.Node.Value;
        //}

        private V Sefense(IStrategyArgs<K, V> strategyArgs)
        {
            return default(V);
        }

        private int[] QueryString(string originalStr, string substr)
        {
            try
            {
                if (substr == null) return null;
                if (originalStr.Length < substr.Length) return new int[2] { 0, 0 };
                string[] _newStrs = originalStr.Replace(substr, "|%|").Split('%');
                int leftCount = 0;
                int rightCount = 0;
                if (_newStrs.Length > 0)
                {
                    if (!(_newStrs[0] == _newStrs[1] && _newStrs[1] == "|"))
                    {
                        // 左边为空 originalStr = 123X  == |%|X
                        // 或者     originalStr = X123  == X%
                        if (_newStrs[0] != "|")
                        {
                            /// 左边有几个;
                            leftCount = _newStrs[0].Length - ("|".Length);
                        }
                        if (_newStrs[1] != "|")
                        {
                            rightCount = _newStrs[1].Length - ("|".Length);
                        }
                    }
                }
                int[] items = new int[2] { leftCount, rightCount };
                return items;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }


}
