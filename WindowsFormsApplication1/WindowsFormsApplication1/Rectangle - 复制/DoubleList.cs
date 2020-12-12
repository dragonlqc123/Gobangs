using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.lru.Rectangle
{
    public class DoubleList<K, V> where V : ILRUNodeToString
    {
        public Node<K, V> CNode;
        public Node<K, V> Head;
        public Node<K, V> Tail;
        private int size;
        public void AddFirstNode(Node<K, V> node)
        {
            if (Head == null)
            {
                Head = node;
                CNode = node;
                Tail = node;
                size = 1;
            }
            else
            {
                CNode = Head;
                Head = node;
                Head.Next = CNode;
                CNode.Pre = Head;
                size += 1;
            }
        }
        public void Remove(Node<K, V> node)
        {
            node.Pre.Next = node.Next;
            // 如果是Tail，需要特殊判断
            if (node.Next != null)
            {
                node.Next.Pre = node.Pre;
            }
            else
            {
                Tail = node.Pre;
            }
            size -= 1;
        }

        public Node<K, V> RemoveLastNode()
        {
            Node<K, V> last = Tail;
            Tail.Pre.Next = null;
            Tail = Tail.Pre;
            size -= 1;
            return last;
        }

        public int Size()
        {
            return size;
        }


        #region test
        public void WirteLineNext()
        {
            wirteN(Head);
            Console.WriteLine("总共：" + size + "个");
        }

        private void wirteN(Node<K, V> node)
        {
            if (node != null)
            {
                Console.WriteLine(node.ToString());
            }
            if (node.Next != null)
                wirteN(node.Next);
        }

        public void WirteLinePre()
        {
            wirteP(Tail);
            Console.WriteLine("总共：" + size + "个");
        }

        private void wirteP(Node<K, V> node)
        {
            if (node != null)
            {
                Console.WriteLine(node.ToString());
            }
            if (node.Pre != null)
                wirteP(node.Pre);
        }
        #endregion
    }
}
