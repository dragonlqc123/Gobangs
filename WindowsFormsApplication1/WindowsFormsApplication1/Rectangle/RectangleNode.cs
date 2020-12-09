using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.lru.Rectangle
{
    public class RectangleNode<K, V> where V : ILRUNodeToString
    {
        LRUCache<K, V> H;
        LRUCache<K, V> S;
        LRUCache<K, V> RX;
        LRUCache<K, V> YX;

        public RectangleNode()
        {
            H = new LRUCache<K, V>();
            S = new LRUCache<K, V>();
            RX = new LRUCache<K, V>();
            YX = new LRUCache<K, V>();
        }

        public void Add(string type,K key,V value)
        {
            if (type == "H")
            {
                H.Push(key,value);
            }
            else if (type == "S")
            {
                S.Push(key, value);
            }
            else if (type == "RX")
            {
                RX.Push(key, value);
            }
            else if (type == "YX")
            {
                YX.Push(key, value);
            }

        }

    }
}
