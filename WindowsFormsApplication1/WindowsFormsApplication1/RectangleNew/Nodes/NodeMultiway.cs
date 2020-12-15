using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew
{
    public class NodeMultiway<K, V> : RL_DoubleList<K, V> where V : ILRUNodeToString, INodeDirection<K>, INodeSerach, INodeCopy<V>
    {
        private SearchTest<K> _searchDelegate;
        
        public NodeMultiway<K, V> GetAllDirection(Node<K, V> node, object obj)
        {
            NodeMultiway<K, V> nodeMultiway = new NodeMultiway<K, V>();
            base.H_Line(node, obj,nodeMultiway);
            base.S_Line(node, obj, nodeMultiway);
            base.LR_Line(node, obj, nodeMultiway);
            base.RL_Line(node, obj, nodeMultiway);
            return nodeMultiway;
        }

        public NodeMultiway<K, V> GetAllDirection(Node<K, V> node, object obj, SearchTest<K> searchDelegate)
        {
            _searchDelegate = searchDelegate;
            InitRegister();
            return GetAllDirection(node, obj);
        }

        protected void Test(V value)
        {
            _searchDelegate(value);
        }

        private void InitRegister()
        {
            InitRegister(Test);
        }
        private void InitRegister(SeachePath<V> seachePath)
        {
            L_Path = new SeachePath<V>(seachePath);
            R_Path = new SeachePath<V>(seachePath);
            U_Path = new SeachePath<V>(seachePath);
            D_Path = new SeachePath<V>(seachePath);
            L_LU_Path = new SeachePath<V>(seachePath);
            L_RD_Path = new SeachePath<V>(seachePath);
            R_RU_Path = new SeachePath<V>(seachePath);
            R_LD_Path = new SeachePath<V>(seachePath);
        }
    }
}
