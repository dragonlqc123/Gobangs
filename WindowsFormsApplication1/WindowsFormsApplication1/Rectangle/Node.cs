﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Node<K, V> where V : ILRUNodeToString
    {
        public Node<K, V> L { get; set; }
        public Node<K, V> R { get; set; }
        public Node<K, V> U { get; set; }
        public Node<K, V> D { get; set; }
       
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
