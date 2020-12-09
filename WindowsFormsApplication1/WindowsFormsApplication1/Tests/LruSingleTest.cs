using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApplication1.lru;

namespace WindowsFormsApplication1
{
    public class LruSingleTest
    {
        public static void Test()
        {
            LRUCache lru = new LRUCache(5);
            Console.WriteLine("\n===============================");
            //lru.Push(1,"1");
            //lru.Push(2, "2");
            //lru.Push(1, "100");
            //Display(lru);
            for (int i = 1; i < 6; i++)
            {
                lru.Push(i, i);
            }
            Display(lru);
            if (Console.ReadLine() == "y") { }
            int j = 1;
            for (int i = 1; i < 1000; i++)
            {
                Console.WriteLine("\n===============================" + j);
                lru.Push(i, i);
                Display(lru);
                j++;
                if (Console.ReadLine() == "y")
                    continue;
            }

            Console.Read();
        }
        private static void Display(LRUCache lru)
        {
            //Console.WriteLine("Next顺序显示......");
            //lru.WirteLineNext();
            Console.WriteLine("Pre顺序显示......");
            lru.WirteLinePre();
        }
    }
}
