using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew.Rectangles
{                   
    public interface IRectangleModel<Key> : ILRUNodeToString, INodeDirection<Key>, INodeSerach 
    {
    }
    public interface IRectangleModel<Key, V> : IRectangleModel<Key>, INodeCopy<V>  where V : IRectangleModel<Key>, INodeCopy<V>
    { }

    public abstract class EntityData<Key> : IRectangleModel<Key, EntityData<Key>> 
    {
        public abstract Key _L { get; }

        public abstract Key _R { get; }

        public abstract Key _U { get; }

        public abstract Key _D { get; }

        public abstract Key _L_LU { get; }

        public abstract Key _L_RD { get; }

        public abstract Key _R_RU { get; }

        public abstract Key _R_LD { get; }

        public abstract EntityData<Key> Copy();
        public abstract string EmptySymbol();
        public abstract string IllegalSymbol();
        public abstract bool IsIllegalSymbol(object senderArgs);

        public abstract bool SerchNode(object conditionType);
        public abstract string Symbol();
        public abstract string ToIdentification(object conditionType);
    }
}
