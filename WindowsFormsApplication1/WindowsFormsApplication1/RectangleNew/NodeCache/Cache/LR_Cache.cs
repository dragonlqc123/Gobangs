using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew
{
    public abstract class LR_Cache<K, V>: S_Cache<K, V> where V : ILRUNodeToString, INodeDirection<K>, INodeSerach, INodeCopy<V>
    {
        public LR_Cache(int captity) : base(captity)
        {
        }

        protected override void FirstExce(Node<K, V> node)
        {
            LR_list.LR_AddNode(node);
            LR_map.Add(node.Key, node);
            base.FirstExce(node);
        }

        protected Node<K, V> LR_CreateNodeReturn(K key, V value)
        {
            if (LR_map.ContainsKey(key))
            {
                return LR_map[key];
            }
            else
                return new Node<K, V>(key, value);
        }
        protected bool IsCheckMap(K key)
        {
            return !LR_map.ContainsKey(key);
        }
        /// <summary>
        /// 没有
        /// 有
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected V LR_GetV(K key)
        {
            if (!LR_map.ContainsKey(key))
            {
                return default(V);
            }
            else
            {
                V value = LR_map[key].Value;
                LR_Push(key, value);
                return value;
            }
        }
        protected virtual void LR_Push(K key, V value)
        {
            if (!this.IsCheckMap(key)) return;
            Node<K, V> _new = LR_Push_NewNode(key, value);

            LR_list.LR_AddNode(_new);
            if (!LR_map.ContainsKey(key))
            {
                LR_map.Add(key, _new);
                base.AddNodeComplate(key, _new);
                LR_PushComplate(_new);
            }
        }
        protected void LR_Push(Node<K, V> CurrentNode, K key, V value)
        {
            if (!this.IsCheckMap(key)) return;
            Node<K, V> _new = LR_Push_NewNode(key, value);

            LR_list.LR_InsertNode(CurrentNode,_new);
            if (!LR_map.ContainsKey(key))
            {
                LR_map.Add(key, _new);
                base.AddNodeComplate(key, _new);
                LR_PushComplate(_new);
            }
        }

        protected abstract void LR_PushComplate(Node<K, V> node);
        protected virtual Node<K, V> LR_Push_NewNode(K key, V value)
        {
            Node<K, V> _new = LR_NewNode(key, value);
            return _new;
        }

        protected abstract Node<K, V> LR_NewNode(K key, V value);
        #region test
        //public void WirteLineNext()
        //{
        //    //LR_list.WirteLineNext();
        //}
        //public void WirteLinePre()
        //{
        //    //LR_list.WirteLinePre();
        //}
        #endregion
    }
}
