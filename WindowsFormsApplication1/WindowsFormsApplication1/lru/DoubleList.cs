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
        }

        public Node RemoveLast()
        {
            Node lastNode = Tail;
            Tail = lastNode.PreNode;
            Tail.NexNode = null;
            return lastNode;
        }
        public int Size()
        {
            return size;
        }

        public void WirteLineNext()
        {
            wirteN(Head);
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
    }
}
