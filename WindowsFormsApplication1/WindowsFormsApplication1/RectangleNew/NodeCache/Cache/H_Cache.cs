using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew
{
    public abstract class H_Cache<K, V>: CacheBase<K, V> where V : ILRUNodeToString, INodeDirection<K>
    {
        //protected Dictionary<K, Node<K, V>> map;
        //protected NodeMultiway<K, V> list;
        //protected int Captity;
        public H_Cache(int captity) : base(captity)
        {
        }
        //public H_Cache(int captity) : this()
        //{
        //    Captity = captity;
        //}
        //public H_Cache()
        //{
        //    this.map = new Dictionary<K, Node<K, V>>();
        //    this.list = new NodeMultiway<K, V>();
        //}

        protected override void FirstExce(Node<K, V> node)
        {
            H_list.H_AddNode(node);
            H_map.Add(node.Key, node);
        }
        protected Node<K, V> H_CreateNodeReturn(K key,V value)
        {
            if (H_map.ContainsKey(key))
            {
                return H_map[key];
            }
            else
                return new Node<K, V>(key,value);
        }
        protected bool IsCheckMap(K key)
        {
            return !H_map.ContainsKey(key);
        }
        /// <summary>
        /// 没有
        /// 有
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected V H_GetV(K key)
        {
            if (!H_map.ContainsKey(key))
            {
                return default(V);
            }
            else
            {
                V value = H_map[key].Value;
                H_Push(key, value);
                return value;
            }
        }
        protected void H_Push(K key, V value)
        {
            if (!this.IsCheckMap(key)) return;
            Node<K, V> _new = H_Push_NewNode(key, value);
            H_list.H_AddNode(_new);
            if (!H_map.ContainsKey(key))
            {
                H_map.Add(key, _new);
                base.AddNodeComplate(key,_new);
                H_PushComplate(_new);
            }
        }
        protected void H_Push(Node<K, V> CurrentNode,K key, V value)
        {
            if (!this.IsCheckMap(key)) return;
            Node<K, V> _new = H_Push_NewNode(key, value);
            H_list.H_InsertNode(CurrentNode, _new);
            if (!H_map.ContainsKey(key))
            {
                H_map.Add(key, _new);
                base.AddNodeComplate(key, _new);
                H_PushComplate(_new);
            }
        }

        protected abstract void H_PushComplate(Node<K, V> node);

        protected virtual Node<K, V> H_Push_NewNode(K key, V value)
        {
            Node<K, V> _new = H_NewNode(key, value);
            return _new;
        }

        protected abstract Node<K, V>  H_NewNode(K key, V value);
        

        #region test
        //public void WirteLineNext()
        //{
        //    //H_list.WirteLineNext();
        //}
        //public void WirteLinePre()
        //{
        //    //H_list.WirteLinePre();
        //}
        #endregion
    }
}
