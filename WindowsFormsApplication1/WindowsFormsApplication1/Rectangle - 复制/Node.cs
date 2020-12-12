using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Node<K, V> where V : ILRUNodeToString
    {
        public Node<K, V> Next { get; set; }
        public Node<K, V> Pre { get; set; }

        public K Key;
        public V Value;

        public Node(K key, V value)
        {
            Key = key;
            Value = value;
        }  

        #region test
        public override string ToString()
        {
            return Value.ToString();
        }
        #endregion
    }


    public interface ILRUNodeToString
    {
        string ToString();
    }
}
