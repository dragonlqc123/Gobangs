using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class User : Operation
    {
        public User(LayoutNode layoutNodes) : base(false, layoutNodes)
        {
        }
        
        public override Operation Next(Context context)
        {
            return context.computer;

        }

    }
}
