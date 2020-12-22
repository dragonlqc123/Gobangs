using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew
{
    public class Node<K, V>: INode<K, V> where V : ILRUNodeToString,INodeDirection<K>, INodeSerach, INodeCopy<V>
    {
        public Node<K, V> L { get; set; }
        public Node<K, V> R { get; set; }

        public Node<K, V> U { get; set; }
        public Node<K, V> D { get; set; }

        public Node<K, V> L_LU { get; set; }
        public Node<K, V> L_RD { get; set; }


        public Node<K, V> R_RU { get; set; }
        public Node<K, V> R_LD { get; set; }
        
        public K Key { get; }
        public V Value { get; }

        public Node(K key, V value)
        {
            Key = key;
            Value = value;
        }
        
        #region INodeSerach
        public bool SerchNode(object senderArgs)
        {
            return Value.SerchNode(senderArgs);
        }
        #endregion

        #region test
        public override string ToString()
        {
            return Value.ToString();
        }

        public string ToIdentification(object senderArgs)
        {
            return Value.ToIdentification(senderArgs);
        }
       
        public Node<K, V> Copy()
        {
            if (Value != null)
            {
                Node<K, V> node = _Copy(this);
                CopyL(node, this);
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

        public Node<K, V> Copy(object senderArgs)
        {
            if (Value != null)
            {
                Node<K, V> node = _Copy(this, senderArgs);
                if (node == null) return null; 
                CopyL(node, this, senderArgs);
                CopyR(node, this, senderArgs);
                CopyU(node, this, senderArgs);
                CopyD(node, this, senderArgs);
                CopyL_LU(node, this, senderArgs);
                CopyL_RD(node, this, senderArgs);
                CopyR_LD(node, this, senderArgs);
                CopyR_RU(node, this, senderArgs);
                return node;
            }
            else
                return null;
        }

        #region 复制
        private Node<K, V> _Copy(Node<K, V> node, object senderArgs)
        {
            if (Value != null && node.SerchNode(senderArgs))
            {
                Node<K, V> _node = new Node<K, V>(node.Key, node.Value.Copy());
                return _node;
            }
            else
                return null;
        }
        private void CopyL(Node<K, V> node, Node<K, V> nodeOld, object senderArgs)
        {
            if (nodeOld.L != null && !nodeOld.L.Key.Equals(nodeOld.Key))
            {
                node.L = _Copy(nodeOld.L, senderArgs);
                if (node.L == null) return;
                CopyL(node.L, nodeOld.L, senderArgs);
            }
        }

        private void CopyR(Node<K, V> node, Node<K, V> nodeOld, object senderArgs)
        {
            if (nodeOld.R != null && !nodeOld.R.Key.Equals(nodeOld.Key))
            {
                node.R = _Copy(nodeOld.R, senderArgs);
                if (node.R == null) return;
                CopyR(node.R, nodeOld.R, senderArgs);
            }
        }

        private void CopyU(Node<K, V> node, Node<K, V> nodeOld, object senderArgs)
        {
            if (nodeOld.U != null && !nodeOld.U.Key.Equals(nodeOld.Key))
            {
                node.U = _Copy(nodeOld.U, senderArgs);
                if (node.U == null) return;
                CopyU(node.U, nodeOld.U, senderArgs);
            }
        }
        private void CopyD(Node<K, V> node, Node<K, V> nodeOld, object senderArgs)
        {
            if (nodeOld.D != null && !nodeOld.D.Key.Equals(nodeOld.Key))
            {
                node.D = _Copy(nodeOld.D, senderArgs);
                if (node.D == null) return;
                CopyD(node.D, nodeOld.D, senderArgs);
            }
        }

        private void CopyL_LU(Node<K, V> node, Node<K, V> nodeOld, object senderArgs)
        {
            if (nodeOld.L_LU != null && !nodeOld.L_LU.Key.Equals(nodeOld.Key))
            {
                node.L_LU = _Copy(nodeOld.L_LU, senderArgs);
                if (node.L_LU == null) return;
                CopyL_LU(node.L_LU, nodeOld.L_LU, senderArgs);
            }
        }

        private void CopyL_RD(Node<K, V> node, Node<K, V> nodeOld, object senderArgs)
        {
            if (nodeOld.L_RD != null && !nodeOld.L_RD.Key.Equals(nodeOld.Key))
            {
                node.L_RD = _Copy(nodeOld.L_RD, senderArgs);
                if (node.L_RD == null) return;
                CopyL_RD(node.L_RD, nodeOld.L_RD, senderArgs);
            }
        }

        private void CopyR_LD(Node<K, V> node, Node<K, V> nodeOld, object senderArgs)
        {
            if (nodeOld.R_LD != null && !nodeOld.R_LD.Key.Equals(nodeOld.Key))
            {
                node.R_LD = _Copy(nodeOld.R_LD, senderArgs);

                if (node.R_LD == null) return;
                CopyR_LD(node.R_LD, nodeOld.R_LD, senderArgs);
            }
        }
        private void CopyR_RU(Node<K, V> node, Node<K, V> nodeOld, object senderArgs)
        {
            if (nodeOld.R_RU != null && !nodeOld.R_RU.Key.Equals(nodeOld.Key))
            {
                node.R_RU = _Copy(nodeOld.R_RU, senderArgs);

                if (node.R_RU == null) return;
                CopyR_RU(node.R_RU, nodeOld.R_RU, senderArgs);
            }
        }
        #endregion
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
            if (nodeOld.L != null && !nodeOld.L.Key.Equals(nodeOld.Key))
            {
                node.L = _Copy(nodeOld.L);
                CopyL(node.L, nodeOld.L);
            }
        }

        private void CopyR(Node<K, V> node, Node<K, V> nodeOld)
        {
            if (nodeOld.R != null && !nodeOld.R.Key.Equals(nodeOld.Key))
            {
                node.R = _Copy(nodeOld.R);
                CopyR(node.R, nodeOld.R);
            }
        }

        private void CopyU(Node<K, V> node, Node<K, V> nodeOld)
        {
            if (nodeOld.U != null && !nodeOld.U.Key.Equals(nodeOld.Key))
            {
                node.U = _Copy(nodeOld.U);
                CopyU(node.U, nodeOld.U);
            }
        }
        private void CopyD(Node<K, V> node, Node<K, V> nodeOld)
        {
            if (nodeOld.D != null && !nodeOld.D.Key.Equals(nodeOld.Key))
            {
                node.D = _Copy(nodeOld.D);
                CopyD(node.D, nodeOld.D);
            }
        }

        private void CopyL_LU(Node<K, V> node, Node<K, V> nodeOld)
        {
            if (nodeOld.L_LU != null && !nodeOld.L_LU.Key.Equals(nodeOld.Key))
            {
                node.L_LU = _Copy(nodeOld.L_LU);
                CopyL_LU(node.L_LU, nodeOld.L_LU);
            }
        }

        private void CopyL_RD(Node<K, V> node, Node<K, V> nodeOld)
        {
            if (nodeOld.L_RD != null && !nodeOld.L_RD.Key.Equals(nodeOld.Key))
            {
                node.L_RD = _Copy(nodeOld.L_RD);
                CopyL_RD(node.L_RD, nodeOld.L_RD);
            }
        }

        private void CopyR_LD(Node<K, V> node, Node<K, V> nodeOld)
        {
            if (nodeOld.R_LD != null && !nodeOld.R_LD.Key.Equals(nodeOld.Key))
            {
                node.R_LD = _Copy(nodeOld.R_LD);
                CopyR_LD(node.R_LD, nodeOld.R_LD);
            }
        }
        private void CopyR_RU(Node<K, V> node, Node<K, V> nodeOld)
        {
            if (nodeOld.R_RU != null && !nodeOld.R_RU.Key.Equals(nodeOld.Key))
            {
                node.R_RU = _Copy(nodeOld.R_RU);
                CopyR_RU(node.R_RU, nodeOld.R_RU);
            }
        }
        #endregion
        #endregion



    }

    public interface INode<K,V>
    {
        K Key { get; }
        V Value { get; }
    }
    public interface ILRUNodeToString
    {
        string ToString();
        string ToIdentification(object senderArgs);
        string Symbol();
        bool IsIllegalSymbol(object senderArgs);
        string IllegalSymbol();
        string EmptySymbol();

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
        bool SerchNode(object senderArgs);
    }
    public interface INodeSerach<ConditionType>
    {
       bool SerchNode(ConditionType senderArgs);
    }
}
