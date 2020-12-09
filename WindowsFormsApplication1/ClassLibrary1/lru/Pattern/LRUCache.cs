using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.lru.Pattern
{
    public class LRUCache<K,V> where V : ILRUNodeToString
    {
        private Dictionary<K, Node<K,V>> map;
        private DoubleList<K,V> list;
        public int Captity;

        public LRUCache(int captity)
        {
            this.map = new Dictionary<K,Node<K, V>>();
            this.list = new DoubleList<K, V>();
            Captity = captity;
        }
        /// <summary>
        /// 没有
        /// 有
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public V GetV(K key)
        {
            if (!map.ContainsKey(key))
            {
                return default(V);
            }
            else
            {
                V value = map[key].Value;
                Push(key,value);
                return value;
            }
        }
        public void Push(K key, V value)
        {
            Node<K, V> _new = new Node<K, V>(key, value);

            // 存在
            if (map.ContainsKey(key))
            {
                list.Remove(map[key]);
                map.Remove(key);
                list.AddFirstNode(_new);
                map.Add(key, _new);
            }
            // 超过大小
            // 移除
            else
            {
                if (list.Size() == Captity)
                {
                    Node<K, V> node = list.RemoveLastNode();
                    map.Remove(node.Key);
                }
                list.AddFirstNode(_new);
                map.Add(key,_new);
            }
        }


        #region test
        public void WirteLineNext()
        {
            list.WirteLineNext();
        }
        public void WirteLinePre()
        {
            list.WirteLinePre();
        }
        #endregion
    }
}
