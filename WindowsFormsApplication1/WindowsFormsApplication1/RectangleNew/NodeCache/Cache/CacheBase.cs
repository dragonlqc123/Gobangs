using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew
{
    public abstract class CacheBase<K, V> : AbstractCache<K, V> where V : ILRUNodeToString, INodeDirection<K>, INodeSerach, INodeCopy<V>
    {
        public CacheBase(int captity) : base(captity)
        {
        }

        public void AddFirstNode(K key, V value)
        {
            Node<K, V> node = AddFirstExce(key, value);
            FirstExce(node);
            base.AddNodeComplate(key, node);
            AddFirstNodeComplate(node);
        }

        protected abstract void AddFirstNodeComplate(Node<K, V> node);

        private Node<K, V> AddFirstExce(K key, V value)
        {
            Node<K, V> _new = First_Push_NewNode(key, value);
            return _new;
        }
        protected abstract void FirstExce(Node<K, V> node);
        protected virtual Node<K, V> First_Push_NewNode(K key, V value)
        {
            Node<K, V> _new = First_NewNode(key, value);
            return _new;
        }
        protected abstract Node<K, V> First_NewNode(K key, V value);

    }
}
