using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew
{
    
    public class NodeMultiway<K, V> : RL_DoubleList<K, V> where V : ILRUNodeToString, INodeDirection<K>, INodeSerach, INodeCopy<V>
    {
        private SearchTest<K> _searchDelegate;
        private CalculateTheScore<K,V> _calculateTheScore;
        private object _senderArgs;
        public NodeMultiway()
        { }
        private NodeMultiway(CalculateTheScore<K,V> calculateTheScore,object senderArgs) :this()
        {
            _calculateTheScore = calculateTheScore;
            _senderArgs = senderArgs;
        }

        //public CalculateTheScore CalculateTheScore { get { return _calculateTheScore; } }
        public NodeMultiway<K, V> GetAllDirection(Node<K, V> node, object senderArgs, CalculateTheScore<K, V> calculateTheScore)
        {
            _senderArgs = senderArgs;
            _calculateTheScore =calculateTheScore;
            NodeMultiway<K, V> nodeMultiway = new NodeMultiway<K, V>(_calculateTheScore, senderArgs);
            var _newNode = node.Copy(senderArgs);
            if (_newNode == null)
            {
                return null;
            }
            base.H_Line(_newNode, senderArgs, nodeMultiway);
            base.S_Line(_newNode, senderArgs, nodeMultiway);
            base.LR_Line(_newNode, senderArgs, nodeMultiway);
            base.RL_Line(_newNode, senderArgs, nodeMultiway);
            return nodeMultiway;
        }

        public NodeMultiway<K, V> GetAllDirection(Node<K, V> node, object senderArgs, SearchTest<K> searchDelegate, CalculateTheScore<K,V> calculateTheScore)
        {
            _searchDelegate = searchDelegate;
            InitRegister();
            return GetAllDirection(node, senderArgs, _calculateTheScore);
        }
      
        #region test
        protected void Test(V value)
        {
            _searchDelegate(value);
        }

        private void InitRegister()
        {
            InitRegister(Test);
        }
        #endregion
        
        private void InitRegister(SeachePath<V> seachePath)
        {
            L_Path = new SeachePath<V>(seachePath);
            R_Path = new SeachePath<V>(seachePath);
            U_Path = new SeachePath<V>(seachePath);
            D_Path = new SeachePath<V>(seachePath);
            L_LU_Path = new SeachePath<V>(seachePath);
            L_RD_Path = new SeachePath<V>(seachePath);
            R_RU_Path = new SeachePath<V>(seachePath);
            R_LD_Path = new SeachePath<V>(seachePath);
        }

        public List<NodeList<K, V>> ToList()
        {
            List<NodeList<K, V>> nodeLists = new List<NodeList<K, V>>();
            if (this.H_Head != null)
            {
                Displacement H = new Displacement(Reset_H);
                DesignativePosition<K, V> H_position = new DesignativePosition<K, V>(Get_H);
                NodeList<K, V> nodeList1 = new NodeList<K, V>(this.H_Head, this.H_Tail, this.H_Size(), this.H_ToIdentification(_senderArgs), H_position, H, _calculateTheScore, _senderArgs);

                nodeLists.Add(nodeList1);
            }
            if (this.LR_Head != null)
            {
                Displacement LR = new Displacement(Reset_LR);
                DesignativePosition<K, V> LR_position = new DesignativePosition<K, V>(Get_LR);

                NodeList<K, V> nodeList2 = new NodeList<K, V>(this.LR_Head, this.LR_Tail, this.LR_Size(), this.LR_ToIdentification(_senderArgs), LR_position, LR, _calculateTheScore, _senderArgs);

                nodeLists.Add(nodeList2);
            }
            if (this.RL_Head != null)
            {
                Displacement RL = new Displacement(Reset_RL);
                DesignativePosition<K, V> RL_position = new DesignativePosition<K, V>(Get_RL);
                NodeList<K, V> nodeList3 = new NodeList<K, V>(this.RL_Head, this.RL_Tail, this.RL_Size(), this.RL_ToIdentification(_senderArgs), RL_position, RL, _calculateTheScore, _senderArgs);

                nodeLists.Add(nodeList3);
            }
            if (this.S_Head != null)
            {
                Displacement S = new Displacement(Reset_S);
                DesignativePosition<K, V> S_position = new DesignativePosition<K, V>(Get_S);
                NodeList<K, V> nodeList4 = new NodeList<K, V>(this.S_Head, this.S_Tail, this.S_Size(), this.S_ToIdentification(_senderArgs), S_position, S, _calculateTheScore, _senderArgs);

                nodeLists.Add(nodeList4);
            }
            return nodeLists;
        }
        

    }
}
