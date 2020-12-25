using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew.Rectangles
{
    public interface IRectangle<K, V> : IAbstractCache<K, V> where V : EntityData<K>, INodeCopy<V>
    {
        void AddNode(K key, V value);
         V Analysis(K key, object condition);
         V TestAnalysis(K key, object condition, SearchTest<K> searchTest);
        V Analysis(object attackCondition, object defenseCondition, GetAll<K> getAll, K key);
        //ScatterNode ScatterNode { get;}
        void TestWriteLineAll();
        void WriteLineAllDESC();
        void WriteLineAllASC();
        void WriteLine(Direction direction, Sort sort, K key);
        void WriteLineAll(K key);
        bool CheckVictory(K key, object condition);
    }
}
