using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew.Rectangles
{
    public class TheScoreTemplate2<K, V> : TheScoreTemplateBase<K, V>
    {
        private Dictionary<string, int> _templateDic2;

        public TheScoreTemplate2(StrategyTheScore<K, V> strategyTheScore) : base("template2", strategyTheScore)
        {
            _templateDic2 = InitTheScoreTemplate(base.FileName);
        }
        public CalculateTheScoreArgs<K, V> this[string key]
        {
            get
            {
                try
                {
                    if (_templateDic2 == null)
                    {
                        goto AddCache;
                    }
                    List<int> strategyIndexs = new List<int>();
                    int sorce = 0;
                    string templateStr = null;
                    string _totalStrs;
                    string _subStrs;
                    foreach (var _tempStr in _templateDic2.Keys)
                    {
                        if (key.Length > _tempStr.Length) { _totalStrs = key; _subStrs = _tempStr; }
                        else { _totalStrs = _tempStr; _subStrs = key; }
                        //if (_totalStrs.Contains(_subStrs))
                        if (_totalStrs==(_subStrs))
                        {

                            var _sorce = _templateDic2[_tempStr];
                            if (_sorce > sorce)
                            {
                                templateStr = _tempStr;
                                sorce = _sorce;
                            }
                        }
                    }
                    if (templateStr != null)
                    {
                        int[] items = QueryString(key, templateStr);
                        string _newTemplate = templateStr;
                        int _score = sorce;
                        if (key.Length < templateStr.Length)
                        {
                            _newTemplate = key;
                        }
                        strategyIndexs = GetStoma(_newTemplate);
                        CalculateTheScoreArgs<K, V> strategyArgs = new CalculateTheScoreArgs<K, V>(strategyTheScore, _score, _newTemplate, items[0], items[1], strategyIndexs);
                        return strategyArgs;
                    }
                    AddCache:
                    if (key.Contains("+"))
                    {
                        int _newKey = key.Split('+').Length + key.Split('O').Length * 2;
                        this.WriteTheScoreTemplate(key + "="+ _newKey, base.FileName);
                        _templateDic2 = InitTheScoreTemplate(base.FileName);
                        return this[key];
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
