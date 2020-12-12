using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew
{
    public abstract class RL_Cache<K, V> : LR_Cache<K, V> where V : ILRUNodeToString, INodeDirection<K>
    {
        public RL_Cache(int captity) : base(captity)
        {
        }
        protected override void FirstExce(Node<K, V> node)
        {
            RL_list.RL_AddNode(node);
            RL_map.Add(node.Key, node);
            base.FirstExce(node);
        }

        protected Node<K, V> RL_CreateNodeReturn(K key, V value)
        {
            if (RL_map.ContainsKey(key))
            {
                return RL_map[key];
            }
            else
                return new Node<K, V>(key, value);
        }
        protected bool IsCheckMap(K key)
        {
            return !RL_map.ContainsKey(key);
        }
        /// <summary>
        /// 没有
        /// 有
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected V RL_GetV(K key)
        {
            if (!RL_map.ContainsKey(key))
            {
                return default(V);
            }
            else
            {
                V value = RL_map[key].Value;
                RL_Push(key, value);
                return value;
            }
        }
        protected virtual void RL_Push(K key, V value)
        {
            if (!this.IsCheckMap(key)) return;
            Node<K, V> _new = RL_Push_NewNode(key, value);

            RL_list.RL_AddNode(_new);
            if (!RL_map.ContainsKey(key))
            {
                RL_map.Add(key, _new);
                base.AddNodeComplate(key, _new);
                RL_PushComplate(_new);
            }
        }
        protected void RL_Push(Node<K, V> CurrentNode, K key, V value)
        {
            if (!this.IsCheckMap(key)) return;
            Node<K, V> _new = RL_Push_NewNode(key, value);

            RL_list.RL_InsertNode(CurrentNode,_new);
            if (!RL_map.ContainsKey(key))
            {
                RL_map.Add(key, _new);
                base.AddNodeComplate(key, _new);
                RL_PushComplate(_new);
            }
        }

        protected abstract void RL_PushComplate(Node<K, V> node);
        protected virtual Node<K, V> RL_Push_NewNode(K key, V value)
        {
            Node<K, V> _new = RL_NewNode(key, value);
            return _new;
        }
        protected abstract Node<K, V> RL_NewNode(K key, V value);
        #region test
        //public void WirteLineNext()
        //{
        //    //RL_list.WirteLineNext();
        //}
        //public void WirteLinePre()
        //{
        //    //RL_list.WirteLinePre();
        //}
        #endregion
    }
}
