using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew.Rectangles
{
    public class TheScoreSubTemplate2<K, V> : TheScoreTemplateBase<K, V>
    {
        private Dictionary<string, int> _subTemplateDic2;
        public TheScoreSubTemplate2(StrategyTheScore<K, V> strategyTheScore) : base("subtemplate2", strategyTheScore)
        {
            _subTemplateDic2 = InitTheScoreTemplate(base.FileName);
        }

        public CalculateTheScoreArgs<K, V> Get(string key)
        {
            try
            {
                if (_subTemplateDic2 == null)
                    goto AddCache;
                List<int> strategyIndexs = new List<int>();
                int sorce = 0;
                string templateStr = null;
                foreach (var _tempStr in _subTemplateDic2.Keys)
                {
                    if (key.Contains(_tempStr))
                    {

                        var _sorce = _subTemplateDic2[_tempStr];
                        if (_sorce > sorce)
                        {
                            sorce = _sorce;
                            templateStr = _tempStr;
                        }
                    }
                }
                if (templateStr != null)
                {
                    int[] items = QueryString(key, templateStr);
                    strategyIndexs = GetStoma(templateStr);
                    CalculateTheScoreArgs<K, V> strategyArgs = new CalculateTheScoreArgs<K, V>(strategyTheScore, sorce, templateStr, items[0], items[1], strategyIndexs);
                    return strategyArgs;
                }
                AddCache:
                int _newKey = key.Split('+').Length * 2 + key.Split('O').Length;
                this.WriteTheScoreTemplate(key + "=" + _newKey, base.FileName);
                //this.WriteTheScoreTemplate(key + "=" + key.Split('O').Length, base.FileName);
                _subTemplateDic2 = InitTheScoreTemplate(base.FileName);
                return Get(key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
