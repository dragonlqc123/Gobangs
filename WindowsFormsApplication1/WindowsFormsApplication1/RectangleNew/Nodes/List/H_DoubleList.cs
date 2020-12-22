using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew
{

    public abstract class DoubleListDelegate<V>
    {
        protected SeachePath<V> L_Path;
        protected SeachePath<V> R_Path;
        protected SeachePath<V> U_Path;
        protected SeachePath<V> D_Path;
        protected SeachePath<V> L_LU_Path;
        protected SeachePath<V> L_RD_Path;
        protected SeachePath<V> R_RU_Path;
        protected SeachePath<V> R_LD_Path;

        protected void L_Delegate(V value)
        {
            if (L_Path != null)
            {
                L_Path(value);
            }
        }
        protected void R_Delegate(V value)
        {
            if (R_Path != null)
            {
                R_Path(value);
            }
        }
        protected void U_Delegate(V value)
        {
            if (U_Path != null)
            {
                U_Path(value);
            }
        }
        protected void D_Delegate(V value)
        {
            if (D_Path != null)
            {
                D_Path(value);
            }
        }
        protected void L_RD_Delegate(V value)
        {
            if (L_RD_Path != null)
            {
                L_RD_Path(value);
            }
        }
        protected void L_LU_Delegate(V value)
        {
            if (L_LU_Path != null)
            {
                L_LU_Path(value);
            }
        }
        protected void R_RU_Delegate(V value)
        {
            if (R_RU_Path != null)
            {
                R_RU_Path(value);
            }
        }
        protected void R_LD_Delegate(V value)
        {
            if (R_LD_Path != null)
            {
                R_LD_Path(value);
            }
        }

        protected SeachePath<DoubleListDelegate<V>> HL_PathComplate;
        protected SeachePath<DoubleListDelegate<V>> LR_PathComplate;
        protected SeachePath<DoubleListDelegate<V>> RL_PathComplate;
        protected SeachePath<DoubleListDelegate<V>> S_PathComplate;

        protected void HL_DelegateComplate(DoubleListDelegate<V> value)
        {
            if (HL_PathComplate != null)
            {
                HL_PathComplate(value);
            }
        }
        protected void LR_DelegateComplate(DoubleListDelegate<V> value)
        {
            if (LR_PathComplate != null)
            {
                LR_PathComplate(value);
            }
        }
        protected void RL_DelegateComplate(DoubleListDelegate<V> value)
        {
            if (RL_PathComplate != null)
            {
                RL_PathComplate(value);
            }
        }
        protected void S_DelegateComplate(DoubleListDelegate<V> value)
        {
            if (S_PathComplate != null)
            {
                S_PathComplate(value);
            }
        }

    }
    public abstract class H_DoubleList<K, V> : DoubleListDelegate<V> where V : ILRUNodeToString, INodeDirection<K>, INodeSerach, INodeCopy<V>
    {
        private Node<K, V> H_CNode;
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
        public void H_InsertNode(Node<K, V> currentNode, Node<K, V> new_Node)
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

        #region 根据节点找出一条线

        protected H_DoubleList<K, V> H_Line(Node<K, V> node, object obj, H_DoubleList<K, V> h_DoubleList)
        {
            //H_DoubleList<K, V> h_DoubleList = new NodeMultiway<K, V>();
            H_R(node.Copy(), obj, h_DoubleList);
            H_L(node.Copy(), obj, h_DoubleList);
            HL_DelegateComplate(h_DoubleList);
            return h_DoubleList;
        }

        protected void H_R(Node<K, V> node, object obj, H_DoubleList<K, V> h_DoubleList)
        {
            if (node != null)
            {
                if (node.SerchNode(obj))
                {
                    if (node.L != null)
                        H_R(node.L, obj, h_DoubleList);
                    h_DoubleList.H_AddNode(node);
                    R_Delegate(node.Value);
                }
            }
        }

        private void H_L(Node<K, V> node, object obj, H_DoubleList<K, V> h_DoubleList)
        {
            if (node.R != null)
            {
                if (node.R.SerchNode(obj))
                {
                    H_L(node.R, obj, h_DoubleList);
                    h_DoubleList.H_InsertNode(node, node.R);
                    L_Delegate(node.R.Value);
                }
            }
        }

        #endregion

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
                Console.WriteLine("右边：" + node.ToString() + " ");
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
                Console.WriteLine("左边：" + node.ToString() + " ");
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

        #region ILRUNodeToString 
        public string H_ToIdentification(object senderArgs)
        {
            string value = "";
            HLToString(H_Head, senderArgs, ref value);
            return value;
        }
        private void HLToString(Node<K, V> node, object senderArgs, ref string value)
        {
            if (node != null)
            {
                value += node.ToIdentification(senderArgs);
            }
            if (node.R != null)
                HLToString(node.R, senderArgs, ref value);
        }
        #endregion

        #region Reset
        protected void Reset_H(int leftCount, int rightCount)
        {
            if(leftCount>0)
                _ResetHead(H_Head, 0, leftCount);
            if (rightCount > 0)
                _ResetTail(H_Tail, 0, rightCount);
        }

        private void _ResetHead(Node<K, V> node, int count, int totalCount)
        {
            if (node.R != null)
            {
                count++;
                if (count == totalCount)
                {
                    H_Head = node.R;
                }
                else
                    _ResetHead(node.R, count, totalCount);
            }
        }
        private void _ResetTail(Node<K, V> node, int count, int totalCount)
        {
            if (node.L != null)
            {
                count++;
                if (count == totalCount)
                {
                    H_Tail = node.L;
                }
                else
                    _ResetTail(node.L, count, totalCount);
            }
        }
        #endregion

        #region Displacement

        protected Node<K, V> Get_H(int totalCount)
        {
            if (totalCount == 1) return H_Head;
            return H_Displacement(H_Head,1, totalCount);
        }
        private Node<K, V> H_Displacement(Node<K, V> node, int count, int totalCount)
        {
            if (node.R != null)
            {
                count++;
                if (count == totalCount)
                {
                    return node.R;
                }
                else
                    return H_Displacement(node.R, count, totalCount);
            }
            throw new Exception("没有获取到空位！");
        }
        #endregion
    }




}
