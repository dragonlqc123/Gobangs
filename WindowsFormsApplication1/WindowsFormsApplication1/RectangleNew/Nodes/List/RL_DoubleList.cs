using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew
{
    public abstract class RL_DoubleList<K, V> : LR_DoubleList<K, V> where V : ILRUNodeToString, INodeDirection<K>
    {
        public Node<K, V> RL_CNode;
        public Node<K, V> RL_Head;
        public Node<K, V> RL_Tail;
        private int RL_size;

        public void RL_AddNode(Node<K, V> node)
        {
            if (RL_Head == null)
            {
                RL_Head = node;
                RL_CNode = node;
                RL_Tail = node;
                RL_size = 1;
            }
            else
            {
                RL_CNode = RL_Tail;
                RL_Tail = node;
                RL_Tail.R_RU = RL_CNode;
                RL_CNode.R_LD = RL_Tail;
                RL_size += 1;
            }
        }

        public void RL_InsertNode(Node<K, V> currentNode, Node<K, V> new_Node)
        {
            currentNode.R_LD = new_Node;
            new_Node.R_RU = currentNode;
            RL_size += 1;
        }

        public void RL_Remove(Node<K, V> node)
        {
            node.R_RU.R_LD = node.R_LD;
            // 如果是Tail，需要特殊判断
            if (node.R_LD != null)
            {
                node.R_LD.R_RU = node.R_RU;
            }
            else
            {
                RL_Tail = node.R_RU;
            }
            RL_size -= 1;
        }

        public Node<K, V> RL_RemoveLastNode()
        {
            Node<K, V> last = RL_Tail;
            RL_Tail.R_RU.R_LD = null;
            RL_Tail = RL_Tail.R_RU;
            RL_size -= 1;
            return last;
        }

        public int RL_Size()
        {
            return RL_size;
        }
        #region test
        public void RL_WirteLine_R_RU()
        {
            RL_WirteLine_R_RU(RL_Head);
            Console.WriteLine("总共：" + RL_size + "个");
        }

        public void RL_WirteLine_R_RU(Node<K, V> node)
        {
            if (node != null)
            {
                Console.WriteLine("左下："+node.ToString() + " ");
            }
            if (node.R_LD != null)
                RL_WirteLine_R_RU(node.R_LD);
        }
        public void RL_WirteLine1_R_RU(Node<K, V> node)
        {
            if (node.R_LD != null)
                RL_WirteLine_R_RU(node.R_LD);
        }
        public void RL_WirteLine_R_LD()
        {
            RL_WirteLine_R_LD(RL_Tail);
            Console.WriteLine("总共：" + RL_size + "个");
        }

        public void RL_WirteLine_R_LD(Node<K, V> node)
        {
            if (node != null)
            {
                Console.WriteLine("右上：" + node.ToString() + " ");
            }
            if (node.R_RU != null)
                RL_WirteLine_R_LD(node.R_RU);
        }
        public void RL_WirteLine1_R_LD(Node<K, V> node)
        {
            if (node.R_RU != null)
                RL_WirteLine_R_LD(node.R_RU);
        }
        #endregion
    }

}
