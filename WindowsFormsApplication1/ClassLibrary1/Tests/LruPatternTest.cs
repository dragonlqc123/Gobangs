using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApplication1.lru.Pattern;

namespace WindowsFormsApplication1
{
    public class LruPatternTest
    {
        public static void Test()
        {
            LRUCache<string, UserInfo> lruCache = new LRUCache<string, UserInfo>(5);
            for (int i = 0; i < 6; i++)
            {
                lruCache.Push(i.ToString(),new UserInfo(i.ToString(),"盘古",10*i));
            }
            Display(lruCache);
            if (Console.ReadLine() == "y") { }
            int j = 1;
            for (int i = 1; i < 1000; i++)
            {
                Console.WriteLine("\n===============================" + j);
                lruCache.Push(i.ToString(), new UserInfo(i.ToString(), "盘古", 10 * i));
                Display(lruCache);
                j++;
                if (Console.ReadLine() == "y")
                    continue;
            }
        }
        private static void Display(LRUCache<string, UserInfo> lru)
        {
            Console.WriteLine("Next顺序显示......");
            lru.WirteLineNext();
            //Console.WriteLine("Pre顺序显示......");
            //lru.WirteLinePre();
        }
    }


    public class UserInfo: ILRUNodeToString
    {
        public UserInfo(string id, string userName, int age)
        {
            Id = id;
            UserName = userName;
            Age = age;
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return "{Id="+Id+",Name="+UserName+",Age="+Age+"}";
        }

    }
}
