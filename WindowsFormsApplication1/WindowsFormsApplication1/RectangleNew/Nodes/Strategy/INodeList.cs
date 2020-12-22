using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace WindowsFormsApplication1.RectangleNew
{
    public interface INodeList<K, V> : IScore<V> where V : ILRUNodeToString, INodeDirection<K>, INodeSerach, INodeCopy<V>
    {
        Node<K, V> Head { get; }
        Node<K, V> Tail { get; }
        int Count { get; }
    }

    public interface INodeListScore<K, V> where V : ILRUNodeToString, INodeDirection<K>, INodeSerach, INodeCopy<V>
    {
        V GetV();
        int Score { get; }
    }
}
