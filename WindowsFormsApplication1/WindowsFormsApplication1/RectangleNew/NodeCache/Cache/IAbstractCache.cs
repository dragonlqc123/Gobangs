﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew
{
    public interface IAbstractCache<K, V>
    {
        V Summary_Get(K key);
    }

    public interface ISeachCache<K,V>
    {
        //V SeacheNodes(K key, Direction direction, object condition);
    }
}
