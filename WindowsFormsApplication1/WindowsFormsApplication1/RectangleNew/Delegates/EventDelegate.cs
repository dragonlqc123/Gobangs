using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew
{

    public delegate void RectangAddFirstComplate(object obj);
    public delegate object ScatterNode(object key);
    public delegate void SeachePath<V>(V value);
    public delegate void SearchTest<K>(object entityData);
}
