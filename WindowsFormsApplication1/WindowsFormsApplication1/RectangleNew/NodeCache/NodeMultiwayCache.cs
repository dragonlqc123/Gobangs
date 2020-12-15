using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew
{
    public abstract class NodeMultiwayCache<K, V> : RL_Cache<K, V> where V : ILRUNodeToString, INodeDirection<K>, INodeSerach, INodeCopy<V>
    {
        #region 
        public NodeMultiwayCache(int captity) : base(captity)
        {
        }

        #region 创建新节点
        protected override Node<K, V> H_NewNode(K key, V value)
        {
            //return H_CreateNodeReturn(key, value);
            return CreateNodeReturn(key, value);
        }

        protected override Node<K, V> LR_NewNode(K key, V value)
        {
            //return LR_CreateNodeReturn(key, value);
            return CreateNodeReturn(key, value);
        }

        protected override Node<K, V> RL_NewNode(K key, V value)
        {
            //return RL_CreateNodeReturn(key, value);
            return CreateNodeReturn(key, value);
        }

        protected override Node<K, V> S_NewNode(K key, V value)
        {
            //return S_CreateNodeReturn(key, value);
            return CreateNodeReturn(key, value);
        }
        #endregion

        protected override void H_PushComplate(Node<K, V> node)
        {
            //H_Scatter(node);
            Scatter(node);
        }

        protected override void S_PushComplate(Node<K, V> node)
        {
            //S_Scatter(node);
            Scatter(node);
        }
        protected override void LR_PushComplate(Node<K, V> node)
        {
            //LR_Scatter(node);
            Scatter(node);
        }

        protected override void RL_PushComplate(Node<K, V> node)
        {
            //RL_Scatter(node);
            Scatter(node);
        }


        #endregion

        protected override Node<K, V> First_NewNode(K key, V value)
        {
            return base.CreateNodeReturn( key,  value);
        }

        protected override void AddFirstNodeComplate(Node<K, V> node)
        {
            Scatter(node);
        }

        private void H_Scatter(Node<K, V> node)
        {
            //var _LNew = GetScatterNode(node.Value._L);
            //if (_LNew != null)
            //{
            //    H_Push(node.Value._L, _LNew);
            //}
            var _RNew = GetScatterNode(node.Value._R);
            if (_RNew != null)
            {
                H_Push(node, node.Value._R, _RNew);
            }
        }
        private void S_Scatter(Node<K, V> node)
        {
            //var _UNew = GetScatterNode(node.Value._U);
            //if (_UNew != null)
            //{
            //    S_Push( node.Value._U, _UNew);
            //}
            var _DNew = GetScatterNode(node.Value._D);
            if (_DNew != null)
            {
                S_Push(node, node.Value._D, _DNew);
            }
        }

        private void LR_Scatter(Node<K, V> node)
        {
            //var _L_LUNew = GetScatterNode(node.Value._L_LU);
            //if (_L_LUNew != null)
            //{
            //    LR_Push(node.Value._L_LU, _L_LUNew);
            //}
            var _L_RDNew = GetScatterNode(node.Value._L_RD);
            if (_L_RDNew != null)
            {
                LR_Push(node, node.Value._L_RD, _L_RDNew);
            }
        }
        private void RL_Scatter(Node<K, V> node)
        {
            //var _R_RUNew = GetScatterNode(node.Value._R_RU);
            //if (_R_RUNew != null)
            //{
            //    RL_Push(node.Value._R_RU, _R_RUNew);
            //}
            var _R_LDNew = GetScatterNode(node.Value._R_LD);
            if (_R_LDNew != null)
            {
                RL_Push(node, node.Value._R_LD, _R_LDNew);
            }
        }

        private void Scatter(Node<K, V> node)
        {
            H_Scatter(node);
            S_Scatter(node);
            LR_Scatter(node);
            RL_Scatter(node);
        }

        protected abstract V GetScatterNode(K key);
    }
}
