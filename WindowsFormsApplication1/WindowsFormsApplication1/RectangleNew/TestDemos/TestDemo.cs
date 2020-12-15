using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApplication1.RectangleNew.Rectangles;

namespace WindowsFormsApplication1.RectangleNew
{
    public class TestDemo
    {
        public Context testContext = null;
        GenerateRectangle<string> generateRectangle;
        SearchTest<string> searchTest; 
        public TestDemo(int captity, Dictionary<string,C_Point> c_Points)
        {
            Dictionary<string, EntityData<string>> rectangleModel = new Dictionary<string, EntityData<string>>();
            foreach (string key in c_Points.Keys)
            {
                rectangleModel.Add(key, c_Points[key]);
            }
            generateRectangle = new GenerateRectangle<string>(1000000, rectangleModel);
            searchTest = new SearchTest<string>(TestPath);
        }

        public TestDemo(int captity, Dictionary<string, EntityData<string>> c_Points)
        {
            generateRectangle = new GenerateRectangle<string>(10000, c_Points);
        }

        public IRectangleModel<string> this[string key]
        {
            get
            {
                //Console.WriteLine("=========================");
                //generateRectangle.WriteLineAll(key);
                return generateRectangle[key];
            }
        }

        public void Test(string key)
        {
           generateRectangle.TestAnalysis(key, true, searchTest);
        }

        private void TestPath(object obj)
        {
            C_Point c_Point = (C_Point)obj;
            testContext.TestNext(0, c_Point.X, c_Point.Y,10);
            if (c_Point.GridView.Row == 0)
            {
                Console.WriteLine("=====================");
            }
            Console.WriteLine(c_Point.X+","+ c_Point.Y);
        }
    }
}
