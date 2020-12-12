using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApplication1.RectangleNew.Rectangles;

namespace WindowsFormsApplication1.RectangleNew
{
    public class TestDemo
    {
        GenerateRectangle<string> generateRectangle;
        public TestDemo(int captity, Dictionary<string, C_Point> c_Points)
        {
            Dictionary<string, IRectangleModel<string>> rectangleModel = new Dictionary<string, IRectangleModel<string>>();
            foreach (string key in c_Points.Keys)
            {
                rectangleModel.Add(key, c_Points[key]);
            }
            generateRectangle = new GenerateRectangle<string>(10000, rectangleModel);
        }
        public TestDemo(int captity, Dictionary<string, IRectangleModel<string>> c_Points)
        {
            generateRectangle = new GenerateRectangle<string>(10000, c_Points);
        }

        public IRectangleModel<string> this[string key]
        {
            get
            {
                Console.WriteLine("=========================");
                generateRectangle.WriteLineAll(key);
                return generateRectangle[key];
            }
        }
    }
}
