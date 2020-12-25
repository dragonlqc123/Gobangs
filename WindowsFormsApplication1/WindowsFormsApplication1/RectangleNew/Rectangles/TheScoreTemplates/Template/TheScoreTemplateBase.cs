using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew.Rectangles
{

    public abstract class TheScoreTemplateBase<K, V>
    {
        protected StrategyTheScore<K, V> strategyTheScore;
        protected string FileName { get; private set; }
        protected virtual string Extension { get { return ".txt"; } }

        private string _path;
        protected TheScoreTemplateBase(string fileName, StrategyTheScore<K, V> strategyTheScore)
        {
            _path = AppDomain.CurrentDomain.BaseDirectory + "Brains";
            FileName = System.IO.Path.Combine(_path, (fileName +Extension));
            this.strategyTheScore = strategyTheScore;
        }

        /// <summary>
        /// 初始化评分模板subtemplate
        /// </summary>
        /// <returns></returns>
        protected Dictionary<string, int> InitTheScoreTemplate(string fileName)
        {
            try
            {
                var theScoreDic = new Dictionary<string, int>();
                using (System.IO.StreamReader sr = new System.IO.StreamReader(System.IO.Path.Combine(_path, fileName)))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] strs = line.Split('=');
                        if (strs.Length != 2) continue;
                        if (!theScoreDic.ContainsKey(strs[0]))
                        {
                            theScoreDic.Add(strs[0], int.Parse(strs[1]));
                        }
                    }
                }
                return theScoreDic;
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return null;
        }

        protected void WriteTheScoreTemplate(string key, string fileName)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(Path.Combine(_path, FileName), true))
            {
                file.WriteLine(key);
            }
        }

        protected List<int> GetStoma(string templateStr)
        {
            try
            {
                char[] strs = templateStr.ToArray();
                List<int> _ls = new List<int>();
                for (int i = 0; i < strs.Length; i++)
                {
                    if (strs[i] == '+')
                        _ls.Add(i + 1);

                }
                return _ls;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected int[] QueryString(string originalStr, string substr)
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
