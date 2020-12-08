using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.lru
{
    public class LRUCache
    {
        private int captity;
        public DoubleList list;
        public Dictionary<int, Node> map;

        public LRUCache(int captity)
        {
            this.captity = captity;
            list = new DoubleList();
            map = new Dictionary<int, Node>();

        }

        /// <summary>
        /// 没有
        /// 有
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object Get(int key)
        {
            if (!map.ContainsKey(key))
            {
                return -1;
            }
            else
            {
                object res = map[key].values;
                Push(key, res);
                return res;
            }
        }

        public void Push(int key ,object val)
        {
            Node node = new Node(key,val);
            if (map.ContainsKey(key))
            {
                list.Remove(map[key]);
                map.Remove(key);
                list.AddFirstNode(node);
                map.Add(key, node);
            }
            else
            {
                if (captity < list.Size())
                {
                    Node last = list.RemoveLast();
                    map.Remove(last.key);
                }
                list.AddFirstNode(node);
                map.Add(key, node);
            }
        }

        public void WirteLineNext()
        {
            list.WirteLineNext();
        }
        public void WirteLinePre()
        {
            list.WirteLinePre();
        }
    }
}
