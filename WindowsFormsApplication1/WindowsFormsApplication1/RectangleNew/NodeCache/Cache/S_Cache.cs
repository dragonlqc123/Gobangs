using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew
{
    public abstract class S_Cache<K, V> : H_Cache<K, V> where V : ILRUNodeToString, INodeDirection<K>, INodeSerach, INodeCopy<V>
    {
        public S_Cache(int captity) : base(captity)
        {
        }

        protected Node<K, V> S_CreateNodeReturn(K key, V value)
        {
            if (S_map.ContainsKey(key))
            {
                return S_map[key];
            }
            else
                return new Node<K, V>(key, value);
        }
        protected override void FirstExce(Node<K, V> node)
        {
            S_list.S_AddNode(node);
            S_map.Add(node.Key, node);
            base.FirstExce(node);
        }
        protected  bool IsCheckMap(K key)
        {
            return !S_map.ContainsKey(key);
        }
        /// <summary>
        /// 没有
        /// 有
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected V S_GetV(K key)
        {
            if (!S_map.ContainsKey(key))
            {
                return default(V);
            }
            else
            {
                V value = S_map[key].Value;
                S_Push(key, value);
                return value;
            }
        }
        protected virtual void S_Push(K key, V value)
        {
            if (!this.IsCheckMap(key)) return;
            Node<K, V> _new = S_Push_NewNode(key, value);
            S_list.S_AddNode(_new);
            if (!S_map.ContainsKey(key))
            {
                S_map.Add(key, _new);
                base.AddNodeComplate(key, _new);
                S_PushComplate(_new);
            }
        }
        protected void S_Push(Node<K, V> CurrentNode, K key, V value)
        {
            if (!this.IsCheckMap(key)) return;
            Node<K, V> _new = S_Push_NewNode(key, value);

            S_list.S_InsertNode(CurrentNode,_new);
            if (!S_map.ContainsKey(key))
            {
                S_map.Add(key, _new);
                base.AddNodeComplate(key, _new);
                S_PushComplate(_new);
            }
        }

        protected abstract void S_PushComplate(Node<K, V> node);
        protected virtual Node<K, V> S_Push_NewNode(K key, V value)
        {
            Node<K, V> _new = S_NewNode(key, value);
            return _new;
        }
        protected abstract Node<K, V> S_NewNode(K key, V value);
        #region test
        //public void WirteLineNext()
        //{
        //    //S_list.WirteLineNext();
        //}
        //public void WirteLinePre()
        //{
        //    //S_list.WirteLinePre();
        //}
        #endregion
    }
}
