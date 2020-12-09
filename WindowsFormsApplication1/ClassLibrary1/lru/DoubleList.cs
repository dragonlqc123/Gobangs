using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.lru
{
    public class DoubleList
    {
        public Node Head;
        public Node Tail;
        public Node CNode;
        public int size;
        public void AddFirstNode(Node node)
        {
            if (Head == null)
            {
                Head = node;
                Tail = node;
                CNode = node;
                size = 1;
            }
            else
            {
                CNode = Head;
                Head = node;
                Head.NexNode = CNode;
                CNode.PreNode = Head;
                size += 1;
            }
        }

        public void Remove(Node node)
        {
            node.PreNode.NexNode = node.NexNode;
            // 如果是Tail，需要特殊判断
            if (node.NexNode != null)
            {
                node.NexNode.PreNode = node.PreNode;
            }
            else
            {
                Tail = node.PreNode;
            }
            size -= 1;
        }

        public Node RemoveLast()
        {
            Node last = Tail;
            Tail.PreNode.NexNode = null;
            Tail = Tail.PreNode;
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
            Console.WriteLine("总共："+size+"个");
        }

        private void wirteN(Node node)
        {
            if (node != null)
            {
                Console.WriteLine(node.ToString());
            }
            if (node.NexNode != null)
                wirteN(node.NexNode);
        }

        public void WirteLinePre()
        {
            wirteP(Tail);
            Console.WriteLine("总共：" + size + "个");
        }

        private void wirteP(Node node)
        {
            if (node != null)
            {
                Console.WriteLine(node.ToString());
            }
            if (node.PreNode != null)
                wirteP(node.PreNode);
        }
        #endregion
    }
}
