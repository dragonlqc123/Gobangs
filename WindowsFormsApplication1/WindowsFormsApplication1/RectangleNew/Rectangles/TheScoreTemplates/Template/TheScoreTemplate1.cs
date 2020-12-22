using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew.Rectangles
{
    public class TheScoreTemplate1<K, V> : TheScoreTemplateBase<K, V>
    {
        private Dictionary<string, int> _templateDic1;
        private TheScoreTemplate2<K, V> _scoreTemplate2;
        public TheScoreTemplate1(StrategyTheScore<K, V> strategyTheScore) : base("template", strategyTheScore)
        {
            _templateDic1= InitTheScoreTemplate(base.FileName);
            _scoreTemplate2 = new TheScoreTemplate2<K, V>(strategyTheScore);
        }

        public CalculateTheScoreArgs<K, V> this[string key]
        {
            get
            {
                try
                {
                    List<int> strategyIndexs = new List<int>();
                    int sorce = 0;
                    string templateStr = null;
                    string _totalStrs;
                    string _subStrs;
                    foreach (var _tempStr in _templateDic1.Keys)
                    {
                        if (key.Length > _tempStr.Length) { _totalStrs = key; _subStrs = _tempStr; }
                        else { _totalStrs = _tempStr; _subStrs = key; }
                        if (_totalStrs.Contains(_subStrs))
                        {

                            var _sorce = _templateDic1[_tempStr];
                            if (_sorce > sorce)
                            {
                                templateStr = _tempStr;
                                sorce = _sorce;
                            }
                        }
                    }
                    if (templateStr != null && key.Length >= templateStr.Length)
                    {
                        int[] items = QueryString(key, templateStr);
                        strategyIndexs = GetStoma(templateStr);
                        CalculateTheScoreArgs<K, V> strategyArgs = new CalculateTheScoreArgs<K, V>(strategyTheScore, sorce, templateStr, items[0], items[1], strategyIndexs);
                        return strategyArgs;
                    }
                    else
                    {
                        return _scoreTemplate2[key];
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
