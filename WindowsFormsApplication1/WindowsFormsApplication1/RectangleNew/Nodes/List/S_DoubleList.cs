using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew
{
    public abstract class S_DoubleList<K, V> : H_DoubleList<K, V> where V : ILRUNodeToString, INodeDirection<K>, INodeSerach, INodeCopy<V>
    {
        public Node<K, V> S_CNode;
        public Node<K, V> S_Head;
        public Node<K, V> S_Tail;
        private int S_size;

        public void S_AddNode(Node<K, V> node)
        {
            if (S_Head == null)
            {
                S_Head = node;
                S_CNode = node;
                S_Tail = node;
                S_size = 1;
            }
            else
            {
                S_CNode = S_Tail;
                S_Tail = node;
                S_Tail.U = S_CNode;
                S_CNode.D = S_Tail;
                S_size += 1;
            }
        }

        public void S_InsertNode(Node<K, V> currentNode, Node<K, V> new_Node)
        {
            currentNode.D = new_Node;
            new_Node.U = currentNode;
            S_size += 1;
        }
        public void S_Remove(Node<K, V> node)
        {
            node.U.D = node.D;
            // 如果是Tail，需要特殊判断
            if (node.D != null)
            {
                node.D.U = node.U;
            }
            else
            {
                S_Tail = node.U;
            }
            S_size -= 1;
        }

        public Node<K, V> S_RemoveLastNode()
        {
            Node<K, V> last = S_Tail;
            S_Tail.U.D = null;
            S_Tail = S_Tail.U;
            S_size -= 1;
            return last;
        }

        public int S_Size()
        {
            return S_size;
        }
        #region 根据节点找出一条线

        protected S_DoubleList<K, V> S_Line(Node<K, V> node, object obj, S_DoubleList<K, V> s_DoubleList)
        {
            //S_DoubleList<K, V> s_DoubleList = new NodeMultiway<K, V>();
            S_D(node.Copy(), obj, s_DoubleList);
            S_U(node.Copy(), obj, s_DoubleList);
            return s_DoubleList;
        }

        private void S_D(Node<K, V> node, object obj, S_DoubleList<K, V> s_DoubleList)
        {
            if (node != null)
            {
                if (node.SerchNode(obj))
                {
                    if (node.D != null)
                        S_D(node.D, obj, s_DoubleList);
                    s_DoubleList.S_AddNode(node);
                    D_Delegate(node.Value);
                }
            }
        }

        private void S_U(Node<K, V> node, object obj, S_DoubleList<K, V> s_DoubleList)
        {
            if (node.U != null)
            {
                if (node.U.SerchNode(obj))
                {
                    S_U(node.U, obj, s_DoubleList);
                    s_DoubleList.S_InsertNode(node, node.U);
                    U_Delegate(node.U.Value);
                }
            }
        }

        #endregion

        #region test
        public void S_WirteLine_U()
        {
            S_WirteLine_U(S_Head);
            Console.WriteLine("总共：" + S_size + "个");
        }

        public void S_WirteLine_U(Node<K, V> node)
        {
            if (node != null)
            {
                Console.WriteLine("下边："+node.ToString() + " ");
            }
            if (node.D != null)
                S_WirteLine_U(node.D);
        }
        public void S_WirteLine1_U(Node<K, V> node)
        {
            if (node.D != null)
                S_WirteLine_U(node.D);
        }
        public void S_WirteLine_D()
        {
            S_WirteLine_D(S_Tail);
            Console.WriteLine("总共：" + S_size + "个");
        }

        public void S_WirteLine_D(Node<K, V> node)
        {
            if (node != null)
            {
                Console.WriteLine("上边：" + node.ToString() + " ");
            }
            if (node.U != null)
                S_WirteLine_D(node.U);
        }
        public void S_WirteLine1_D(Node<K, V> node)
        {
            if (node.U != null)
                S_WirteLine_D(node.U);
        }
        #endregion
    }

}
