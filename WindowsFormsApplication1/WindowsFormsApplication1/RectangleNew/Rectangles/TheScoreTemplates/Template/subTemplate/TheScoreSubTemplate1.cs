using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew.Rectangles
{
    public  class TheScoreSubTemplate1<K, V> : TheScoreTemplateBase<K, V>
    {
        private Dictionary<string, int> _subTemplateDic1;
        private TheScoreSubTemplate2<K,V> _subTemplate2;
        public TheScoreSubTemplate1(StrategyTheScore<K, V> strategyTheScore) : base("subtemplate", strategyTheScore)
        {
            _subTemplateDic1 = InitTheScoreTemplate(base.FileName);
            _subTemplate2 = new TheScoreSubTemplate2<K, V>(strategyTheScore);
        }


        public CalculateTheScoreArgs<K, V> Get(string key)
        {
            try
            {
                List<int> strategyIndexs = new List<int>();
                int sorce = 0;
                string templateStr = null;
                string _totalStrs;
                string _subStrs;
                foreach (var _tempStr in _subTemplateDic1.Keys)
                {
                    if (key.Length > _tempStr.Length) { _totalStrs = key; _subStrs = _tempStr; }
                    else { _totalStrs = _tempStr; _subStrs = key; }
                    if (_totalStrs.Contains(_subStrs))
                    {

                        var _sorce = _subTemplateDic1[_tempStr];
                        if (_sorce > sorce)
                        {
                            sorce = _sorce;
                            templateStr = _tempStr;
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
                    return _subTemplate2.Get(key);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
