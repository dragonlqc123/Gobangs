using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew.Rectangles
{
    public interface IRectangleModel<Key>: ILRUNodeToString, INodeDirection<Key>
    {
    }
}
