using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew.Rectangles
{

    public class Rectangle<K, V> : NodeMultiwayCache<K, V>, IRectangle<K, V> where V : EntityData<K>, INodeCopy<V>
    {
        private ScatterNode ScatterNode { get; }
        protected Rectangle(int captity) : base(captity)
        {

        }
        public Rectangle(int captity, ScatterNode scatterNode) : this(captity)
        {
            ScatterNode = scatterNode;
        }
        public void AddNode(K key, V value)
        {
            this.AddFirstNode(key, value);
        }

        protected override V GetScatterNode(K key)
        {
            return (V)ScatterNode(key);
        }

        public void Analysis(K key, object condition)
        {
            var _a = base.SeacheNodes(key, condition);
        }

        #region Console
        public void TestWriteLineAll()
        {
            base.WriteLine(Direction.H, Sort.ASC);
            base.WriteLine(Direction.H, Sort.DESC);
            base.WriteLine(Direction.S, Sort.ASC);
            base.WriteLine(Direction.S, Sort.DESC);
            base.WriteLine(Direction.LR, Sort.ASC);
            base.WriteLine(Direction.LR, Sort.DESC);
            base.WriteLine(Direction.RL, Sort.ASC);
            base.WriteLine(Direction.RL, Sort.DESC);
        }
        public void WriteLineAllDESC()
        {

            base.WriteLine(Direction.H, Sort.DESC);
            base.WriteLine(Direction.S, Sort.DESC);
            base.WriteLine(Direction.LR, Sort.DESC);
            base.WriteLine(Direction.RL, Sort.DESC);
        }
        public void WriteLineAllASC()
        {
            base.WriteLine(Direction.H, Sort.ASC);
            base.WriteLine(Direction.S, Sort.ASC);
            base.WriteLine(Direction.LR, Sort.ASC);
            base.WriteLine(Direction.RL, Sort.ASC);
        }

        public void WriteLineAll(K key)
        {
            var node = Summary_GetNode(key);
            base.WriteLine(Direction.H, Sort.ASC, node);
            base.WriteLine(Direction.H, Sort.DESC, node);
            Console.WriteLine();
            base.WriteLine(Direction.S, Sort.ASC, node);
            base.WriteLine(Direction.S, Sort.DESC, node);
            Console.WriteLine();
            base.WriteLine(Direction.LR, Sort.ASC, node);
            base.WriteLine(Direction.LR, Sort.DESC, node);
            Console.WriteLine();
            base.WriteLine(Direction.RL, Sort.ASC, node);
            base.WriteLine(Direction.RL, Sort.DESC, node);
            Console.WriteLine();
        }
        public void WriteLine(Direction direction, Sort sort, K key)
        {
            var node = Summary_GetNode(key);
            base.WriteLine(direction, sort, node);
        }


        public void TestAnalysis(K key, object condition, SearchTest<K> searchTest)
        {
            base.TestSeacheNodes(key, condition, searchTest);
        }
        #endregion
    }



}
