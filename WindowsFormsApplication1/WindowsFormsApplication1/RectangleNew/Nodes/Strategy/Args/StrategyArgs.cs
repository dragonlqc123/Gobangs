using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace WindowsFormsApplication1.RectangleNew
{
    public interface ICalculateTheScoreArgs
    {
        int Score { get; }
        List<int> StrategyIndexs { get; }
        string TemplateSorce { get; }
    }

    public interface IDisplacementArgs
    {
        int LeftCount { get; }
        int RightCount { get; }
    }

    public class CalculateTheScoreArgs<K,V>: ICalculateTheScoreArgs, IDisplacementArgs
    {
        public StrategyTheScore<K,V> StrategyTheScore { get; }

        public CalculateTheScoreArgs(StrategyTheScore<K, V> strategyTheScore, int score,string templateSorce, int leftCount,int rightCount,List<int> strategyIndexs)
        {
            if (strategyTheScore != null)
            {
                this.StrategyTheScore = strategyTheScore;
                Score = score;
                StrategyIndexs = strategyIndexs;
                LeftCount = leftCount;
                RightCount = rightCount;
                TemplateSorce = templateSorce;
            }
            else
            {
                throw new Exception("评分策略不能为空！");
            }
        }

        public int Score { get; }
        
        //public int LJ { get; set; }

        public List<int> StrategyIndexs { get; }

        public int LeftCount { get; }

        public int RightCount { get; }

        public string TemplateSorce { get; }
    }

    public interface IArgsTemplate<K, V>
    {
        INode<K, V> Node { get; }
        String NewTemplateSorce { get; }
        object SenderArgs { get; }
        int Weight { get; }
    }

    /// <summary>
    /// 多个空位参数
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class ArgsTemplate<K, V> : IArgsTemplate<K, V>
    {
       
        public ArgsTemplate(INode<K, V> node, string templateStr, int position, string symbol, object senderArgs)
        {
            //_senderArgs = senderArgs;
            Node = node;
            string begin = templateStr.Substring(0, position - 1);
            string end = templateStr.Substring(position);
            NewTemplateSorce = begin + symbol + end;
            if (NewTemplateSorce.Length%2==1 && NewTemplateSorce.Length !=1)
            {
                int zj = int.Parse((NewTemplateSorce.Length / 2).ToString());
                var _newStr = NewTemplateSorce.Insert(zj - 1, "-");

                string[] chars =_newStr.Split('-');
                if (chars[0].Split('+').Length > chars[1].Split('+').Length)
                {
                    if (position < chars[0].Length)
                    {
                        Weight = 1;
                    }
                    else if (position == chars[0].Length)
                    {
                        Weight = 2;
                    }
                }
                if (chars[0].Split('+').Length < chars[1].Split('+').Length)
                {
                    if (position > chars[0].Length)
                    {
                        Weight = 1;
                    }
                    else if (position == chars[0].Length)
                    {
                        Weight = 2;
                    }
                }
                //int zj = int.Parse((NewTemplateSorce.Length / 2).ToString())-1;
                //char[] chars = NewTemplateSorce.ToCharArray();
                //for (int i = 0; i < chars.Length; i++)
                //{
                //    if (i == zj)
                //    {

                //    }
                //}
            }
            SenderArgs = senderArgs;
        }
        //private string GetString(Char[] arrays)
        //{
        //    string result = "";
        //    foreach (var _a in arrays)
        //    {
        //        result += _a;
        //    }
        //    return result;
        //}

        public INode<K, V> Node { get; }

        public string NewTemplateSorce { get; }

        public object SenderArgs { get; }

        public int Weight{ get; private set; }
    }

    public interface IStrategyArgs<K, V>
    {
        int TemplateScore { get; }
        List<IArgsTemplate<K, V>> StrategyIndexs { get; }
    }

    /// <summary>
    /// 策略参数
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class StrategyArgs<K, V> : IStrategyArgs<K, V> where V : ILRUNodeToString, INodeDirection<K>, INodeSerach, INodeCopy<V>
    {
        public StrategyArgs(int templateScore, List<IArgsTemplate<K, V>> strategyIndexs)
        {
            TemplateScore = templateScore;
            StrategyIndexs = strategyIndexs;
        }

        public int TemplateScore { get; }

        public List<IArgsTemplate<K, V>> StrategyIndexs { get; }
        public ScoreEntity<K, V> ParentScoreEntity;
    }



}
