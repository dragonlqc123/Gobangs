using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew
{

    public interface IScore<V>
    {
        string AnswerSheet { get; }
        int Score { get; }
    }
}
