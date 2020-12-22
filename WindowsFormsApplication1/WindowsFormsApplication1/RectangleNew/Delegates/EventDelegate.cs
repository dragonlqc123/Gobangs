using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew
{

    public delegate void RectangAddFirstComplate(object obj);
    public delegate object ScatterNode(object key);
    public delegate void SeachePath<V>(V value);
    public delegate void SearchTest<K>(object entityData);
    public delegate CalculateTheScoreArgs<K,V> CalculateTheScore<K,V>(string identification);
    //public delegate V StrategyTheScore<K,V>(IStrategyArgs<K, V> strategyArgs);
    public delegate List<ScoreEntity<K, V>> StrategyTheScore<K,V>(IStrategyArgs<K, V> strategyArgs);
    public delegate void Displacement(int leftCount, int rightCount);
    public delegate INode<K, V> DesignativePosition<K, V>(int count);
    public delegate List<K> GetAll<K>(object attackOrdefenseCondition);
    public delegate int AnalysisRecursion<K,V>(IArgsTemplate<K, V> argsTemplate);

}
