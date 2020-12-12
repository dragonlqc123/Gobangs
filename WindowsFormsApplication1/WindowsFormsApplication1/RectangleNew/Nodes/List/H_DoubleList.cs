using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew
{
    public abstract class H_DoubleList<K, V> where V : ILRUNodeToString, INodeDirection<K>
    {
        public Node<K, V> H_CNode;
        public Node<K, V> H_Head;
        public Node<K, V> H_Tail;
        private int H_size;

        public void H_AddNode(Node<K, V> node)
        {
            if (H_Head == null)
            {
                H_Head = node;
                H_CNode = node;
                H_Tail = node;
                H_size = 1;
            }
            else
            {
                H_CNode = H_Tail;
                H_Tail = node;
                H_Tail.L = H_CNode;
                H_CNode.R = H_Tail;
                H_size += 1;
            }
        }
        public void H_InsertNode(Node<K, V> currentNode,Node<K, V> new_Node)
        {
            currentNode.R = new_Node;
            new_Node.L = currentNode;
            H_size += 1;
        }
        public void H_Remove(Node<K, V> node)
        {
            node.L.R = node.R;
            // 如果是Tail，需要特殊判断
            if (node.R != null)
            {
                node.R.L = node.L;
            }
            else
            {
                H_Tail = node.L;
            }
            H_size -= 1;
        }

        public Node<K, V> H_RemoveLastNode()
        {
            Node<K, V> last = H_Tail;
            H_Tail.L.R = null;
            H_Tail = H_Tail.L;
            H_size -= 1;
            return last;
        }

        public int H_Size()
        {
            return H_size;
        }
        
        #region test
        public void H_WirteLine_L()
        {
            H_WirteLine_L(H_Head);
            Console.WriteLine("总共：" + H_size + "个");
        }

        public void H_WirteLine_L(Node<K, V> node)
        {
            if (node != null)
            {
                Console.WriteLine("右边："+node.ToString()+" ");
            }
            if (node.R != null)
                H_WirteLine_L(node.R);
        }
        public void H_WirteLine1_L(Node<K, V> node)
        {
            if (node.R != null)
                H_WirteLine_L(node.R);
        }
        public void H_WirteLine_R()
        {
            H_WirteLine_R(H_Tail);
            Console.WriteLine("总共：" + H_size + "个");
        }

        public void H_WirteLine_R(Node<K, V> node)
        {
            if (node != null)
            {
                Console.WriteLine("左边："+node.ToString() + " ");
            }
            if (node.L != null)
                H_WirteLine_R(node.L);
        }

        public void H_WirteLine1_R(Node<K, V> node)
        {
            if (node.L != null)
                H_WirteLine_R(node.L);
        }
        #endregion

    }




}
