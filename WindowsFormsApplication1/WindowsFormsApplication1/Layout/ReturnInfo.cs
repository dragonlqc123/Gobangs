using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class ReturnInfo
    {
        public ReturnInfo(bool isSucces, string info)
        {
            IsSucces = isSucces;
            Info = info;
        }

        public bool IsSucces { get; set; }
        public string Info { get; set; }

        public static ReturnInfo GetDefaultInfo()
        {
           return new ReturnInfo(true, "平局");
        }
    }
}
