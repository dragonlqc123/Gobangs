using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew
{
    public abstract class LR_DoubleList<K, V>:S_DoubleList<K, V> where V : ILRUNodeToString, INodeDirection<K>, INodeSerach, INodeCopy<V>
    {
        public Node<K, V> LR_CNode;
        public Node<K, V> LR_Head;
        public Node<K, V> LR_Tail;
        private int LR_size;

        public void LR_AddNode(Node<K, V> node)
        {
            if (LR_Head == null)
            {
                LR_Head = node;
                LR_CNode = node;
                LR_Tail = node;
                LR_size = 1;
            }
            else
            {
                LR_CNode = LR_Tail;
                LR_Tail = node;
                LR_Tail.L_LU = LR_CNode;
                LR_CNode.L_RD = LR_Tail;
                LR_size += 1;
            }
        }

        public void LR_InsertNode(Node<K, V> currentNode, Node<K, V> new_Node)
        {
            currentNode.L_RD = new_Node;
            new_Node.L_LU = currentNode;
            LR_size += 1;
        }
        public void LR_Remove(Node<K, V> node)
        {
            node.L_LU.L_RD = node.L_RD;
            // 如果是Tail，需要特殊判断
            if (node.L_RD != null)
            {
                node.L_RD.L_LU = node.L_LU;
            }
            else
            {
                LR_Tail = node.L_LU;
            }
            LR_size -= 1;
        }

        public Node<K, V> LR_RemoveLastNode()
        {
            Node<K, V> last = LR_Tail;
            LR_Tail.L_LU.L_RD = null;
            LR_Tail = LR_Tail.L_LU;
            LR_size -= 1;
            return last;
        }

        public int LR_Size()
        {
            return LR_size;
        }
        
        #region 根据节点找出一条线

        protected LR_DoubleList<K, V> LR_Line(Node<K, V> node, object obj, LR_DoubleList<K, V> lr_DoubleList)
        {
            //LR_DoubleList<K, V> lr_DoubleList = new NodeMultiway<K, V>();
            L_RD(node.Copy(), obj, lr_DoubleList);
            L_LU(node.Copy(), obj, lr_DoubleList);
            return lr_DoubleList;
        }

        private void L_RD(Node<K, V> node, object obj, LR_DoubleList<K, V> LR_DoubleList)
        {
            if (node != null)
            {
                if (node.SerchNode(obj))
                {
                    if (node.L_RD != null)
                        L_RD(node.L_RD, obj, LR_DoubleList);
                    LR_DoubleList.LR_AddNode(node);
                    L_RD_Delegate(node.Value);
                }
            }
        }

        private void L_LU(Node<K, V> node, object obj, LR_DoubleList<K, V> LR_DoubleList)
        {
            if (node.L_LU != null)
            {
                if (node.L_LU.SerchNode(obj))
                {
                    L_LU(node.L_LU, obj, LR_DoubleList);
                    LR_DoubleList.LR_InsertNode(node, node.L_LU);
                    L_LU_Delegate(node.L_LU.Value);
                }
            }
        }

        #endregion

        #region test
        public void LR_WirteLine_L_LU()
        {
            LR_WirteLine_L_LU(LR_Head);
            Console.WriteLine("总共：" + LR_size + "个");
        }

        public void LR_WirteLine_L_LU(Node<K, V> node)
        {
            if (node != null)
            {
                Console.WriteLine("右下："+node.ToString() + " ");
            }
            if (node.L_RD != null)
                LR_WirteLine_L_LU(node.L_RD);
        }
        public void LR_WirteLine1_L_LU(Node<K, V> node)
        {
            if (node.L_RD != null)
                LR_WirteLine_L_LU(node.L_RD);
        }

        public void LR_WirteLine_L_RD()
        {
            LR_WirteLine_L_RD(LR_Tail);
            Console.WriteLine("总共：" + LR_size + "个");
        }

        public void LR_WirteLine_L_RD(Node<K, V> node)
        {
            if (node != null)
            {
                Console.WriteLine("左上："+node.ToString() + " ");
            }
            if (node.L_LU != null)
                LR_WirteLine_L_RD(node.L_LU);
        }
        public void LR_WirteLine1_L_RD(Node<K, V> node)
        {
            if (node.L_LU != null)
                LR_WirteLine_L_RD(node.L_LU);
        }
        #endregion
    }

}
