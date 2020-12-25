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
        private GenerateRectangle<string> generateRectangle;
        private SearchTest<string> searchTest;
        private List<GrideView> _grideViews;
        private GetAll<string> _getAllDelegate;


        private TestDemo(int captity, Dictionary<string,C_Point> c_Points)
        {
            Dictionary<string, EntityData<string>> rectangleModel = new Dictionary<string, EntityData<string>>();
            foreach (string key in c_Points.Keys)
            {
                rectangleModel.Add(key, c_Points[key]);
            }
            generateRectangle = new GenerateRectangle<string>(1000000, rectangleModel);
            searchTest = new SearchTest<string>(TestPath);
        }
        public TestDemo(int captity, Dictionary<string, C_Point> c_Points, List<GrideView> grideViews) : this(captity, c_Points)
        {
            _grideViews = grideViews;
            _getAllDelegate = new GetAll<string>(GetAll);
        }

        private TestDemo(int captity, Dictionary<string, EntityData<string>> c_Points)
        {
            generateRectangle = new GenerateRectangle<string>(10000, c_Points);
        }

        public C_Point this[string key]
        {
            get
            {
                //Console.WriteLine("=========================");
                //generateRectangle.WriteLineAll(key);
                return (C_Point)generateRectangle[key];
            }
        }

        public C_Point AttackorDefense(bool? attackCondition,bool? defenseCondition,string key)
        {
            var c_Point = (C_Point)generateRectangle.Analysis(attackCondition, defenseCondition, _getAllDelegate,key);
            if (c_Point != null)
            {
                return this[c_Point.X+","+c_Point.Y];
            }
            throw new NotImplementedException("未实现找不到后的处理结果！！");
        }

        private List<string> GetAll(object attackOrdefenseCondition)
        {
            //_grideViews.Where(z => z.Node.State == state && z.Node.IsBlanck == isBlanck).ToList();
            List<GrideView> grideViews = _grideViews.Where(z => z.Node.IsBlanck == (bool?)attackOrdefenseCondition).ToList();
            List<string> _ls = new List<string>();
            foreach (var _g in grideViews)
            {
                _ls.Add(_g.Node.cpoint.X + "," + _g.Node.cpoint.Y);
            }
            return _ls;
        }

        public bool CheckVictory(WindowsFormsApplication1.Node node, object condition)
        {
            return generateRectangle.CheckVictory(node.cpoint.X + "," + node.cpoint.Y, condition);
        }

        #region test
        public C_Point Test(string key)
        {
           return (C_Point)generateRectangle.TestAnalysis(key, true, searchTest);
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
        #endregion

    }
}
