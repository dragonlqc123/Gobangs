using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew
{
    public class NodeMultiway<K, V> : RL_DoubleList<K, V> where V : ILRUNodeToString, INodeDirection<K>
    {
    }
}
