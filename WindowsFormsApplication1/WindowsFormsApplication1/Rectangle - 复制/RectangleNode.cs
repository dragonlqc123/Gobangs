using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.lru.Rectangle
{
    public class RectangleNode<K, V>: LRUCache<K, V> where V : ILRUNodeToString
    {
        //LRUCache<K, V> H;
        //LRUCache<K, V> S;
        //LRUCache<K, V> RX;
        //LRUCache<K, V> YX;

        public RectangleNode()
        {
            //H = new LRUCache<K, V>();
            //S = new LRUCache<K, V>();
            //RX = new LRUCache<K, V>();
            //YX = new LRUCache<K, V>();
        }
        List<LRUCache<K, V>> lis = new List<LRUCache<K, V>>();
        public RectangleNode(int captity) : base(captity)
        {

        }

        public void Add(string type,K key,V value)
        {
            //if (type == "H")
            //{
            //    H.Push(key,value);
            //}
            //else if (type == "S")
            //{
            //    S.Push(key, value);
            //}
            //else if (type == "RX")
            //{
            //    RX.Push(key, value);
            //}
            //else if (type == "YX")
            //{
            //    YX.Push(key, value);
            //}

        }
        int row = -1;
        public void PushB(bool isNewLine,K key, V value)
        {
            if (isNewLine == true)
            {
                row++;
                lis.Add(new LRUCache<K, V>());
            }
            lis[row].Push(key,value);
        }
        public override void Push(K key, V value)
        {
            base.Push(key, value);
        }
    }
}
