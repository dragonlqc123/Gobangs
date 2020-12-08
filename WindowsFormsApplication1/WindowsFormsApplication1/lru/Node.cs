using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.lru
{
    public class Node
    {
        public Node(int key, object values)
        {
            this.key = key;
            this.values = values;
        }

        public Node PreNode { get; set; }
        public Node NexNode { get; set; }

        public int key { get; set; }
        public Object values { get; set; }

        public override string ToString()
        {
            return "{key="+key+",value="+values+"}";
        }
    }
}
