using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew
{
    public abstract class RL_DoubleList<K, V> : LR_DoubleList<K, V> where V : ILRUNodeToString, INodeDirection<K>, INodeSerach, INodeCopy<V>
    {
        private Node<K, V> RL_CNode;
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


        #region 根据节点找出一条线

        protected RL_DoubleList<K, V> RL_Line(Node<K, V> node, object obj, RL_DoubleList<K, V> rl_DoubleList)
        {
            //RL_DoubleList<K, V> rl_DoubleList = new NodeMultiway<K, V>();
            R_LD(node.Copy(), obj, rl_DoubleList);
            R_RU(node.Copy(), obj, rl_DoubleList);
            RL_DelegateComplate(rl_DoubleList);
            return rl_DoubleList;
        }

        private void R_LD(Node<K, V> node, object obj, RL_DoubleList<K, V> rl_DoubleList)
        {
            if (node != null)
            {
                if (node.SerchNode(obj))
                {
                    if (node.R_RU != null)
                        R_LD(node.R_RU, obj, rl_DoubleList);
                    rl_DoubleList.RL_AddNode(node);
                    R_LD_Delegate(node.Value);
                }
            }
        }

        private void R_RU(Node<K, V> node, object obj, RL_DoubleList<K, V> rl_DoubleList)
        {
            if (node.R_LD != null)
            {
                if (node.R_LD.SerchNode(obj))
                {
                    R_RU(node.R_LD, obj, rl_DoubleList);
                    rl_DoubleList.RL_InsertNode(node, node.R_LD);
                    R_RU_Delegate(node.R_LD.Value);
                }
            }
        }

        #endregion

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

        #region ILRUNodeToString 
        public string RL_ToIdentification(object senderArgs)
        {
            string value = "";
            RLToString(RL_Head, senderArgs,ref value);
            return value;
        }
        private void RLToString(Node<K, V> node, object senderArgs,ref string value)
        {
            if (node != null)
            {
                value += node.ToIdentification(senderArgs);
            }
            if (node.R_LD != null)
                RLToString(node.R_LD, senderArgs,ref value);
        }
        #endregion

        #region Reset
        protected void Reset_RL(int leftCount, int rightCount)
        {
            if(leftCount>0)
                _ResetHead(RL_Head, 0, leftCount);
            if (rightCount > 0)
                _ResetTail(RL_Tail, 0, rightCount);
        }

        private void _ResetHead(Node<K, V> node, int count, int totalCount)
        {
            if (node.R_LD != null)
            {
                count++;
                if (count == totalCount)
                {
                    RL_Head = node.R_LD;
                }
                else
                    _ResetHead(node.R_LD, count, totalCount);
            }
        }
        private void _ResetTail(Node<K, V> node, int count, int totalCount)
        {
            if (node.R_RU != null)
            {
                count++;
                if (count == totalCount)
                {
                    RL_Tail = node.R_RU;
                }
                else
                    _ResetTail(node.R_RU, count, totalCount);
            }
        }
        #endregion

        #region Displacement

        protected Node<K, V> Get_RL(int totalCount)
        {
            if (totalCount == 1) return RL_Head;
            return RL_Displacement(RL_Head, 1, totalCount);
        }
        private Node<K, V> RL_Displacement(Node<K, V> node, int count, int totalCount)
        {
            if (node.R_LD != null)
            {
                count++;
                if (count == totalCount)
                {
                    return node.R_LD;
                }
                else
                    return RL_Displacement(node.R_LD, count, totalCount);
            }
            throw new Exception("没有获取到空位！");
        }
        #endregion
    }

}
