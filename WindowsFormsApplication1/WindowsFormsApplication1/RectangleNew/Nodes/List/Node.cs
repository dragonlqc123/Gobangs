using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew
{
    public class Node<K, V> where V : ILRUNodeToString,INodeDirection<K>, INodeSerach, INodeCopy<V>
    {
        public Node<K, V> L { get; set; }
        public Node<K, V> R { get; set; }

        public Node<K, V> U { get; set; }
        public Node<K, V> D { get; set; }

        public Node<K, V> L_LU { get; set; }
        public Node<K, V> L_RD { get; set; }


        public Node<K, V> R_RU { get; set; }
        public Node<K, V> R_LD { get; set; }
        
        public K Key;
        public V Value;

        public Node(K key, V value)
        {
            Key = key;
            Value = value;
        }
        
        #region INodeSerach
        public bool SerchNode(object conditionType)
        {
            return Value.SerchNode(conditionType);
        }
        #endregion

        #region test
        public override string ToString()
        {
            return Value.ToString();
        }

        public Node<K, V> Copy()
        {
            if (Value != null)
            {
                Node<K, V> node = _Copy(this);
                CopyL(node,this);
                CopyR(node, this);
                CopyU(node, this);
                CopyD(node, this);
                CopyL_LU(node, this);
                CopyL_RD(node, this);
                CopyR_LD(node, this);
                CopyR_RU(node, this);
                return node;
            }
            else
                return null;
        }
        #region 复制
        private Node<K, V> _Copy(Node<K, V> node)
        {
            if (Value != null)
            {
                Node<K, V> _node = new Node<K, V>(node.Key, node.Value.Copy());
                return _node;
            }
            else
                return null;
        }
        private void CopyL(Node<K, V> node, Node<K, V> nodeOld)
        {
            if (nodeOld.L != null)
            {
                node.L = _Copy(nodeOld.L);
                CopyL(node.L, nodeOld.L);
            }
        }

        private void CopyR(Node<K, V> node, Node<K, V> nodeOld)
        {
            if (nodeOld.R != null)
            {
                node.R = _Copy(nodeOld.R);
                CopyR(node.R, nodeOld.R);
            }
        }

        private void CopyU(Node<K, V> node, Node<K, V> nodeOld)
        {
            if (nodeOld.U != null)
            {
                node.U = _Copy(nodeOld.U);
                CopyU(node.U, nodeOld.U);
            }
        }
        private void CopyD(Node<K, V> node, Node<K, V> nodeOld)
        {
            if (nodeOld.D != null)
            {
                node.D = _Copy(nodeOld.D);
                CopyD(node.D, nodeOld.D);
            }
        }

        private void CopyL_LU(Node<K, V> node, Node<K, V> nodeOld)
        {
            if (nodeOld.L_LU != null)
            {
                node.L_LU = _Copy(nodeOld.L_LU);
                CopyL_LU(node.L_LU, nodeOld.L_LU);
            }
        }

        private void CopyL_RD(Node<K, V> node, Node<K, V> nodeOld)
        {
            if (nodeOld.L_RD != null)
            {
                node.L_RD = _Copy(nodeOld.L_RD);
                CopyL_RD(node.L_RD, nodeOld.L_RD);
            }
        }

        private void CopyR_LD(Node<K, V> node, Node<K, V> nodeOld)
        {
            if (nodeOld.R_LD != null)
            {
                node.R_LD = _Copy(nodeOld.R_LD);
                CopyR_LD(node.R_LD, nodeOld.R_LD);
            }
        }
        private void CopyR_RU(Node<K, V> node, Node<K, V> nodeOld)
        {
            if (nodeOld.R_RU != null)
            {
                node.R_RU = _Copy(nodeOld.R_RU);
                CopyR_RU(node.R_RU, nodeOld.R_RU);
            }
        }
        #endregion
        #endregion
    }


    public interface ILRUNodeToString
    {
        string ToString();
    }

    /// <summary>
    /// 节点出口方向，简称：方向
    /// </summary>
    public interface INodeDirection<K>
    {
        K _L { get; }
        K _R { get;}

        K _U { get; }
        K _D { get; }

        K _L_LU { get; }
        K _L_RD { get;}


        K _R_RU { get;  }
        K _R_LD { get;}

    }

    public interface INodeCopy<V>
    {
        V Copy();
    }
    public interface INodeSerach
    {
        bool SerchNode(object conditionType);
    }
    public interface INodeSerach<ConditionType>
    {
       bool SerchNode(ConditionType conditionType);
    }
}
