using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew
{
    public abstract class AbstractCache<K, V> : IAbstractCache<K, V> where V : ILRUNodeToString, INodeDirection<K>, INodeSerach, INodeCopy<V>
    {
        protected Dictionary<K, Node<K, V>> Summary_map;
        protected NodeMultiway<K, V> Summary_list;

        protected Dictionary<K, Node<K, V>> H_map;
        protected NodeMultiway<K, V> H_list;
        protected int H_Captity;

        protected Dictionary<K, Node<K, V>> S_map;
        protected NodeMultiway<K, V> S_list;
        protected int S_Captity;

        protected Dictionary<K, Node<K, V>> LR_map;
        protected NodeMultiway<K, V> LR_list;
        protected int LR_Captity;

        protected Dictionary<K, Node<K, V>> RL_map;
        protected NodeMultiway<K, V> RL_list;
        protected int RL_Captity;

        public AbstractCache(int captity) : this()
        {
            H_Captity =
            S_Captity =
            LR_Captity =
            RL_Captity = captity;
        }

        public AbstractCache()
        {
            this.H_map = new Dictionary<K, Node<K, V>>();
            this.S_map = new Dictionary<K, Node<K, V>>();
            this.LR_map = new Dictionary<K, Node<K, V>>();
            this.RL_map = new Dictionary<K, Node<K, V>>();
            this.H_list = new NodeMultiway<K, V>();
            this.S_list = new NodeMultiway<K, V>();
            this.LR_list = new NodeMultiway<K, V>();
            this.RL_list = new NodeMultiway<K, V>();
            Summary_map = new Dictionary<K, Node<K, V>>();
            Summary_list = new NodeMultiway<K, V>();
        }

        
        protected void AddNodeComplate(K key, Node<K, V> newNode)
        {
            if (!Summary_map.ContainsKey(key))
            {
                Summary_map.Add(key, newNode);
            }
        }

        public V Summary_Get(K key)
        {
            if (!Summary_map.ContainsKey(key))
            {
                return default(V);
            }
            else
            {
                V value = Summary_GetNode(key).Value;
                return value;
            }
        }
        public Node<K,V> Summary_GetNode(K key)
        {
            if (!Summary_map.ContainsKey(key))
            {
                return default(Node<K, V>);
            }
            else
            {
                Node<K, V> value = Summary_map[key];
                return value;
            }
        }

        protected Node<K, V> CreateNodeReturn(K key, V value)
        {
            if (Summary_map.ContainsKey(key))
            {
                return Summary_map[key];
            }
            else
                return new Node<K, V>(key, value);
        }

        #region ISerchCache
        protected NodeMultiway<K, V> TestSeacheNodes(K key, object condition, SearchTest<K> searchDelegate)
        {
            Node<K, V> _node = Summary_GetNode(key);
            if (_node != null)
            {
                return Summary_list.GetAllDirection(_node.Copy(), condition, searchDelegate);
            }
            return null;
        }
        protected NodeMultiway<K, V> SeacheNodes(K key, object condition)
        {
            Node<K, V>  _node =Summary_GetNode(key);
            if (_node != null)
            {
                return Summary_list.GetAllDirection(_node.Copy(), condition);
            }
            return null;
        }

        #endregion
        #region test

        public void WriteLine(Direction direction, Sort sort)
        {
            if (direction == Direction.H)
            {
                if (sort == Sort.ASC)
                {
                    H_list.H_WirteLine_L();
                }
                else
                    H_list.H_WirteLine_R();

            }
            else if (direction == Direction.S)
            {
                if (sort == Sort.ASC)
                {
                    S_list.S_WirteLine_U();
                }
                else
                    S_list.S_WirteLine_D();

            }
            else if (direction == Direction.LR)
            {
                if (sort == Sort.ASC)
                {
                    LR_list.LR_WirteLine_L_LU();
                }
                else
                    LR_list.LR_WirteLine_L_RD();

            }
            else if (direction == Direction.RL)
            {
                if (sort == Sort.ASC)
                {
                    RL_list.RL_WirteLine_R_RU();
                }
                else
                    RL_list.RL_WirteLine_R_LD();
            }
        }
        public void WriteLine(Direction direction, Sort sort, Node<K, V> node)
        {
            if (direction == Direction.H)
            {
                if (sort == Sort.ASC)
                {
                    H_list.H_WirteLine1_L(node);
                }
                else
                    H_list.H_WirteLine1_R(node);
            }
            else if (direction == Direction.S)
            {
                if (sort == Sort.ASC)
                {
                    S_list.S_WirteLine1_U(node);
                }
                else
                    S_list.S_WirteLine1_D(node);

            }
            else if (direction == Direction.LR)
            {
                if (sort == Sort.ASC)
                {
                    LR_list.LR_WirteLine1_L_LU(node);
                }
                else
                    LR_list.LR_WirteLine1_L_RD(node);

            }
            else if (direction == Direction.RL)
            {
                if (sort == Sort.ASC)
                {
                    RL_list.RL_WirteLine1_R_RU(node);
                }
                else
                    RL_list.RL_WirteLine1_R_LD(node);
            }
        }

        #endregion
    }

    public enum Direction
    {
        H,
        S,
        LR,
        RL
    }

    public enum Sort
    {
       ASC,
       DESC,
    }

    public interface IOperation
    {
        void SelectLine();
        void SelectAllLine();
        
    }
}
