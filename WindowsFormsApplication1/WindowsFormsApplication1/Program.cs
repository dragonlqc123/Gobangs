using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApplication1.lru;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
            //Test();
        }
        private static void Test()
        {
            LRUCache lru = new LRUCache(5);
            Console.WriteLine("\n===============================");
            lru.Push(1,"1");
            lru.Push(2, "2");
            lru.Push(1, "100");
            Display(lru);
            //int j = 1;
            //for (int i = 10; i < 1000; i++)
            //{
            //    Console.WriteLine("\n===============================" + j);
            //    lru.Push(i, i);
            //    Display(lru);
            //    j++;
            //    if (Console.ReadLine() == "y")
            //        continue;
            //}

            Console.Read();
        }
        private static void Display(LRUCache lru)
        {
            Console.WriteLine("Next顺序显示......");
            lru.WirteLineNext();
            //Console.WriteLine("Pre顺序显示......");
            //lru.WirteLinePre();
        }
    }
}
