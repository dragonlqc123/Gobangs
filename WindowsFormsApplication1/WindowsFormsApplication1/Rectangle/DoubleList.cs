﻿using System;
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
                Head.R = CNode;
                CNode.L = Head;
                size += 1;
            }
        }
        public void Remove(Node<K, V> node)
        {
            node.L.R = node.R;
            // 如果是Tail，需要特殊判断
            if (node.R != null)
            {
                node.R.L = node.L;
            }
            else
            {
                Tail = node.L;
            }
            size -= 1;
        }

        public Node<K, V> RemoveLastNode()
        {
            Node<K, V> last = Tail;
            Tail.L.R = null;
            Tail = Tail.L;
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
            if (node.R != null)
                wirteN(node.R);
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
            if (node.L != null)
                wirteP(node.L);
        }
        #endregion
    }
}
