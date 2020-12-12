using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew
{
    public class Node<K, V> where V : ILRUNodeToString,INodeDirection<K>
    {
        public Node<K, V> L { get; set; }
        public Node<K, V> R { get; set; }

        public Node<K, V> U { get; set; }
        public Node<K, V> D { get; set; }

        public Node<K, V> L_LU { get; set; }
        public Node<K, V> L_RD { get; set; }


        public Node<K, V> R_RU { get; set; }
        public Node<K, V> R_LD { get; set; }
        
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

    /// <summary>
    /// 节点出口方向，简称：方向
    /// </summary>
    public interface INodeDirection<K>
    {
        K _L { get; }
        K _R { get;}

        K _U { get; }
        K _D { get; }

        K _L_LU { get; }
        K _L_RD { get;}


        K _R_RU { get;  }
        K _R_LD { get;}
    }
}
